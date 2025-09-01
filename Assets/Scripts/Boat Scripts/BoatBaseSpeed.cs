using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatBaseSpeed : MonoBehaviour
{
    public ScoreDisplay scoreDisplay;
    Rigidbody2D rb;
    public float baseSpeed;

    float inverval = 3f;
    float timer = 0f;

    float AppliedForce = 0f;

    public float speedMaximumMult = 5.0f;

    private float totalMultiplier = 0f;

    private int pushCount = 0;

    void Start()
    {
        scoreDisplay = GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreDisplay>();
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(Vector2.right * baseSpeed, ForceMode2D.Impulse);
    }

     public void pushBoatForward()
    {
        // Generate a random multiplier between 1.0 and 5.0, rounded to 1 decimal place
        float randomMultiplier = Mathf.Round(Random.Range(1.0f, speedMaximumMult) * 10f) / 10f;

        // Apply force with random variance
        rb.AddForce(Vector2.right * baseSpeed * randomMultiplier, ForceMode2D.Force);

        AppliedForce = baseSpeed * randomMultiplier;

        // Update running totals for average
        totalMultiplier += randomMultiplier;
        pushCount++;
        
        float averageMultiplier = totalMultiplier / pushCount;

        //Debug.Log($"BoatBaseSpeed: Applied multiplier {randomMultiplier:F1} | " +
                  //$"Average multiplier so far: {averageMultiplier:F2} " +
                // $"(Total pushes: {pushCount})");
    }

    void FixedUpdate()
    {
        timer++;
        if (timer > inverval)
        {
            pushBoatForward();
            
            float DistanceTraveled(float AppliedForce)
                { 
                    float distance = AppliedForce * Time.fixedDeltaTime;
                    return distance;
                }
            scoreDisplay.UpdateScore(DistanceTraveled(AppliedForce));
            timer = 0;
        }
    }
}
