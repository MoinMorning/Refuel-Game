using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;

/*Defines behavior of shooting*/
public class Shooting : MonoBehaviour
{
    public float bulletForce = 20f;
    private float fireRate = 0.5f;

    private float nextShot = 0.0f;
    public Camera cam;
    [SerializeField]
    public Transform firePoint;
    [SerializeField]
    public GameObject bulletPrefab;
    GameObject bullet;

    void Update() 
    {
        // Shoot with specific firerate
        if(Input.GetButton("Fire1") && Time.time > nextShot) {
            nextShot = (float) Time.time + fireRate / 2;
            Shoot();
        }
    }

    /*Play audio on shot, add impulse to the shot*/
    void Shoot()
    {  
        FindObjectOfType<AudioManager>().Play("GunShot");
        bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }

    public void changeFireRate(float factor) {
        this.fireRate = fireRate - fireRate * factor;
    }
}
