using UnityEngine;
using UnityEngine.UI;

public class GameViewChange : MonoBehaviour
{
    [SerializeField] private Text _scoreTextUI;

    public void SetTextScore(int score)
    {
        _scoreTextUI.text = score.ToString();
    }
}