using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaveCrestColorMatch : MonoBehaviour
{
    WaterFillProgress water;
    SpriteRenderer waterSprite;

    private Color darkColor = new Color(84f / 255f, 140f / 255f, 209f / 255f, 1f);
    private Color lightColor = new Color(146f / 255f, 207f / 255f, 249f / 255f, 1f);

    void Start()
    {
        water = GameObject.FindGameObjectWithTag("Water").GetComponent<WaterFillProgress>();
        waterSprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        float fillValue = water.waterImage.fillAmount;
        Color interpolatedColor = Color.Lerp(darkColor, lightColor, fillValue);
        waterSprite.color = interpolatedColor;
    }
}
