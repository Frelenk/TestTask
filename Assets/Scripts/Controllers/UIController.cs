
using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private TMP_Text score;
    // Start is called before the first frame update

    public void UpdateInfo(ScoreInformation scoreInformation)
    {
        score.text = $"Score: {scoreInformation.Score.ToString()}";
    }
}
