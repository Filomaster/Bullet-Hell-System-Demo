using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSystemController : MonoBehaviour
{
    [SerializeField]
    public List<EmmiterGroup> emmitersGroups;
    public GameObject parent;
    public static BulletSystemController BulletSystem;
    public int emmiterIndex = 0;

    private void Awake()
    {
        BulletSystem = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        emmitersGroups = new List<EmmiterGroup>();
        CreateEmmiterGroup();
    }

    public int CreateEmmiterGroup()
    {
        int index = emmiterIndex;
        GameObject groupParent = new GameObject();
        groupParent.name = "Emmiter Group " + index;
        groupParent.transform.parent = parent.transform;
        emmitersGroups.Add(groupParent.AddComponent<EmmiterGroup>());
        emmiterIndex++;
        return index;
    }
}