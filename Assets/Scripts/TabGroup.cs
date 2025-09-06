using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabGroup : MonoBehaviour
{
    public List<Tab_Button> tabButtons;
    public Sprite tabIdle;
    public Sprite tabHover;
    public Sprite tabSelected;
    public Tab_Button selectedTab;
    public List<GameObject> tabContents;

    public void Subscribe(Tab_Button button)
    {
        if (tabButtons == null)
        {
            tabButtons = new List<Tab_Button>();
        }
        tabButtons.Add(button);
    }

    public void OnTabEnter(Tab_Button button)
    {
        SetAllTabsIdle();
        if (selectedTab == null || button != selectedTab)
        { 
            button.backgroundImage.sprite = tabHover;
        }
    }

    public void OnTabExit(Tab_Button button)
    {
        SetAllTabsIdle();
    }

    public void OnTabSelected(Tab_Button button)
    {
        if (selectedTab != null)
        { 
            selectedTab.Deselect();
        }

        selectedTab = button;

        selectedTab.Select();

        SetAllTabsIdle();
        button.backgroundImage.sprite = tabSelected;
        int index = button.transform.GetSiblingIndex();
        for (int i = 0; i < tabContents.Count; i++)
        {
            if (i == index)
            {
                tabContents[i].SetActive(true);
            }
            else
            {
                tabContents[i].SetActive(false);
            }
        }
    }
    
    public void SetAllTabsIdle()
    {
        foreach (Tab_Button button in tabButtons)
        {
            if (selectedTab != null && button == selectedTab) { continue; }
            button.backgroundImage.sprite = tabIdle;
        }
    }
}
