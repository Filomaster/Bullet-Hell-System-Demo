using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{

    public float deceleration;
    public float decelerationRate;
    public float ttl = 5f;
    private Rigidbody body;
    private void Awake()
    {

        body = this.GetComponent<Rigidbody>();
        // InvokeRepeating("Decelerate", 0, 1);
    }
    private void Start()
    {
        Destroy(this.gameObject, ttl);
        body.drag = deceleration;

    }
    void Decelerate()
    {
        body.drag = deceleration;
    }
}
