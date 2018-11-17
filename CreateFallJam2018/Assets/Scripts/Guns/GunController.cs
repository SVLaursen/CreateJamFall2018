using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunController : MonoBehaviour, WeaponBehavior
{
    public bool isSemiAuto;
    public bool isFiring;
    public List<BulletController> bullets;
    public PlayerController player;
    public float bulletSpeed;
    public float timeBetweenShots;
    private float shotCounter;
    public Transform firePoint;
    public float projectileDecay;
    public float maxAmmo;
    public float currentAmmo;
    public float ammoInGun;
    public float ammoCap;
    public bool hasShot;
    public float damage;
    public float reloadTime;
    private bool hasReloaded;
    public int _id;
    public float slingShotCharge;
    public float maxCharge;
    public Vector3 pointToFace { get; set; }
    private IEnumerator _reloadTime;

    private CameraShake camShake;
    public CameraShake.Properties shakerProperties;

    private void Awake()
    {
        camShake = FindObjectOfType<CameraShake>().GetComponent<CameraShake>();
    }
    
    public void Reload()
    {
        _reloadTime = WaitTime(reloadTime);
        StartCoroutine(_reloadTime);
        if (hasReloaded) StopCoroutine(_reloadTime);

    }
    private IEnumerator WaitTime(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        if (currentAmmo > 0)
        {
            currentAmmo -= ammoCap - ammoInGun;
            ammoInGun = ammoCap;

            hasReloaded = false;
        }
        else
        {
            //Not Implemented
        }
    }
    public void Shoot(int k)
    {
        switch (k)
        {
            case 0: //Slingshot
                if (slingShotCharge <= maxCharge)
                {
                    slingShotCharge += Time.deltaTime;
                }
                camShake.StartShake(shakerProperties);
                break;

            /*
             * case 1: //NerfGun
             
                if (ammoInGun > 0)
                {
                    if (isSemiAuto)
                    {

                        if (!hasShot)
                        {
                            BulletController myBullet = Instantiate(bullets[1], firePoint.position, firePoint.rotation) as BulletController;
                            myBullet.deathTime = projectileDecay;
                            myBullet.speed = bulletSpeed;
                            myBullet.damage = damage;
                            ammoInGun--;
                            hasShot = true;
                        }
                    }
                    else
                    {
                        shotCounter -= Time.deltaTime;
                        if (shotCounter <= 0f)
                        {
                            shotCounter = timeBetweenShots;
                            BulletController myBullet = Instantiate(bullets[1], firePoint.position, firePoint.rotation) as BulletController;
                            myBullet.deathTime = projectileDecay;
                            myBullet.speed = bulletSpeed;
                            myBullet.damage = damage;
                            ammoInGun--;
                            camShake.StartShake(shakerProperties[2]);
                        }
                    }
                }
                break;
*/
        }

    }

    public void StopShooting(int k)
    {
        switch (k)
        {
            case 0:
                if (hasShot == true)
                {
                    BulletController mySlingBullet = Instantiate(bullets[0], firePoint.position, firePoint.rotation) as BulletController;
                    mySlingBullet.deathTime = projectileDecay;
                    mySlingBullet.speed = bulletSpeed*slingShotCharge;
                    mySlingBullet.damage = damage * slingShotCharge;
                    hasShot = false;
                    slingShotCharge = 0f;
                }
                break;

            case 1:
                hasShot = false;
                shotCounter = 0f;
                break;

            case 2:
                hasShot = false;
                break;
        }
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
        onWeaponChange(0);
    } 
    
    public void onWeaponChange(int id)
    {
        _id = id;
        ammoCap = player.ammoCap[id];
        maxAmmo = player.maxAmmo[id];
        currentAmmo = player.ammo[id].x;
        ammoInGun = player.ammo[id].y;
        damage = player.damage[id];
        bulletSpeed = player.bulletSpeed[id];
        hasShot = false;

        if (id == 0) //Slingshot
        {
            isSemiAuto = true;
        }
        if (id == 1) //Nerfgun
        {
            isSemiAuto = false;
        }
        if (id == 2) //Launcher
        {
            isSemiAuto = true;
        }
    }
}
