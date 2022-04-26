using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullScript : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPullPrefab;
    public GameObject bulletPushPrefab;
    public float attackCooldown;
    public float bulletForce = 20f;

    void Update()
    {
        if (Input.GetButton("Fire1") && attackCooldown <= 0 /*&& PlayerHealth.instance.PlayerCurrentHealth > 0*/)
        {
            Shoot(bulletPullPrefab);
            //FindObjectOfType<AudioManager>().Play("PlayerPew");
            attackCooldown = 1;
        }
        else if (Input.GetButton("Fire2") && attackCooldown <= 0 /*&& PlayerHealth.instance.PlayerCurrentHealth > 0*/)
        {
            Shoot(bulletPushPrefab);
            //FindObjectOfType<AudioManager>().Play("PlayerPew");
            attackCooldown = 1;
        }
        attackCooldown -= (Time.deltaTime * 5);
    }
    void Shoot(GameObject bulletType)
    {
        GameObject bullet = Instantiate(bulletType, firePoint.position, firePoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.AddForce(firePoint.forward * bulletForce, ForceMode.Impulse);
    }
}
