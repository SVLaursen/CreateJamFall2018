using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour {

    public AudioController audioController;

    NavMeshAgent agent;
    GameObject target;
    SphereCollider c;

    private List<Collider> colliders = new List<Collider>();

    public GameObject floatingTextPrefab;

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
        audioController = FindObjectOfType<AudioController>();
	}
	
	// Update is called once per frame
	void Update () { 
        if (colliders.Count != 0) {
            timeLeft -= Time.deltaTime;
            if (timeLeft < 0)
            {
                if (colliders[0] != null)
                {
                    Attack(colliders[0].gameObject, ad);
                    timeLeft = attackSpeed;
                }
                
            }
            
        }
        
        if (target)
        {
            updateTargetPos(target); // Update the target -> keep on player if he moves
        }


        if (hp <= 0)
        {
            FindObjectOfType<HUD>().score += 10;
            Destroy(gameObject);
        }
	}

    void showFloatingText(int dmg)
    {
        GameObject text = Instantiate(floatingTextPrefab, transform.position, Quaternion.identity, transform);
        text.GetComponent<TextMesh>().text = hp.ToString();
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
        ag = getModifiedParam(level, ag, 4);
        ad = getModifiedParam(level, ad, 2);
        hp = getModifiedParam(level, hp, 8);
    }

    private float getModifiedParam(int level, float param, float divisor) // Where stats are calculated based on level
    {
        return (param + (level * level / divisor));
    }

    public void Damage(float amount)
    {
        audioController.playHit();
        if (floatingTextPrefab)
        {
            showFloatingText(amount);
        }

        FindObjectOfType<HUD>().score += 5;
        hp -= amount;
        
    }

    public void showFloatingText(float amount)
    {
        amount = (int)amount;
        var b = Instantiate(floatingTextPrefab, transform.position, Quaternion.identity);
        b.GetComponent<TextMesh>().text = amount.ToString();
    }

    private void Attack(GameObject target, float amount)
    {
        if (target.tag == "PLAYER")
        {
            PlayerStats p = target.GetComponent<PlayerStats>();
            p.Damage(amount);
        }
        if (target.tag == "PILLOWWALL")
        {
            PillowWall p = target.GetComponent<PillowWall>();
            p.DamageWall();
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

        if (other.gameObject.tag == "PILLOWWALL")
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
