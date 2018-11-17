using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingText : MonoBehaviour
{

    float destroyTime = 3f;
    // Use this for initialization
    void Start()
    {
        Destroy(gameObject, destroyTime);
    }

    private void Update()
    {
        transform.LookAt(GameObject.FindGameObjectWithTag("MainCamera").transform);
    }
}
