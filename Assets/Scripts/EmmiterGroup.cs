using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EmmiterGroup : MonoBehaviour
{
    private GameObject parent;
    public GameObject bulletsObject;
    public Color bulletColor;
    [Range(5.0f, 30.0f)]
    public float BulletSpeed = 10.0f;
    [Range(0.0f, 1.5f)]
    public float FireDelay = 0.5f;


    public EmmiterGroup(GameObject parent)
    {
        this.parent = parent;
    }
}
