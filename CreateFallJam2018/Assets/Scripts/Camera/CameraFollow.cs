using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	[Header("Camera Target")]
	public Transform target;
	[HideInInspector] public Transform npcTarget;
    
	[Header("Camera Settings")]
    public Vector3 offset = new Vector3(0, 0, -1);

	private float counter;
	

	[Header("Camera FX")] 
	public CameraShake.Properties shakerProperties;

	private void Start()
	{
		transform.position = offset;
		npcTarget = target;
	}

	private void LateUpdate()
    { 
	    transform.position = target.position + offset;
	    transform.LookAt(target.position);
    }

	public void StandardCameraShake()
	{
		FindObjectOfType<CameraShake>().StartShake(shakerProperties);
	}

	public void ShakeCamera(CameraShake.Properties shakeProperties)
	{
		FindObjectOfType<CameraShake>().StartShake(shakeProperties);
	}
}
