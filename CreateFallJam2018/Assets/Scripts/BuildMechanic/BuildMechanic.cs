using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildMechanic : MonoBehaviour
{
	public GameObject wallPrefab;
	
	public void BuildWall()
	{
		//Checks for right mouse button click and if true it builds the prefab
		if (Input.GetMouseButtonDown(1))
		{
			Instantiate(wallPrefab, transform.position + transform.forward * 2f, transform.rotation);
		}
	}
}
