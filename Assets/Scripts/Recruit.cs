using UnityEngine;

[CreateAssetMenu(fileName = "New Unit", menuName = "Units", order = 0)]
public class Recruit : ScriptableObject
{
    public string nameOfUnit;

    public int levelOfUnit;

    public string hireText;

    public float price;

    public Sprite unitImage;

    public float damagePerSecond;

    public GameObject infoPanel;
}