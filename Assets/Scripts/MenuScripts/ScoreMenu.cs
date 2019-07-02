using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ScoreMenu : MonoBehaviour
{
    [SerializeField] private DataMemory _dataSO;
    [SerializeField] private Text _bestScore;
    public UnityEvent _returnToMainMenu;

    private void OnEnable()
    {
        _bestScore.text = _dataSO.BestScore.ToString();
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _returnToMainMenu.Invoke();
            //Debug.Log("Score Menu Escape");
        }
    }
}
