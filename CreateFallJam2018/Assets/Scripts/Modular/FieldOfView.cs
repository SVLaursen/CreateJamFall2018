using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FieldOfView : MonoBehaviour {

	public float viewRadius;
	[Range(0,360)]
	public float viewAngle;
	[Range(0,30)]
	public float interactionRadius = 5f;

	public LayerMask targetMask;
	public LayerMask obstacleMask;

	[HideInInspector]
	public List<Transform> visibleTargets = new List<Transform>();

	[HideInInspector] public GameObject _target;

	void Start() {
		StartCoroutine ("FindTargetsWithDelay", .2f);
	}


	IEnumerator FindTargetsWithDelay(float delay) {
		while (true) {
			yield return new WaitForSeconds (delay);
			FindVisibleTargets ();
		}
	}

	private void FindVisibleTargets() {
		visibleTargets.Clear ();
		_target = null;
		Collider[] targetsInViewRadius = Physics.OverlapSphere (transform.position, viewRadius, targetMask);

		for (var i = 0; i < targetsInViewRadius.Length; i++) {
			var target = targetsInViewRadius [i].transform;
			var dirToTarget = (target.position - transform.position).normalized;

			if (!(Vector3.Angle(transform.forward, dirToTarget) < viewAngle / 2)) continue;
			var dstToTarget = Vector3.Distance (transform.position, target.position);

			if (!Physics.Raycast (transform.position, dirToTarget, dstToTarget, obstacleMask)) {
				visibleTargets.Add (target);
				_target = target.gameObject;
			}
		}
	}


	public Vector3 DirFromAngle(float angleInDegrees, bool angleIsGlobal) {
		if (!angleIsGlobal) {
			angleInDegrees += transform.eulerAngles.y;
		}
		return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad),0,Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
	}
}