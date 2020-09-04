using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GuiController : MonoBehaviour
{

    public Emmiter emmiter;
    public List<EmmiterGroup> emmiters;
    public EmmiterGroup currentEmmiter;
    public GameObject parent;
    [Header("Speed")]
    public Slider speedSlider;
    public TextMeshProUGUI bulletSpeedValue;
    [Header("Delay")]
    public Slider delaySlider;
    public TextMeshProUGUI fireDelayValue;

    private BulletSystemController bulletSystemController;
    public static GuiController Instance;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {

        bulletSystemController = BulletSystemController.BulletSystem;
        speedSlider.value = emmiter.BulletSpeed;
        delaySlider.value = emmiter.FireDelay;
        bulletSpeedValue.text = emmiter.BulletSpeed.ToString("0.00");
        fireDelayValue.text = emmiter.FireDelay.ToString("0.00");
    }
    public void OnSpeedChange()
    {
        emmiter.BulletSpeed = speedSlider.value;
        bulletSpeedValue.text = emmiter.BulletSpeed.ToString("0.00");
    }

    public void OnDelayChange()
    {

        emmiter.FireDelay = delaySlider.value;
        fireDelayValue.text = emmiter.FireDelay.ToString("0.00");
    }

    public void AddEmmiterGroup()
    {
        EmmiterGroup emmiter = new EmmiterGroup(bulletSystemController.parent);
    }
}
