using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WaterFillProgress : MonoBehaviour
{
    public Image waterImage;

    public ScoreDisplay scoreDisplay;

    public TextMeshProUGUI waveCount;

    private int waveCountInt = 0;

    private float threshold = 10000f;


    void Start()
    {
        waterImage.fillAmount = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        waterImage.fillAmount = scoreDisplay.publicScore / threshold;

        if (waterImage.fillAmount == 1.0f)
        {
            waveCountInt++;
            waveCount.text = "Wave " + waveCountInt.ToString();
            threshold *= 3;
        }
    }
}
