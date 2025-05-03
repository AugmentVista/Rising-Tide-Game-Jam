using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UnitDisplay : MonoBehaviour
{
    public Recruit unit;

    public TMP_Text nameOfUnit;

    public TMP_Text levelOfUnit;

    public Image unitSprite;

    public TMP_Text hireText;

    public TMP_Text priceText;

    public TMP_Text damagePerSecond;

    public GameObject infoPanel;

    public int timesPurchased = 0;

    private void Start()
    {
        nameOfUnit.text = unit.nameOfUnit;

        levelOfUnit.text = unit.levelOfUnit.ToString();

        unitSprite.sprite = unit.unitImage;

        priceText.text = unit.price.ToString();

        damagePerSecond.text = unit.damagePerSecond.ToString() + " damage per second";

        infoPanel = unit.infoPanel;
    }

    public bool IsTitleMatch(string titleToCheck)
    {
        return nameOfUnit.text.Equals(titleToCheck, StringComparison.OrdinalIgnoreCase);
    }

}