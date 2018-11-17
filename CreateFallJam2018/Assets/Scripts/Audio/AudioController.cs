using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioController : MonoBehaviour {

    public AudioSource[] sounds;
    public AudioSource hitSound;
    public AudioSource slingshotPull;
    public AudioSource catapultShoot;

    // Use this for initialization
    void Start () {
        sounds = GetComponents<AudioSource>();
        hitSound = sounds[0];
        slingshotPull = sounds[1];
        catapultShoot = sounds[2];
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
}
