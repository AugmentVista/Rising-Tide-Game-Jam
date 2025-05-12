using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestUnlock : MonoBehaviour
{
    public ScoreDisplay scoreDisplay;

    float scoreThreshold = 0;

    [SerializeField] GameObject Quest1;
    [SerializeField] GameObject Quest2;
    [SerializeField] GameObject Quest3;
    [SerializeField] GameObject Quest4;

    private void Start()
    {
        Quest1.SetActive(false);
        Quest2.SetActive(false);
        Quest3.SetActive(false);
        Quest4.SetActive(false);
    }

    void Update()
    {
        scoreThreshold = scoreDisplay.publicScore;
        UnlockQuest();
    }


    private void UnlockQuest()
    { 
        if(scoreThreshold > 20) 
        {
            Quest1.SetActive(true);
        }
        if (scoreThreshold > 100)
        {
            Quest2.SetActive(true);
        }
        if (scoreThreshold > 200)
        {
            Quest3.SetActive(true);
        }
        if (scoreThreshold > 300)
        {
            Quest4.SetActive(true);
        }
    }


}
