using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

    public float hp = 100;

    public GameObject HUDObject;
    private HUD hud;

    bool hasChanged;

	// Use this for initialization
	void Start () {
        hud = HUDObject.GetComponent<HUD>();
        hasChanged = false;
	}
	
	// Update is called once per frame
	void Update () {
        updateHudValues();
	}

    void updateHudValues()
    {
        hud.setHP(hp);
        hasChanged = false;
    }

    public void Damage(float amount)
    {
        hp -= amount;
        hasChanged = true;
    }
}
