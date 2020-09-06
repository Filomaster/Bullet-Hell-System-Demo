using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour, IPooledObject
{

    public float ttl = 5f;
    private Rigidbody body;
    private void Awake()
    {

        body = this.GetComponent<Rigidbody>();
        // InvokeRepeating("Decelerate", 0, 1);
    }
    public void OnObjectSpawn(float deceleration, float ttl)
    {
        Debug.Log("Test");
        // Destroy(this.gameObject, ttl);
        body.drag = deceleration;
        this.ttl = ttl;
        StartCoroutine("Deactivate");
    }


    IEnumerator Deactivate()
    {
        yield return new WaitForSeconds(ttl);
        this.gameObject.SetActive(false);
        Debug.Log("Deactivated after " + ttl);
    }
}
