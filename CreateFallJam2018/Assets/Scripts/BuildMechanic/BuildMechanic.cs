using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildMechanic : MonoBehaviour
{
	public GameObject wallPrefab;
	public float yPosOffset = 1.5f;
	
	public void BuildWall()
	{
		//Checks for right mouse button click and if true it builds the prefab
		if (Input.GetMouseButtonDown(1))
		{
			Vector3 position = new Vector3(transform.position.x, transform.position.y - yPosOffset, transform.position.z);
			Instantiate(wallPrefab, position + transform.forward * 2f, transform.rotation);
		}
	}
}
