using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour {

    public bool isFiring;
    public BulletController bullet;
    public float bulletSpeed;
    public float timeBetweenShots;
    public float shotCounter;
    public Transform firePoint;



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (isFiring)
        {
            shotCounter -= Time.deltaTime;
            if(shotCounter <= 0f)
            {
                shotCounter = timeBetweenShots;
                BulletController myBullet = Instantiate(bullet, firePoint.position, firePoint.rotation) as BulletController;
                myBullet.speed = bulletSpeed;
            }
        }
        else
        {
            shotCounter = 0f;
        }

        if (Input.GetMouseButtonDown(0))
        {
            isFiring = true;
        }
        else
        {
            isFiring = false;
        }
	}
}
