using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

    public float deathTime;
    private float lifeTime;
    public float speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        lifeTime += Time.deltaTime;
        if(lifeTime >= deathTime)
        {
            Destroy(this.gameObject);
        }
	}
}
