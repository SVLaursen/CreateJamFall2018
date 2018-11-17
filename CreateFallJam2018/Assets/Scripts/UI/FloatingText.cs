using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingText : MonoBehaviour {

    public float destroyTime = 3f;
    public Vector3 offset = new Vector3(0, 2, 0);

	// Use this for initialization
	void Start () {
        Destroy(gameObject, destroyTime);
        transform.localPosition += offset;
	}
	
	// Update is called once per frame

}
