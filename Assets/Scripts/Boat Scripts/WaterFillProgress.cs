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
    private float threshold = 50;
    private float clickCount = 0;

    private int delay = 100; // fixed update counts to 100 every 2 seconds
    private int timer = 0;
    private float addBlend = 0.0f;
    private float waterDrainAmount = 2f;

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
            threshold = 50f;

            delay = 100; // 2 seconds
            weight = waterDrainAmount; // 1 per second
        }
        else if (scoreDisplay.shipName == ("Sad cat"))
        {
            threshold = 250f;

            delay = 100; // 2 seconds
            weight = 2 * waterDrainAmount; // 2 per second
        }
        else if (scoreDisplay.shipName == ("Lawnchair"))
        {
            threshold = 800f;

            delay = 50; // 1 second
            weight = 3 * waterDrainAmount; // 6 per second
        }
        else if (scoreDisplay.shipName == ("The half-boat"))
        {
            threshold = 2000f;

            delay = 50; // 1 second 
            weight = 10 * waterDrainAmount; // 20 per second
        }
        else if (scoreDisplay.shipName == ("Pet Rock"))
        {
            threshold = 5000f;

            delay = 25; // 0.5 seconds
            weight = 10 * waterDrainAmount; // 40 per second
        }

    }


    void Update()
    {
        boatSlider.value = waterImage.fillAmount;

        // only occurs when the water level reaches it's highest.
        if (waterImage.fillAmount >= 1.0f)
        {
            waveCountInt++;
            if (waveCountInt > 5) { waveCount.text = "All boats have risen"; }
            else { waveCount.text = "Wave " + waveCountInt.ToString() + " / " + shipNames.Count.ToString(); }
            waterImage.fillAmount = 0.0f;
            clickCount = 0;
            addBlend += 0.25f;
            boatAnimator.SetFloat("Blend", addBlend);
            scoreDisplay.shipName = shipNames[waveCountInt -1].ToString();
            ChangeWeight();
        }
    }
}