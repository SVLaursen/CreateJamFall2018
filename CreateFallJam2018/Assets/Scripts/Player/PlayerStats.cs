using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

    public float hp = 100;

    public GameObject HUDObject;
    private HUD hud;

	// Use this for initialization
	void Start () {
        hud = HUDObject.GetComponent<HUD>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void updateHudValues()
    {
        
    }

    public void Damage(float amount)
    {
        hp -= amount;
        Debug.Log(hp);
    }
}
