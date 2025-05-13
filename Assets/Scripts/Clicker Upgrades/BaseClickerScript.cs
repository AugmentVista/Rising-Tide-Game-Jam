using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseClickerScript : MonoBehaviour
{
    public ScoreDisplay scoreDisplay;
    public ClickerButton clickerButton;

    public float Cost;

    public int ClickIncrease;

    // Start is called before the first frame update
    void Start()
    {
        scoreDisplay = GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreDisplay>();
        clickerButton = GameObject.FindGameObjectWithTag("BoatButton").GetComponent <ClickerButton>();
    }

    bool CanAfford()
    {
        if (scoreDisplay.publicScore >= Cost)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void BuyClickerUpgrade()
    {
        if (!CanAfford())
        {
            return;
        }
        else if (CanAfford())
        {
            scoreDisplay.publicScore -= Cost;
            clickerButton.WaterIncreaseAmmount += ClickIncrease;
            clickerButton.ScoreIncrease += ClickIncrease;
        }
    }
}
