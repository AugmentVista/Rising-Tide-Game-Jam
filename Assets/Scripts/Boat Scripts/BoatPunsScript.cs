using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BoatPunsScript : MonoBehaviour
{
    List<string> factsIndex = new List<string>();

    [SerializeField] private TextMeshProUGUI displayText;


    void Randomizefacts()
    {
        int randomizedBoatFact = Random.Range(0, factsIndex.Count);
        string currentBoatfact = factsIndex[randomizedBoatFact];
        displayText.text = currentBoatfact;
        
    }

    // Start is called before the first frame update
    void Start()
    {
        // Boat facts needed.
        factsIndex.Add("");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
