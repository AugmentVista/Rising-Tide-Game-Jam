using TMPro;
using UnityEngine;

public class ClickerButton : MonoBehaviour
{
    public ScoreDisplay scoreDisplay;

    public float score;

    private void Start()
    {
        scoreDisplay = GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreDisplay>();
        if (scoreDisplay != null)
        {
            Debug.Log("ScoreDisplay successfully connected.");
        }
        else { Debug.Log("ScoreDisplay failed to connect."); }
    }

    public void OnButtonClick()
    {
        score++;
        scoreDisplay.GetScore(score);
    }
}
