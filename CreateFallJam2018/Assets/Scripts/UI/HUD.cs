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
    private List<float> timeSinceSpawned;

    // HUD Text Objects
    public Text waveText;
    public Text scoreText;
    public Slider hpSlider;

    //public static HUD instance;
    [Header("Player Shizzle")]
    public int health;
    public int wave;
    public int score;
    
    //Game Over Screen
    public GameObject gameOverCanvas;

    // Use this for initialization
    private void Start()
    {
        powerUpsObjects = new List<GameObject>();
        timeSinceSpawned = new List<float>();
        powerUpLifetime = 10.0f;
        gameOverCanvas.SetActive(false);
    }

    // Update is called once per frame
    private void Update()
    {
        if (FindObjectOfType<PlayerStats>().GetComponent<PlayerStats>().hp <= 0) GameOver();
        
        //waveText.text = waveText.text.Substring(0, waveText.text.Length-wave.ToString().Length) + wave.ToString();
        waveText.text = "Wave: " + wave;
        scoreText.text = "Score: " + score;
        hpSlider.value = (float) FindObjectOfType<PlayerStats>().hp / 100;

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

    public void detractScore(int detract)
    {
        score -= detract;
    }

    public int getScore()
    {
        return score;
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

    public void setHP(float inputHealth)
    {
        health = (int)inputHealth;
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

    public void spawnPowerUp()
    {
        if (gunPrefab)
        {
            gunPrefab = gunPrefabs[Random.Range(0, gunPrefabs.Length)];
            Vector3 planeSize = plane.GetComponent<Collider>().bounds.size;
            Vector3 planePosition = plane.transform.position;
            Vector3 newPos = new Vector3(Random.Range(planePosition.x - planeSize.x / 2, planePosition.x + planeSize.x / 2), planeSize.y, Random.Range(planePosition.z - planeSize.z / 2, planePosition.z + planeSize.z / 2));
            GameObject swag = Instantiate(gunPrefab, newPos, Quaternion.identity) as GameObject;
            powerUpsObjects.Add(swag);
            timeSinceSpawned.Add(powerUpLifetime);
        }
        
    }

    public void deletePowerUp(GameObject inputPowerUp)
    {

        for (int i = 0; i < powerUpsObjects.Count; i++)
        {
            if (inputPowerUp.Equals(powerUpsObjects[i])) {
                GameObject toDestroy = powerUpsObjects[i];
                powerUpsObjects.RemoveAt(i);
                Destroy(toDestroy);
            }
        }
    }

    public void GameOver()
    {
        FindObjectOfType<PlayerInput>().GetComponent<PlayerInput>().paused = true;
        gameOverCanvas.SetActive(true);
    }
}
