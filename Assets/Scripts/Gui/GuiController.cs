using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GuiController : MonoBehaviour
{

    public Emmiter emmiter;
    public TextMeshProUGUI version;
    private static string VERSION = "0.1a";
    public GameObject parent;
    [Header("Speed")]
    public Slider speedSlider;
    public TextMeshProUGUI bulletSpeedValue;
    [Header("Delay")]
    public Slider delaySlider;
    public TextMeshProUGUI fireDelayValue;
    [Header("Emmiters Count")]
    public Slider emmitersSlider;
    public TextMeshProUGUI emmitersValue;
    [Header("Emmiters Angle")]
    public Slider angleSlider;
    public TextMeshProUGUI angleValue;
    [Header("Minimum Angle")]
    public Slider minAngleSlider;
    public TextMeshProUGUI minAngleValue;
    [Header("Maximum Angle")]
    public Slider maxAngleSlider;
    public TextMeshProUGUI maxAngleValue;
    [Header("Color")]
    public Slider colorSlider;
    public Image colorReference;
    [Header("Deceleration")]
    public Slider decelerationSlider;
    public TextMeshProUGUI decelerationValue;
    [Header("Rotation")]
    public Slider rotationSlider;
    public TextMeshProUGUI rotationValue;
    [Header("Children Rotation")]
    public Slider childrenRotationSlider;
    public TextMeshProUGUI childrenRotationValue;
    [Header("Parent Rotation")]
    public Slider parentRotationSlider;
    public TextMeshProUGUI parentRotationValue;

    [Header("TTL")]
    public Slider lifetimeSlider;
    public TextMeshProUGUI lifetimeValue;


    [Header("Time button")]
    public Button timeButton;
    public Sprite pauseButton;
    public Sprite playButton;

    private BulletSystemController bulletSystemController;
    public static GuiController Instance;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {

        bulletSystemController = BulletSystemController.BulletSystem;
        version.text += VERSION;
        // emmitersSlider.wholeNumbers = true;
        ResetControlsOnTabChange();
        // if (emmiter == null)
        //     emmiter = bulletSystemController.emmitersGroups[0];

    }
    private void Update()
    {
        if (emmiter.rotationSpeed != 0)
        {
            angleSlider.value = emmiter.angle;
            angleValue.text = emmiter.angle.ToString("0");
        }
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
    public void OnAngleChange()
    {
        emmiter.angle = angleSlider.value;
        angleValue.text = emmiter.angle.ToString();
    }
    public void OnMinimumAngleChange()
    {
        emmiter.minAngle = minAngleSlider.value;
        minAngleValue.text = emmiter.minAngle.ToString();
    }
    public void OnMaximumAngleChange()
    {
        emmiter.maxAngle = maxAngleSlider.value;
        maxAngleValue.text = emmiter.maxAngle.ToString();
    }
    public void OnDecelerationChange()
    {
        emmiter.bulletDeceleration = decelerationSlider.value;
        decelerationValue.text = emmiter.bulletDeceleration.ToString("0.00");
    }
    public void OnColorChange()
    {
        emmiter.bulletColor = Color.HSVToRGB(colorSlider.value, 1, 1);
        colorReference.color = emmiter.bulletColor;
    }
    public void OnRotationChange()
    {
        emmiter.rotationSpeed = rotationSlider.value;
        rotationValue.text = emmiter.rotationSpeed.ToString();
    }
    public void OnLifetimeChange()
    {
        emmiter.ttl = Mathf.RoundToInt(lifetimeSlider.value);
        lifetimeValue.text = emmiter.ttl.ToString();
    }
    public void OnChildRotationChange()
    {
        emmiter.parentRotation = childrenRotationSlider.value;
        childrenRotationValue.text = emmiter.parentRotation.ToString();
    }
    public void OnParentRotationChange()
    {
        bulletSystemController.rotationSpeed = parentRotationSlider.value;
        parentRotationValue.text = bulletSystemController.rotationSpeed.ToString();
    }



    public void OnPauseButton()
    {
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
            timeButton.image.sprite = pauseButton;

        }
        else
        {
            Time.timeScale = 0;
            timeButton.image.sprite = playButton;
        }
    }

    public void OnDeleteButton()
    {
        if (bulletSystemController.emmitersGroups.Count > 1)
        {
            // BulletSystemController.emmitersGroups.Remove(selectedTab.key);
        }
    }

    public void ResetControlsOnTabChange()
    {
        speedSlider.value = emmiter.BulletSpeed;
        delaySlider.value = emmiter.FireDelay;
        emmitersSlider.value = emmiter.emmitersCount;
        angleSlider.value = emmiter.angle;
        minAngleSlider.value = emmiter.minAngle;
        maxAngleSlider.value = emmiter.maxAngle;
        rotationSlider.value = emmiter.rotationSpeed;
        lifetimeSlider.value = emmiter.ttl;
        childrenRotationSlider.value = emmiter.parentRotation;
        parentRotationSlider.value = bulletSystemController.rotationSpeed;
        decelerationSlider.value = emmiter.bulletDeceleration;
        Color.RGBToHSV(emmiter.bulletColor, out float H, out float S, out float V);
        colorSlider.value = H;


        bulletSpeedValue.text = emmiter.BulletSpeed.ToString("0.00");
        fireDelayValue.text = emmiter.FireDelay.ToString("0.00");
        emmitersValue.text = emmiter.emmitersCount.ToString();
        angleValue.text = emmiter.angle.ToString();
        maxAngleValue.text = emmiter.maxAngle.ToString();
        minAngleValue.text = emmiter.minAngle.ToString();
        decelerationValue.text = emmiter.bulletDeceleration.ToString("0.00");
        colorReference.color = emmiter.bulletColor;
        parentRotationValue.text = bulletSystemController.rotationSpeed.ToString();
        childrenRotationValue.text = emmiter.parentRotation.ToString();
        rotationValue.text = emmiter.rotationSpeed.ToString();
        lifetimeValue.text = emmiter.ttl.ToString();
    }
    // public void AddEmmiterGroup()
    // {
    //     EmmiterGroup emmiter = new EmmiterGroup(bulletSystemController.parent);
    // }
}
