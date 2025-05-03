using UnityEngine;
using UnityEngine.UI;

public class WaterFillProgress : MonoBehaviour
{
    public Image waterImage;

    public ScoreDisplay scoreDisplay;


    void Start()
    {
        waterImage.fillAmount = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        waterImage.fillAmount = scoreDisplay.publicScore / 10000f;
    }
}
