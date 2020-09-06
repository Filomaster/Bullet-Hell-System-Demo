using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSystemController : MonoBehaviour
{
    [SerializeField]
    public Dictionary<string, Emmiter> emmitersGroups;
    public GameObject parent;
    public float rotationSpeed = 0f;
    public static BulletSystemController BulletSystem;
    public GameObject bulletPrefab;
    public int index = 0;


    #region Pooling
    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }

    [Range(100, 10000)]
    public int poolSize = 10000;

    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> poolDictionary;
    #endregion

    private void Awake()
    {
        BulletSystem = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        emmitersGroups = new Dictionary<string, Emmiter>();
        poolDictionary = new Dictionary<string, Queue<GameObject>>();


        CreateEmmiterGroup();
    }

    void FillPool(Pool pool, Transform parent)
    {
        Queue<GameObject> objectPool = new Queue<GameObject>();
        for (int i = 0; i < pool.size; i++)
        {
            GameObject obj = Instantiate(pool.prefab, parent);
            obj.SetActive(false);
            objectPool.Enqueue(obj);
        }
        poolDictionary.Add(pool.tag, objectPool);
    }

    public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation, float deceleration, float ttl)
    {

        Debug.Log("I'm here");
        GameObject objToSpawn = poolDictionary[tag].Dequeue();
        objToSpawn.SetActive(true);
        objToSpawn.transform.position = position;
        objToSpawn.transform.rotation = rotation;
        objToSpawn.GetComponent<Rigidbody>().velocity = Vector3.zero;

        IPooledObject pooled = objToSpawn.GetComponent<IPooledObject>();

        if (pooled != null)
        {
            pooled.OnObjectSpawn(deceleration, ttl);
        }

        poolDictionary[tag].Enqueue(objToSpawn);
        return objToSpawn;
    }

    private void Update()
    {
        parent.transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
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
        newEmmiter.angle = 90f;
        string key = "emmiter_" + index;
        newEmmiter.tag = key;
        Pool bulletPool = new Pool();
        bulletPool.prefab = bulletPrefab;
        bulletPool.size = poolSize;
        bulletPool.tag = key;
        FillPool(bulletPool, groupParent.transform);
        // Debug.Log(key);
        index++;
        emmitersGroups.Add(key, newEmmiter);
        return key;
    }
}