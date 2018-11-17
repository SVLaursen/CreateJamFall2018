using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    // Item spawning
    public GameObject[] gunPrefabs;
    private GameObject gunPrefab;
    public float spawnCooldown = 3;
    private float timeUntilSpawn = 0;
    private float timeUntilDespawn = 0;
    public GameObject plane;
    private float nextActionTime = 0.0f;
    public float powerUpLifetime;
    private List<GameObject> powerUpsObjects;
    private static List<float> timeSinceSpawned;

    // HUD Text Objects
    public GameObject waveShit;
    public static Text waveText;
    public GameObject topLeft;
    public static Text scoreText;

    private static string waveInitText;
    private static string scoreInitText;

    private static int health;
    private static int wave;
    private static int score;


    // Use this for initialization
    void Start()
    {
        health = 100;
        wave = 0;
        score = 0;
        waveText = waveShit.GetComponent<Text>();
        waveInitText = waveText.text;
        scoreText = topLeft.GetComponent<Text>();
        scoreInitText = scoreText.text;
        powerUpsObjects = new List<GameObject>();
        timeSinceSpawned = new List<float>();
        powerUpLifetime = 10.0f;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Helloooooo");
        if (Input.GetKey(KeyCode.K))
        {
            addToWave(1);
        }

        if (Input.GetKey(KeyCode.W))
        {
            addToScore(1);
        }

        if (Input.GetKey(KeyCode.Q))
        {
            spawnPowerUp();
            Debug.Log("Spawned by key");
        }

        //waveText.text = waveText.text.Substring(0, waveText.text.Length-wave.ToString().Length) + wave.ToString();
        waveText.text = waveInitText + wave.ToString();
        scoreText.text = scoreInitText + score.ToString();


        timeUntilSpawn -= Time.deltaTime;
        if (timeUntilSpawn <= 0)
        {
            spawnPowerUp();
            // Reset for next spawn
            timeUntilSpawn = spawnCooldown;
            Debug.Log("Spawned powerup by time...");
        }

        for (int i = 0; i < timeSinceSpawned.Count; i++)
        {
            timeSinceSpawned[i] -= Time.deltaTime;
            //Debug.Log(timeSinceSpawned[i]);
            if (timeSinceSpawned[i] <= 0)
            {
                Debug.Log("Despawned powerup...");
                timeSinceSpawned.RemoveAt(i);

                GameObject objectAtIndex = powerUpsObjects[i];
                powerUpsObjects.RemoveAt(i);
                Destroy(objectAtIndex);
            }
        
        }
    }

    public void updateScore(int newscore)
    {
        score = newscore;
    }

    public void addToScore(int scoreMod)
    {
        score += scoreMod;
    }


    public void addToWave(int waveMod)
    {
        wave += waveMod;
    }

    public void setWave(int newWave)
    {
        wave = newWave;
    }

    public void takeDamage(int damageMod)
    {
        health += damageMod;
    }

    public int getCurrentWave()
    {
        return wave;
    }

    public int getCurrentHP()
    {
        return health;
    }

    public int getCurrentScore()
    {
        return score;
    }

    private void spawnPowerUp()
    {
        gunPrefab = gunPrefabs[Random.Range(0, gunPrefabs.Length)];
        Vector3 planeSize = plane.GetComponent<Collider>().bounds.size;
        Vector3 planePosition = plane.transform.position;
        Vector3 newPos = new Vector3(Random.Range(planePosition.x-planeSize.x/2, planePosition.x+planeSize.x/2), planeSize.y, Random.Range(planePosition.z - planeSize.z / 2, planePosition.z + planeSize.z / 2));
        GameObject swag = Instantiate(gunPrefab, newPos, Quaternion.identity) as GameObject;
        powerUpsObjects.Add(swag);
        timeSinceSpawned.Add(powerUpLifetime);
    }
}
