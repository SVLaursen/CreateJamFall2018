using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gizmo : MonoBehaviour {

    /*
     * Created by Simon V. Laursen - 2018
     * 
     * This script is an in-editor gizmo visualizer with variables for
     * different visual styles.
     * 
     * Script is free to be used anyone and everyone.
     */

    [Header("Enable Gizmo?")]
	public bool enableActiveGizmo = true;
	public bool enablePassiveGizmo = true;

	[Header("Gizmo Style")]
    public bool wireframeSphere = true;
    public bool wireframeCube = false;

	[Header("Gizmo Size")]
    public float sphereSize = 1f;
    public Vector3 cubeSize = new Vector3(1, 1, 1);

	[Header("Gizmo Offset")]
	public Vector3 offset = new Vector3(0, 0, 0);

	[Header("Sphere Gizmo Colors")]
	public Color activeColorSphere = Color.red;
	public Color passiveColorSphere = Color.grey;

	[Header("Cube Gizmo Colors")]
	public Color activeColorCube = Color.red;
    public Color passiveColorCube = Color.grey;

	private void OnDrawGizmos()
	{
		if(enablePassiveGizmo)
		{         
			if(wireframeSphere)
			{
				Gizmos.color = passiveColorSphere;
				Gizmos.DrawWireSphere(transform.position + offset, sphereSize);
			}

			if(wireframeCube)
			{
				Gizmos.color = passiveColorCube;
				Gizmos.DrawWireCube(transform.position + offset, cubeSize);	
			}
		}
	}

	private void OnDrawGizmosSelected()
    {
		if(enableActiveGizmo)
		{         
			if (wireframeSphere)
            {
				Gizmos.color = activeColorSphere;
				Gizmos.DrawWireSphere(transform.position + offset, sphereSize);
            }
            
			if (wireframeCube)
            {
				Gizmos.color = activeColorCube;
				Gizmos.DrawWireCube(transform.position + offset, cubeSize);
            }
		}
    }
}
