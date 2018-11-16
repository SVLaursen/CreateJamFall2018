using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Rigidbody))]
public class PlayerController : MonoBehaviour {

	private Vector3 velocity;
	private Rigidbody rb;

	public float moveSpeed = 5f;

	private void Start () {
		rb = GetComponent<Rigidbody> ();
	}

	public void Move(Vector3 input) {
		Vector3 _velocity = input.normalized * moveSpeed;
		velocity = _velocity;
	}

	public void LookAt(Vector3 lookPoint) {
		Vector3 heightCorrectedPoint = new Vector3 (lookPoint.x, transform.position.y, lookPoint.z);
		transform.LookAt (heightCorrectedPoint);
	}

	private void FixedUpdate() {
		rb.MovePosition (rb.position + velocity * Time.fixedDeltaTime);
	}
}