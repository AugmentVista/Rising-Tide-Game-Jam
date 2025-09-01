using UnityEngine;

public class ClickerButton : MonoBehaviour
{
    public ScoreDisplay scoreDisplay;
    public Rigidbody2D rb;

    public float forwardBoatForce = 1f;

    internal int WaterIncreaseAmount = 1; // made this so the Clicker upgrade script can change the clickers value.

    internal float ScoreIncrease = 0; 

    private float score = 1;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        scoreDisplay = GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreDisplay>();
        if (scoreDisplay != null)
        {
            //Debug.Log("ScoreDisplay successfully connected.");
        }
        else { Debug.Log("ScoreDisplay failed to connect."); }
    }

    public void OnButtonClick()
    {
        scoreDisplay.tapCount += 1;
        float tapMultiplier = scoreDisplay.GetTapMultiplier();

        // Apply multiplier to score and force
        float totalScoreIncrease = (score + ScoreIncrease) * tapMultiplier;
        scoreDisplay.UpdateScore(totalScoreIncrease);

        rb.AddForce(Vector2.right * forwardBoatForce * tapMultiplier, ForceMode2D.Impulse);
    }
}
