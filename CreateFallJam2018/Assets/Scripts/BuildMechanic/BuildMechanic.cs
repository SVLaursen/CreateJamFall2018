using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class BuildMechanic : MonoBehaviour
{
	public GameObject wallPrefab;
	public float yPosOffset = 1.5f;
	public int buildCost = 20;
	public float delayTime = 2f;

	private HUD hud;
	private bool canBuild = true;
	private IEnumerator _delay;

	private void Awake()
	{
		hud = FindObjectOfType<HUD>().GetComponent<HUD>();
	}
	
	public void BuildWall()
	{
		_delay = WaitTime(delayTime);
		
		if (!canBuild) StartCoroutine(WaitTime(delayTime));
		if(canBuild) StopCoroutine(_delay);
		
		var cost = CalcPrice();
		
		//Checks for right mouse button click and if true it builds the prefab
		if (Input.GetMouseButtonDown(1) && hud.getScore() >= cost && canBuild)
		{
			hud.detractScore(buildCost);
			Vector3 position = new Vector3(transform.position.x, transform.position.y - yPosOffset, transform.position.z);
			Instantiate(wallPrefab, position + transform.forward * 2f, transform.rotation);
			canBuild = false;
		}
	}

	private IEnumerator WaitTime(float waitTime)
	{
		yield return new WaitForSeconds(waitTime);
		canBuild = true;
	}

	private int CalcPrice()
	{
		var walls = FindObjectsOfType<PillowWall>();
		var wallAmount = 0;

		if (walls.Length <= 0) return buildCost;

		for (var i = 0; i < walls.Length; i++)
		{
			wallAmount = i;
		}

		var newAmount = buildCost * wallAmount;
		
		return newAmount;
	}
}
