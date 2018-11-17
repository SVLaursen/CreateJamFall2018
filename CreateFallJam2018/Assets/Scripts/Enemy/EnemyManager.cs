using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyManager : MonoBehaviour {

    public GameObject enemy;
    public GameObject player;

    public GameObject[] currentEnemies;

    public List<GameObject> spawners;

    public bool hasSpawned = true;

    public float waveDuration = 30;
    public float waveTimeLeft = 0;

    public float timeToChill = 20;
    public float chillTimeLeft;
    public bool isInWave = false;

    public float waveTimer = 3;
    public int spawnAmount = 0;
    public int waveCounter = 0;


    private float timeLeft;

	// Use this for initialization
	void Start () {
        isInWave = false;
        timeLeft = waveTimer;
	}
	
	// Update is called once per frame
	void Update () {

        if (isInWave)
        {
            waveTimeLeft -= Time.deltaTime;
            if (waveTimeLeft > 0)
            {
                Debug.Log(timeLeft);
                timeLeft -= Time.deltaTime;
                if (timeLeft < 0)
                {
                    hasSpawned = false;
                    timeLeft = waveTimer;

                }
                if (hasSpawned == false)
                {
                    waveCounter += 1;
                    SpawnWave(spawners, spawnAmount);
                    hasSpawned = true;
                }
            } else
            {
                isInWave = false;
                chillTimeLeft = timeToChill;
            }
            
        } else
        {
            chillTimeLeft -= Time.deltaTime;
            if (chillTimeLeft < 0)
            {
                isInWave = true;
                waveTimeLeft = waveDuration;
            }
        }

        
	}

    void SpawnWave(List<GameObject> spawners, int amount)
    {
        if (spawners.Count != 0)
        {
            for (int i = 0; i < spawners.Count; i++)
            {
                for (int j = 0; j < amount / spawners.Count; j++)
                {
                    SpawnOneEnemy(enemy, spawners[i].transform, player);
                }
            }
            for (int i = 0; i < amount; i++)
            {
                int currentSpawner = Random.Range(0, spawners.Count);
                SpawnOneEnemy(enemy, spawners[currentSpawner].transform, player);
            }
        }
        
    }

    void SpawnOneEnemy(GameObject enemy, Transform spawnPosition, GameObject target)
    {
        GameObject enemyClone = (GameObject)Instantiate(enemy, spawnPosition);
        Enemy e = enemyClone.GetComponent<Enemy>();
        e.setLevel(waveCounter);
        e.setTarget(target);
    }
}
