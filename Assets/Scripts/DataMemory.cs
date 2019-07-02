using UnityEngine;

[CreateAssetMenu(menuName = "Data")]
public class DataMemory : ScriptableObject
{
    [Tooltip("Лучший счет")]
    [HideInInspector] public int BestScore;
    [Tooltip("Номер заднего фона")]
    [HideInInspector] public int NumberBackground;
    [Tooltip("Играть звуку или нет")]
    [HideInInspector] public bool IsSound;
}
