using UnityEngine;
using UnityEngine.Events;

public class UiChanges : MonoBehaviour
{
    [SerializeField] private GameViewChange _gameViewText;
    [SerializeField] private DeathViewChanges _deathViewText;
    [SerializeField] private GameObject _pausePanel, _deathPanel;
    private GameStage _gameStage = GameStage.gameStage;
    public UnityEvent PauseUnpause;

    public void GameStageChange(GameStage _gameChange)
    {
        _gameStage = _gameChange;
        if (_gameStage == GameStage.pauseStage) _pausePanel.SetActive(true);
        else if (_gameStage == GameStage.deathStage) _deathPanel.SetActive(false);
    }
    public GameStage GameStageChange()
    {
        return _gameStage;
    }

    private void Start()
    {
        _gameStage = GameStage.gameStage;
    }

    public void SetTextScore(int score)
    {
        _gameViewText.SetTextScore(score);
        _deathViewText.SetTextScore(score); 
    }

    public void GameStageView()
    {
        _pausePanel.SetActive(true);
        _gameStage = GameStage.pauseStage;
        PauseUnpause.Invoke();
    }

    public void PauseStageView()
    {
        _pausePanel.SetActive(false);
        _gameStage = GameStage.gameStage;
        PauseUnpause.Invoke();
    }

    public void DeathStageView()
    {
        _deathPanel.SetActive(true);
        _gameStage = GameStage.deathStage;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Button Escape On Click");
            if (_gameStage == GameStage.gameStage)
            {
                Debug.Log("_pausePanel set active");
                GameStageView();
            }
            else if (_gameStage == GameStage.pauseStage)
            {
                Debug.Log("_pausePanel set disactive");
                PauseStageView();
            }
        }
    }
}

public enum GameStage
{
    gameStage,
    pauseStage,
    deathStage
}