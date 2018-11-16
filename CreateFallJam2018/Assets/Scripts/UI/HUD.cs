using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public GameObject waveShit;
    public static Text waveText;
    public GameObject topLeft;
    public static Text scoreText;

    private static string waveInitText;
    private static string scoreInitText;

    //public static HUD instance;
    private static int health;
    private static int wave;
    private static int score;

    /*
    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
    }
    */

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
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Helloooooo");
        if (Input.GetButton("Jump"))
        {
            addToWave(1);
        }

        if (Input.GetKey(KeyCode.W))
        {
            addToScore(1);
        }

        //waveText.text = waveText.text.Substring(0, waveText.text.Length-wave.ToString().Length) + wave.ToString();
        waveText.text = waveInitText + wave.ToString();
        scoreText.text = scoreInitText + score.ToString();
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
}
