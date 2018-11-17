using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour {

    NavMeshAgent agent;
    GameObject target;
    SphereCollider c;

    private List<Collider> colliders = new List<Collider>();

    public int level;

    public float hp = 100;
    public float ad = 1;
    public float ag = 1;

    public float attackSpeed;
    private float timeLeft;

	// Use this for initialization
	void Start () {
        agent = GetComponent<NavMeshAgent>();
        c = GetComponent<SphereCollider>();
	}
	
	// Update is called once per frame
	void Update () { 
        if (colliders.Count != 0) {
            timeLeft -= Time.deltaTime;
            if (timeLeft < 0)
            {
                Attack(colliders[0].gameObject, ad);
                timeLeft = attackSpeed;
            }
            
        }
        
        if (target)
        {
            updateTargetPos(target); // Update the target -> keep on player if he moves
        }


        if (hp <= 0)
        {
            Destroy(gameObject);
        }
	}

    public void setTarget(GameObject target)
    {
        this.target = target;
    }

    void updateTargetPos(GameObject target) // Update navAgent
    {
        agent.SetDestination(target.transform.position);
    }

    public void setLevel(int level) // Set the level of an enemy
    {
        this.level = level;
        ag = getModifiedParam(level, ag);
        ad = getModifiedParam(level, ad);
        hp = getModifiedParam(level, hp);
    }

    private float getModifiedParam(int level, float param) // Where stats are calculated based on level
    {
        return (param + (level * level / 2));
    }

    public void Damage(float amount)
    {
        this.hp -= amount;
    }

    private void Attack(GameObject target, float amount)
    {
        if (target.tag == "PLAYER")
        {
            PlayerStats p = target.GetComponent<PlayerStats>();
            p.Damage(amount);
        }
        if (target.tag == "")
        {

        }
    }

    public List<Collider> getColliders() // Get the colliders touching the enemy
    {
        return colliders;
    }

    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PLAYER")
        {
            timeLeft = attackSpeed;
            if (!colliders.Contains(other))
            {
                colliders.Add(other);
            }
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        colliders.Remove(other);
    }

}
