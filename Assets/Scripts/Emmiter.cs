using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emmiter : MonoBehaviour
{
    public GameObject bullet;
    public Color bulletColor;
    public GameObject parent;
    public string tag;
    public GameObject bulletGroup;
    private BulletSystemController controller;
    [Header("Bullets properties")]
    [Range(10f, 20f)]
    public float BulletSpeed = 10.0f;
    [Range(10f, 500f)]
    public float SpeedMultiplier = 50;
    [Range(0f, 10f)]
    public float bulletDeceleration = 0f;
    [Range(0f, 1f)]
    public float decelerationTime = 1f;
    [Range(1, 10)]
    public int ttl = 5;
    [Range(0f, 1f)]
    public float FireDelay = 0.5f;
    [Range(1, 20)]
    public int emmitersCount = 1;
    [Range(1, 50)]
    public int bulletsInRay = 1;
    [Header("Bullet angle")]
    [Range(0f, 360f)]
    public float angle = 0f;
    [Range(0f, 360f)]
    public float minAngle = 0f;
    [Range(0f, 360f)]
    public float maxAngle = 360f;
    [Header("Rotation")]
    [Range(-1000f, 1000f)]
    public float rotationSpeed = 0f;
    [Range(-1000f, 1000f)]
    public float parentRotation = 0f;
    [Range(0f, 1000f)]
    public float shiftX = 0f;
    // Start is called before the first frame update
    void Start()
    {
        controller = BulletSystemController.BulletSystem;
        if (parent == null)
        {
            parent = this.gameObject;
        }
        StartCoroutine("Fire");
    }
    private void Update()
    {
        angle += rotationSpeed * Time.deltaTime;
        angle = angle > 360f ? 0 : angle;
        parent.transform.Rotate(0, parentRotation * Time.deltaTime, 0);
    }
    // public void Update()
    // {
    //     this.transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
    // }
    // Update is called once per frame
    IEnumerator Fire()
    {
        yield return new WaitForSeconds(FireDelay);
        // for (int r = 0; r < bulletsInRay; r++)
        // {
        float angleStep = (maxAngle - minAngle) / emmitersCount;
        float currentAngle = angle;
        for (int i = 0; i < emmitersCount; i++)
        {
            float shiftedX = transform.position.x + shiftX;
            Vector3 shift = new Vector3(shiftedX, 0, shiftedX);
            float bulletDirectionX = transform.position.x + Mathf.Sin((currentAngle * Mathf.PI) / 180f);
            float bulletDirectionZ = transform.position.z + Mathf.Cos((currentAngle * Mathf.PI) / 180f);
            Vector3 bulletMoveVector = new Vector3(bulletDirectionX, 1, bulletDirectionZ);
            Vector3 bulletDirection = (bulletMoveVector - shift).normalized;

            // float ttl = 5 - Mathf.RoundToInt(BulletSpeed) - Mathf.RoundToInt(emmitersCount / 5);
            // if (ttl < 1) ttl = 1f;
            GameObject test = controller.SpawnFromPool(tag, bulletDirection, Quaternion.identity, bulletDeceleration, ttl);
            BulletScript bul = test.GetComponent<BulletScript>();
            test.GetComponent<Renderer>().material.SetColor("_EmissionColor", bulletColor);
            test.GetComponent<Rigidbody>().AddForce(new Vector3(BulletSpeed * bulletDirectionX * SpeedMultiplier, 0, BulletSpeed * bulletDirectionZ * SpeedMultiplier));
            currentAngle += angleStep;
        }
        // }
        StartCoroutine("Fire");
    }

    private void OnDestroy()
    {
        StopCoroutine("Fire");
    }
}
