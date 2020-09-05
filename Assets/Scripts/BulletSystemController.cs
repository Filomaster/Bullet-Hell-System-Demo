using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSystemController : MonoBehaviour
{
    [SerializeField]
    public Dictionary<string, Emmiter> emmitersGroups;
    public GameObject parent;
    public static BulletSystemController BulletSystem;
    public GameObject bulletPrefab;
    public int index = 0;

    private void Awake()
    {
        BulletSystem = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        emmitersGroups = new Dictionary<string, Emmiter>();
        CreateEmmiterGroup();
    }

    public string CreateEmmiterGroup()
    {
        GameObject groupParent = new GameObject();
        groupParent.name = "Emmiter Group " + index;
        groupParent.transform.parent = parent.transform;
        Color32 bulletColor = Random.ColorHSV(0, 1, 1, 1, 1, 1, 1, 1);
        Emmiter newEmmiter = groupParent.AddComponent<Emmiter>();
        newEmmiter.bullet = bulletPrefab;
        newEmmiter.bulletColor = bulletColor;
        string key = "emmiter_" + index;
        Debug.Log(key);
        index++;
        emmitersGroups.Add(key, newEmmiter);
        return key;
    }
}