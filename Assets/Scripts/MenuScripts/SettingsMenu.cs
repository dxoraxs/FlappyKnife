using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField] private DataMemory _dataSO;
    [SerializeField] private  Image _soundEnable;
    [SerializeField] private Sprite _onSound, _offSound;
    public UnityEvent _returnToMainMenu;

    private void OnEnable()
    {
        _soundEnable.sprite = _dataSO.IsSound ? _onSound : _offSound;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _returnToMainMenu.Invoke();
        }
    }

    public void OnClickSoundButton()
    {
        _dataSO.IsSound = !_dataSO.IsSound;
        SceneManager.LoadScene(0);
    }

    public void OnClickResetButton()
    {
        _dataSO.BestScore = 0;
        _dataSO.IsSound= true;
        _dataSO.NumberBackground = 0;
        SceneManager.LoadScene(0);
    }
}
