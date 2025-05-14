using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestButton : MonoBehaviour
{
    [Header("UI References")]
    public Button upgradeButton;
    public Image backgroundImage;
    public TextMeshProUGUI questText;
    public Image rewardIcon;

    [Header("Quest Data")]
    public float unlockScore;
    public BaseClickerScript baseClickerScript;
    public string lockedText; // Example: "Complete first wave"
    public string rewardDescription; // Example: "Clicker Strength +2"
    public string rewardName;
    string rewardPrice = "price: ";

    public bool isUnlocked = false;

    public void SetLockedState(bool locked)
    {
        isUnlocked = !locked;
        upgradeButton.interactable = !locked;

        // Color changes for locked/unlocked state
        backgroundImage.color = locked ? Color.gray : Color.white;

        if (locked)
        {
            questText.text = $"Unlock: {lockedText}";
        }
        else
        {
            questText.text = $"{rewardName}\n{rewardDescription}{baseClickerScript.ClickIncrease}: \n{rewardPrice}{baseClickerScript.Cost}";
        }
    }
}