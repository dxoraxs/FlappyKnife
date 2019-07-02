using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeathViewChanges : MonoBehaviour
{
    [SerializeField] private Text _textScore, _textBestScore;
    [SerializeField] private DataMemory _data;

    public void SetTextScore(int score)
    {
        int _bestScore = _data.BestScore;
        if (_bestScore <= score)
        {
            _bestScore = score;
            _data.BestScore = _bestScore;
        }
        _textScore.text = score.ToString();
        _textBestScore.text = _bestScore.ToString();
        //_textBestScore
    }

    public void OnClickExitButton()
    {
        SceneManager.LoadScene(0);
        Debug.Log("Exit From GameScene");
    }
}
