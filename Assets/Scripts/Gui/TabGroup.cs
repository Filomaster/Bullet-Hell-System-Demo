using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabGroup : MonoBehaviour
{
    public List<TabButton> tabButtons;
    public GameObject parent;
    public GameObject tabPrefab;
    [Header("Tab Sprites")]
    public Color idleColor;
    public Color hoveredColor;
    public Color activeColor;
    public Sprite tabSprite;
    public Sprite tabActive;

    private GuiController controller;
    private BulletSystemController bulletSystem;
    private void Start()
    {
        controller = GuiController.Instance;
        bulletSystem = BulletSystemController.BulletSystem;

        foreach (EmmiterGroup emmiter in bulletSystem.emmitersGroups)
        {
            AddNewTab(true);
        }
    }

    public void Subscribe(TabButton button)
    {
        if (tabButtons == null) tabButtons = new List<TabButton>();
        tabButtons.Add(button);
    }

    public void OnTabEnter(TabButton button)
    {
        ResetTabs();
        button.background.color = hoveredColor;
    }

    public void OnTabExit(TabButton button)
    {
        ResetTabs();
    }

    public void OnTabSelect(TabButton button)
    {
        ResetTabs();
        button.background.sprite = tabActive;
        button.background.color = activeColor;
    }

    public void ResetTabs()
    {
        foreach (TabButton button in tabButtons)
        {
            button.background.color = idleColor;
            button.background.sprite = tabSprite;
        }
    }

    public void AddNewTab(bool isInitial)
    {
        GameObject newTab = tabPrefab;
        TabButton button = tabPrefab.GetComponent<TabButton>();
        newTab.name = button.name = "Emmiter Group";
        button.tabGroup = this;
        if (!isInitial)
            button.emmiterIndex = bulletSystem.CreateEmmiterGroup();
        else
            button.emmiterIndex = 0;
        Instantiate(newTab, parent.transform);
    }
}
