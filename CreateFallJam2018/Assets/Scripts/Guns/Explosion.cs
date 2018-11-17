using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {

    private List<Collider> colliders;
    public float damage;

    bool hasExploded = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (hasExploded == false)
        {
            dealDamageInArea(damage);
            hasExploded = true;
        } else
        {
            Destroy(gameObject);
        }
	}

    void dealDamageInArea(float damage)
    {
        if (colliders.Count != 0)
        {
            for (int i = 0; i < colliders.Count; i++)
            {
                if (colliders[i].gameObject.tag == "ENEMY")
                {
                    Enemy e = colliders[i].gameObject.GetComponent<Enemy>();
                    e.Damage(damage);
                }
                if (colliders[i].gameObject.tag == "PLAYER")
                {
                    PlayerStats p = colliders[i].gameObject.GetComponent<PlayerStats>();
                    p.Damage(damage);
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        colliders.Add(other);
    }

    private void OnTriggerExit(Collider other)
    {
        colliders.Remove(other);
    }
}
