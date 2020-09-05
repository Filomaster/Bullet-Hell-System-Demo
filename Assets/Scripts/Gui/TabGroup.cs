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


    public TabButton selectedTab;
    public Emmiter tabEmmiter;

    private GuiController controller;
    private BulletSystemController bulletSystem;
    private void Start()
    {
        controller = GuiController.Instance;
        bulletSystem = BulletSystemController.BulletSystem;

        foreach (KeyValuePair<string, Emmiter> emmiter in bulletSystem.emmitersGroups)
        {
            AddNewTab(emmiter.Key);

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
        if (selectedTab != null && button != selectedTab)
            button.background.color = hoveredColor;
    }

    public void OnTabExit(TabButton button)
    {
        ResetTabs();
    }

    public void OnTabSelect(TabButton button)
    {
        ResetTabs();
        selectedTab = button;
        button.background.sprite = tabActive;
        button.background.color = activeColor;
        controller.emmiter = bulletSystem.emmitersGroups[button.tabKey];
        controller.ResetControlsOnTabChange();
    }

    public void ResetTabs()
    {
        foreach (TabButton button in tabButtons)
        {
            if (selectedTab != null && button == selectedTab) continue;
            button.background.color = idleColor;
            button.background.sprite = tabSprite;
        }
    }

    public void AddNewTab(string key)
    {
        GameObject newTab = tabPrefab;
        TabButton button = tabPrefab.GetComponent<TabButton>();
        // button.tabEmmiter = tabEmmiter;
        button.tabGroup = this;
        button.emmiterIndex = 0;
        button.tabKey = key;
        // selectedTab = button;
        // newTab.transform.parent = parent.transform;
        Instantiate(newTab, parent.transform);
    }
    public void AddNewTab()
    {
        GameObject newTab = tabPrefab;
        TabButton button = tabPrefab.GetComponent<TabButton>();
        // button.tabEmmiter = tabEmmiter;
        button.tabGroup = this;
        newTab.name = button.name = button.tabKey = bulletSystem.CreateEmmiterGroup();

        // newTab.transform.parent = parent.transform;
        Instantiate(newTab, parent.transform);
    }
}
