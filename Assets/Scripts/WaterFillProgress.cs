using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class WaterFillProgress : MonoBehaviour
{
    public Image waterImage;

    public ScoreDisplay scoreDisplay;

    public TextMeshProUGUI waveCount;

    private int waveCountInt = 0;

    private float threshold = 10000f;

    private List<string> shipNames = new List<string>();

    void Start()
    {
        waterImage.fillAmount = 0f;
        shipNames.Add("Sloop");
        shipNames.Add("Schooner");
        shipNames.Add("Brigantine");
        shipNames.Add("Galleon");
        shipNames.Add("Man-o’-war");
        shipNames.Add("Super Sloop");
        shipNames.Add("Super Schooner");
        shipNames.Add("Super Brigantine");
        shipNames.Add("Super Galleon");
        shipNames.Add("Super Man-o’-war");
    }

    void Update()
    {
        waterImage.fillAmount = scoreDisplay.publicScore / threshold;
        scoreDisplay.shipName = shipNames[waveCountInt].ToString();
        if (waterImage.fillAmount == 1.0f)
        {
            waveCountInt++;
            waveCount.text = "Wave " + waveCountInt.ToString();
            threshold *= 3;
        }
    }
}
