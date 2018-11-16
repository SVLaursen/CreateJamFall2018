using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour, WeaponBehavior
{
    public bool isSemiAuto;
    public bool isFiring;
    public BulletController bullet;
    public float bulletSpeed;
    public float timeBetweenShots;
    public float shotCounter;
    public Transform firePoint;
    public float projectileDecay;
    public int maxAmmo;
    public int currentAmmo;
    public int ammoInGun;
    public int ammoCap;
    private bool hasShot;

    public void Reload()
    {
        if (currentAmmo > 0)
        {
            currentAmmo -= ammoCap - ammoInGun;
            ammoInGun = ammoCap;
        }
        else
        {
            //Not Implemented
        }
    }

    public void Shoot()
    {
        if (ammoInGun > 0)
        {
            if (isSemiAuto)
            {

                if (!hasShot)
                {
                    BulletController myBullet = Instantiate(bullet, firePoint.position, firePoint.rotation) as BulletController;
                    myBullet.deathTime = projectileDecay;
                    myBullet.speed = bulletSpeed;
                    hasShot = true;
                }
            }
            else
            {
                shotCounter -= Time.deltaTime;
                if (shotCounter <= 0f)
                {
                    shotCounter = timeBetweenShots;
                    BulletController myBullet = Instantiate(bullet, firePoint.position, firePoint.rotation) as BulletController;
                    myBullet.deathTime = projectileDecay;
                    myBullet.speed = bulletSpeed;
                }


            }

        }



    }

    public void StopShooting()
    {
        hasShot = false;
        shotCounter = 0f;
    }
    public void Special()
    {
        throw new System.NotImplementedException();
    }

    public void Upgrade()
    {
        throw new System.NotImplementedException();
    }



    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
