using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioController : MonoBehaviour {

    public AudioSource[] sounds;
    public AudioSource hitSound;
    public AudioSource slingshotPull;
    public AudioSource catapultShoot;
    public AudioSource BGMusic;

    // Use this for initialization
    void Start () {
        sounds = GetComponents<AudioSource>();
        hitSound = sounds[0];
        slingshotPull = sounds[1];
        catapultShoot = sounds[2];
        BGMusic = sounds[3];

        playBGMusic();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void playHit()
    {
        hitSound.Play();
    }

    public void playCatapultPull()
    {
        slingshotPull.Play();
    }

    public void playCatapultShoot()
    {
        stopCatapultPull();
        catapultShoot.Play();
    }

    public void stopCatapultPull()
    {
        slingshotPull.Stop();
    }

    public void playBGMusic()
    {
        BGMusic.Play();
    }

    public void stopBGMusic()
    {
        BGMusic.Stop();
    }
}
