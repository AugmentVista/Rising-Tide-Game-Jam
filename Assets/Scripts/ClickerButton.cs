using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ClickerButton : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;

    public int score = 0;



    public void OnButtonClick()
    {
        score++;
        scoreText.text = $"John Smith's Sloop Score: {score} small NUMBER";
    }
}
