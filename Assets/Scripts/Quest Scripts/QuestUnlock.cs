using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestUnlock : MonoBehaviour
{
    public ScoreDisplay scoreDisplay;
    public QuestButton[] quests;

    void Start()
    {
        foreach (var quest in quests)
        {
            quest.SetLockedState(true);
        }
    }

    void Update()
    {
        float scoreThreshold = scoreDisplay.publicScore;

        foreach (var quest in quests)
        {
            if (!quest.isUnlocked && scoreThreshold >= quest.unlockScore)
            {
                quest.SetLockedState(false);
            }
        }
    }
}