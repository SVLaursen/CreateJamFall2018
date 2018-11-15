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

	public float turnSpeed = 2f;
	public float mouseTurnSpeed = 4f;

	private float oldTurnSpeed;
	private float counter;
	
	[Header("Dialog Camera Settings")]
	public Vector3 dialogOffset = new Vector3(0, 2.5f, -2.5f);
	public float zoomSpeed = 2.5f;

	[HideInInspector] public bool playerActive;

	[Header("Camera FX")] 
	public CameraShake.Properties shakerProperties;

	private void Start()
	{
		playerActive = true;
		transform.position = offset;
		oldTurnSpeed = turnSpeed;
		npcTarget = target;
	}

	private void LateUpdate()
    {   
	    if (playerActive)
	    {
		    if (Input.GetAxisRaw("Mouse X") != 0 && Input.GetMouseButton(2))
		    {
			    offset = Quaternion.AngleAxis(Input.GetAxisRaw("Mouse X") * mouseTurnSpeed, Vector3.up) * offset; //Mouse input
		    }
		    else
		    {
			    const float maxTurnSpeed = 6f;
			    offset = Quaternion.AngleAxis(Input.GetAxisRaw("Rotate") * turnSpeed, Vector3.up) * offset; //Keystroke input

			    if (Input.GetAxisRaw("Rotate") != 0 && turnSpeed <= maxTurnSpeed)
			    {
				    counter += 2 * Time.deltaTime;

				    if (counter > 3)
				    {
					    turnSpeed += 2 * Time.deltaTime;
				    }
			   
			    }
			    else if (Input.GetAxisRaw("Rotate") == 0)
			    {
				    turnSpeed = oldTurnSpeed;
				    counter = 0;
			    }
		    }
		    
		    transform.position = target.position + offset;
		    transform.LookAt(target.position);
	    }
	    else
	    {
		    var step = zoomSpeed * 2 * Time.deltaTime;
		    transform.LookAt(npcTarget.position);
		    transform.position = Vector3.MoveTowards(transform.position, npcTarget.position + dialogOffset, step);
	    }
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
