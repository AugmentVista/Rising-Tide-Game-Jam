using TMPro;
using UnityEngine;

public class ScoreDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;

    [SerializeField] private float score = 0;

    private int delay = 200;
    private int timer = 0;

    public void UpdateScore(float clickerScore)
    {
        Debug.Log($"{gameObject.name} received score update: {clickerScore}");
        score += clickerScore;
        Debug.Log($"Clickerscore is {clickerScore}");

        scoreText.text = $"John Smith's Sloop Score: {score:F2}";
    }

    void Update()
    {
        timer++;
        if (timer > delay) { Debug.Log($"score is {score}"); timer = 0; }
    }
}
