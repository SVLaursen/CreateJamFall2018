using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public GameObject waveShit;
    public static Text waveText;
    public GameObject scoreShit;
    public static Text scoreText;

    private static string waveInitText;
    private static string scoreInitText;

    //public static HUD instance;
    [Header("Player Shizzle")]
    public int health;
    public int wave;
    public int score;

    // Use this for initialization
    private void Start()
    {
        waveText = waveShit.GetComponent<Text>();
        waveInitText = waveText.text;
        scoreText = scoreShit.GetComponent<Text>();
        scoreInitText = scoreText.text;
    }

    // Update is called once per frame
    private void Update()
    {
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
}
