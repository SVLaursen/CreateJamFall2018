using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent (typeof (Rigidbody))]
public class PlayerController : MonoBehaviour {

	private Vector3 velocity;
	private Rigidbody rb;
    public GunController gun;
	public Animator animator;

    public List<Vector2> ammo;
    public List<float> bulletSpeed;
    public List<float> damage;
    public List<float> maxAmmo;
    public List<float> ammoCap;
	public float moveSpeed = 5f;

	private bool isMoving;

	private void Start () {
		rb = GetComponent<Rigidbody> ();
	}

	public void Move(Vector3 input) {
		Vector3 _velocity = input.normalized * moveSpeed;
		velocity = _velocity;
		isMoving = input != Vector3.zero;
	}

	public void LookAt(Vector3 lookPoint) {
		Vector3 heightCorrectedPoint = new Vector3 (lookPoint.x, transform.position.y, lookPoint.z);
		transform.LookAt (heightCorrectedPoint);
	}

    private void FixedUpdate() {
	    animator.SetBool("isMoving", isMoving);
		rb.MovePosition (rb.position + velocity * Time.fixedDeltaTime);
	}
}