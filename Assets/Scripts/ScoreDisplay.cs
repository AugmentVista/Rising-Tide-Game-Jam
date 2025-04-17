using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;


    void Start()
    {
        scoreText.text = "John Smith's Sloop\r\n\r\nScore: small NUMBER";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
