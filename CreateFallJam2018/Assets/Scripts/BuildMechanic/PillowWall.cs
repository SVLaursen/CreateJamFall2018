using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillowWall : MonoBehaviour
{
	public int wallHealth = 100;
	public int dmgPerHit = 5;

	public void DamageWall()
	{
		if (wallHealth > 0)
		{
			wallHealth -= dmgPerHit;
		}
		else
		{
			Destroy(gameObject);
		}
	}
}
