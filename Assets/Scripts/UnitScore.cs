using UnityEngine;

public class UnitScore : MonoBehaviour
{
    public Recruit unit;

    public ScoreDisplay scoreDisplay;

    public UnitDisplay unitDisplay;

    private float unitScoreContribution;

    [SerializeField] private bool purchased;

    private int unitCount = 0;

    private float localPrice;

    private float priceEscalationRate = 1.15f;

    private int delay = 50;
    private int timer = 0;

    private void Start()
    {
        localPrice = unit.price;

        unitScoreContribution = unit.damagePerSecond;

        scoreDisplay = GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreDisplay>();
        if (scoreDisplay != null) { Debug.Log("ScoreDisplay successfully connected to UnitScore.");}
        else { Debug.Log("ScoreDisplay failed to connect to UnitScore"); }
    }

    void FixedUpdate()
    {
        timer++;
        if (timer > delay) 
        {
            if (purchased) 
            { 
                scoreDisplay.UpdateScore(unitScoreContribution * unitCount);
                float totalDPS = unitScoreContribution * unitCount;
                unitDisplay.damagePerSecond.text = totalDPS.ToString() + " Total damage per second";
                Debug.Log($"UnitScore is calling UpdateScore on {scoreDisplay.gameObject.name}"); 
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
        if (!purchased || unitCount > 0)
        {
            if (CanPlayerAffordThis(localPrice))
            {
                if (!purchased) { purchased = true; } 
                
                unitCount++;
                localPrice *= priceEscalationRate;
                unitDisplay.priceText.text = localPrice.ToString("F2");
                unitDisplay.levelOfUnit.text = unitCount.ToString();
            }
        }
    } 
}