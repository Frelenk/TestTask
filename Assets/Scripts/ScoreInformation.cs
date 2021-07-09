using UnityEngine;

[CreateAssetMenu(fileName = "ScoreInfo", menuName = "Score table", order = 0)]
public class ScoreInformation : ScriptableObject
{
    [SerializeField] private int score;
    [SerializeField] private bool isSaving;

    public int Score
    {
        get
        {
            return score;
        }

        set
        {
            score = value;
        }
    }

    public bool IsSaving
    {
        get => isSaving;
    }
}
