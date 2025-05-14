using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseClickerScript : MonoBehaviour
{
    ScoreDisplay scoreDisplay;
    ClickerButton clickerButton;

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
            scoreDisplay.UpdateScore(-Cost);
            clickerButton.WaterIncreaseAmount += ClickIncrease;
            clickerButton.ScoreIncrease += ClickIncrease;
        }
    }
}
