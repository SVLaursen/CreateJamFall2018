using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillowWall : MonoBehaviour
{
	public int wallHealth = 100;
	public int dmgPerHit = 5;

    public GameObject floatingTextPrefab;

    public void DamageWall()
	{
		if (wallHealth > 0)
		{
            showFloatingText(dmgPerHit);
			wallHealth -= dmgPerHit;
		}
		else
		{
			Destroy(gameObject);
		}
	}

    public void showFloatingText(float amount)
    {
        amount = (int)amount;
        var b = Instantiate(floatingTextPrefab, transform.position, Quaternion.identity);
        b.GetComponent<TextMesh>().text = amount.ToString();
    }

}
