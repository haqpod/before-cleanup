using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour
{
    [SerializeField]
    private Transform barrelTip;

    [SerializeField]
    private GameObject bullet;

    public float fireRate = 15f;

    private float nextTimeToFire = 0f;

    private Vector2 lookDirection;
    private float lookAngle;

    public Rigidbody2D rb;

    void Update()
    {
        lookDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        lookAngle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, lookAngle - 90f);

        if /*(Input.GetMouseButtonDown(0) && */(Time.time >= nextTimeToFire) 
        {
            nextTimeToFire = Time.time + 10f / fireRate;
            FireBullet();
        }
    }

    private void FireBullet()
    {
        GameObject firedBullet = Instantiate(bullet, barrelTip.position, barrelTip.rotation);
        firedBullet.GetComponent<Rigidbody2D>().velocity = barrelTip.up * 5f;
    }
}