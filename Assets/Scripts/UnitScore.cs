using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class UnitScore : MonoBehaviour
{
    public Recruit unit;

    public ScoreDisplay scoreDisplay;

    public PurchaseManager purchaseManager;

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

        purchaseManager = GameObject.FindGameObjectWithTag("PurchaseManager").GetComponent<PurchaseManager>();
        if (purchaseManager != null)
        {
            Debug.Log("PurchaseManager successfully connected to UnitScore.");
        }
        else { Debug.Log("PurchaseManager failed to connect to UnitScore"); }
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

    public bool CanPlayerAffordThis(float cost)
    {
        float publicScore = scoreDisplay.publicScore;
        if (publicScore - cost >= 0)
        {
            scoreDisplay.UpdateScore(-cost);
            return true;
        }
        else return false;
    }

    public void PurchaseUnit()
    {
        if (!purchased)
        {
            if (CanPlayerAffordThis(unit.price))
            {
                { purchased = true; }
            }
        }
            
    }


}