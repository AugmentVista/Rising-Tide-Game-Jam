using TMPro;
using UnityEngine;

public class ScoreDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;

    [SerializeField] private float score = 0;

    public string shipName;

    public float publicScore = 0;

    public void UpdateScore(float scoreToAdd)
    {
        Debug.Log($"{gameObject.name} received score update: {scoreToAdd}");
        score += scoreToAdd;
        Debug.Log($"Clickerscore is {scoreToAdd}");

        scoreText.text = $"{shipName} Score: {score:F2}";
        publicScore = score;
    }
}
