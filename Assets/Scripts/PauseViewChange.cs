using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseViewChange : MonoBehaviour
{

    public void OnClickContinueButton()
    {
        transform.parent.GetComponent<UiChanges>().PauseStageView();
    }

    public void OnClickExitButton()
    {
        SceneManager.LoadScene(0);
        Debug.Log("Exit From GameScene");
    }
}