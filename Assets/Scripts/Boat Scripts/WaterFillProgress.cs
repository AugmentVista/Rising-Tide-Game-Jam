using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class WaterFillProgress : MonoBehaviour
{
    public Image waterImage;
    public Slider boatSlider;
    public ScoreDisplay scoreDisplay;
    public TextMeshProUGUI waveCount;
    public Animator boatAnimator;

    private int waveCountInt = 1;
    private float threshold = 20f;
    private float clickCount = 0;

    private int delay = 100; // fixed update counts to 100 every 2 seconds
    private int timer = 0;
    private float addBlend = 0.0f;

    public float weight = 1;

    private List<string> shipNames = new List<string>();

    void Start()
    {
        waterImage.fillAmount = 0f;
        boatSlider.value = 0f;
        shipNames.Add("The Classic");
        shipNames.Add("Sad cat");
        shipNames.Add("Lawnchair");
        shipNames.Add("The half-boat");
        shipNames.Add("Pet Rock");
        scoreDisplay.shipName = shipNames[waveCountInt -1].ToString();
        waveCount.text = "Wave " + waveCountInt.ToString() + " / " + shipNames.Count.ToString();
    }

    /// <summary>
    /// Only clicking on boat should call this
    /// </summary>
    /// <param name="amount"></param>
    public void FillWater(float amount)
    {
        clickCount += amount;
        waterImage.fillAmount = clickCount / threshold;
    }

    public void DrainWater(float amount)
    {
        clickCount -= amount;
        waterImage.fillAmount = clickCount / threshold;
        if (clickCount < 0) { clickCount = 0; }
    }


    private void FixedUpdate()
    {
        timer++;
        if (timer > delay)
        {
            DrainWater(weight);
            timer = 0;
        }
    }

    public void ChangeWeight()
    {
        if (scoreDisplay.shipName == ("The Classic"))
        {
            weight = threshold/ 20;
        }
        else if (scoreDisplay.shipName == ("Sad cat"))
        {
            delay = 80;
            weight = threshold / 20;
        }
        else if (scoreDisplay.shipName == ("Lawnchair"))
        {
            delay = 60;
            weight = threshold / 20;
        }
        else if (scoreDisplay.shipName == ("The half-boat"))
        {
            delay = 50;
            weight = threshold / 20;
        }
        else if (scoreDisplay.shipName == ("Pet Rock"))
        {
            delay = 25;
            weight = threshold / 20;
        }

    }


    void Update()
    {
        boatSlider.value = waterImage.fillAmount;

        // only occurs when the water level reaches it's highest.
        if (waterImage.fillAmount >= 1.0f)
        {
            waveCountInt++;
            waveCount.text = "Wave " + waveCountInt.ToString() + " / " + shipNames.Count.ToString();
            threshold *= 5; // this could be a difficulty setting
            waterImage.fillAmount = 0.0f;
            clickCount = 0;
            addBlend += 0.25f;
            boatAnimator.SetFloat("Blend", addBlend);
            scoreDisplay.shipName = shipNames[waveCountInt -1].ToString();
            ChangeWeight();
        }
    }
}