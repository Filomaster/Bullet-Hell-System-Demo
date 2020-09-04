using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emmiter : MonoBehaviour
{
    public GameObject bullet;
    public Color bulletColor;
    public GameObject parent;
    public GameObject bulletGroup;
    [Range(10f, 20f)]
    public float BulletSpeed = 10.0f;
    [Range(0f, 2f)]
    public float FireDelay = 0.5f;
    [Range(1, 20)]
    public int emmitersCount = 1;
    [Range(0f, 20f)]
    public float shift = 0f;
    [Header("Bullet angle")]
    [Range(0f, 360f)]
    public float angle = 0f;
    [Range(0f, 360f)]
    public float minAngle = 0f;
    [Range(0f, 360f)]
    public float maxAngle = 360f;
    [Header("Rotation")]
    [Range(-100f, 100f)]
    public float rotationSpeed = 0f;
    // Start is called before the first frame update
    void Start()
    {
        if (parent == null)
        {
            parent = this.gameObject;
        }
        StartCoroutine("Fire");
    }
    public void Update()
    {
        parent.transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
    }
    // Update is called once per frame
    IEnumerator Fire()
    {
        yield return new WaitForSeconds(FireDelay);
        float angleStep = (maxAngle - minAngle) / emmitersCount;
        float currentAngle = angle;
        for (int i = 0; i < emmitersCount; i++)
        {
            float bulletDirectionX = transform.position.x + Mathf.Sin((currentAngle * Mathf.PI) / 180f);
            float bulletDirectionZ = transform.position.z + Mathf.Cos((currentAngle * Mathf.PI) / 180f);
            float shiftedPositionX = bulletDirectionX + shift;
            float shiftedPositionZ = bulletDirectionZ + shift;

            Vector3 bulletMoveVector = new Vector3(shiftedPositionX, 1, shiftedPositionZ);
            Vector3 bulletDirection = (bulletMoveVector - transform.position).normalized;

            GameObject test = Instantiate(bullet, bulletDirection, Quaternion.identity, parent.transform);
            test.GetComponent<Renderer>().material.SetColor("_EmissionColor", bulletColor);
            test.GetComponent<Rigidbody>().velocity = new Vector3(BulletSpeed * bulletDirectionX, 0, BulletSpeed * bulletDirectionZ);

            currentAngle += angleStep;
        }
        StartCoroutine("Fire");
    }

    private void OnDestroy()
    {
        StopCoroutine("Fire");
    }
}
