using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Image))]
public class TabButton : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler, IPointerExitHandler
{
    [HideInInspector]
    public TabGroup tabGroup;
    public Image background;
    public string buttonName;
    public TextMeshProUGUI tabName;
    public int emmiterIndex;
    // Start is called before the first frame update
    void Awake()
    {
        background = GetComponent<Image>();
        tabGroup.Subscribe(this);

        tabName.text = buttonName;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        tabGroup.OnTabSelect(this);
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        tabGroup.OnTabEnter(this);
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        tabGroup.OnTabExit(this);
    }


}
