using UnityEngine;

public class ClickerButton : MonoBehaviour
{
    public ScoreDisplay scoreDisplay;
    public WaterFillProgress waterFillProgress;
    public Rigidbody2D rb;

    public float forwardBoatForce = 1f;

    internal int WaterIncreaseAmount = 1; // made this so the Clicker upgrade script can change the clickers value.

    internal float ScoreIncrease = 0; // This is so the score can also be increased along with Wave height.

    private float score = 1;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        scoreDisplay = GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreDisplay>();
        waterFillProgress = GameObject.FindGameObjectWithTag("Water").GetComponent<WaterFillProgress>();
        if (scoreDisplay != null)
        {
            //Debug.Log("ScoreDisplay successfully connected.");
        }
        else { Debug.Log("ScoreDisplay failed to connect."); }
    }

    public void OnButtonClick()
    {
        //Debug.Log($"ClickerButton is calling UpdateScore on {scoreDisplay.gameObject.name}");

        scoreDisplay.UpdateScore(score + ScoreIncrease);
        //waterFillProgress.FillWater(WaterIncreaseAmount);

        rb.AddForce(Vector2.right * forwardBoatForce, ForceMode2D.Impulse);

    }
}
