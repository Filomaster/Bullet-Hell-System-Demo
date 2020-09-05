using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GuiController : MonoBehaviour
{

    public Emmiter emmiter;


    public GameObject parent;
    [Header("Speed")]
    public Slider speedSlider;
    public TextMeshProUGUI bulletSpeedValue;
    [Header("Delay")]
    public Slider delaySlider;
    public TextMeshProUGUI fireDelayValue;
    [Header("Emmiters")]
    public Slider emmitersSlider;
    public TextMeshProUGUI emmitersValue;

    private BulletSystemController bulletSystemController;
    public static GuiController Instance;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {

        bulletSystemController = BulletSystemController.BulletSystem;
        // emmitersSlider.wholeNumbers = true;
        ResetControlsOnTabChange();
        // if (emmiter == null)
        //     emmiter = bulletSystemController.emmitersGroups[0];

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

    public void OnEmmiterCountChange()
    {
        emmiter.emmitersCount = Mathf.RoundToInt(emmitersSlider.value);
        emmitersValue.text = emmiter.emmitersCount.ToString();
    }
    public void ResetControlsOnTabChange()
    {
        speedSlider.value = emmiter.BulletSpeed;
        delaySlider.value = emmiter.FireDelay;
        emmitersSlider.value = emmiter.emmitersCount;
        bulletSpeedValue.text = emmiter.BulletSpeed.ToString("0.00");
        fireDelayValue.text = emmiter.FireDelay.ToString("0.00");
        emmitersValue.text = emmiter.emmitersCount.ToString();
    }
    // public void AddEmmiterGroup()
    // {
    //     EmmiterGroup emmiter = new EmmiterGroup(bulletSystemController.parent);
    // }
}
