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

    private int waveCountInt = 0;
    private float threshold = 30f;
    private int clickCount = 0;

    private int delay = 5000;
    private int timer = 0;
    private float addBlend = 0.0f;

    public int weight = 1;

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
        shipNames.Add("Super Sloop");
        shipNames.Add("Super Schooner");
        shipNames.Add("Super Brigantine");
        shipNames.Add("Super Galleon");
        shipNames.Add("Super Man-o’-war");
        scoreDisplay.shipName = shipNames[waveCountInt].ToString();
    }

    /// <summary>
    /// Only clicking on boat should call this
    /// </summary>
    /// <param name="amount"></param>
    public void FillWater(int amount)
    {
        clickCount += amount;
        waterImage.fillAmount = clickCount / threshold;
    }

    public void DrainWater(int amount)
    {
        clickCount -= amount;
        waterImage.fillAmount = clickCount / threshold;
    }


    void Update()
    {
        timer++;
        if (timer > delay)
        {
            DrainWater(weight);
            timer = 0;
        }

        boatSlider.value = waterImage.fillAmount;

        if (waterImage.fillAmount >= 1.0f)
        {
            waveCountInt++;
            waveCount.text = "Wave " + waveCountInt.ToString();
            threshold *= 3;
            waterImage.fillAmount = 0.0f;
            clickCount = 0;
            addBlend += 0.25f;
            boatAnimator.SetFloat("Blend", addBlend);
            scoreDisplay.shipName = shipNames[waveCountInt].ToString();
        }
    }
}