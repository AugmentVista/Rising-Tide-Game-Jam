using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;

    public float score;


    public void GetScore(float newScore)
    {
        score = newScore;
        scoreText.text = $"John Smith's Sloop Score: {score} ";
    }

    void Update()
    {
        for (int i = 0; i < 20; i++) { Debug.Log($"score is {score}"); if (i > 20) { i = 0; } }

            

    }
}
