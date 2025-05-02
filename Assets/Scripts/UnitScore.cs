using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class UnitScore : MonoBehaviour
{
    public Recruit unit;

    public ScoreDisplay scoreDisplay;

    private float unitScoreContribution;

    [SerializeField] private bool purchased;

    private int delay = 50;
    private int timer = 0;

    private void Start()
    {
        unitScoreContribution = unit.damagePerSecond;
        scoreDisplay = GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreDisplay>();
        if (scoreDisplay != null)
        {
            Debug.Log("ScoreDisplay successfully connected to UnitScore.");
        }
        else { Debug.Log("ScoreDisplay failed to connect to UnitScore"); }
    }

    void FixedUpdate()
    {
        timer++;
        if (timer > delay) 
        {
            if (purchased) 
            { 
                scoreDisplay.UpdateScore(unitScoreContribution); Debug.Log($"UnitScore is calling UpdateScore on {scoreDisplay.gameObject.name}"); 
            } 
            timer = 0; 
        }
    }

    public void PurchaseUnit()
    {
        if (!purchased) { purchased = true; }
    }

}