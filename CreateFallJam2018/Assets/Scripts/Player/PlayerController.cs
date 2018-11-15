using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour {

	private CharacterController _controller;

	[Header("Speed Variables")]
	public float walkSpeed = 3f;
	public float runSpeed = 4.5f;
	public float speedSmoothTime = 0.1f;
	public float gravity = -12f;
	
	private float velocitySmoothSpeed;
	private float currentSpeed;
	private Vector3 velocity; 

	[Header("Turning Speed")]
	public float turnSpeed = 3f;
	public float runTurnSpeed = 1.5f;
	
	private void Start()
	{
		_controller = GetComponent<CharacterController>();
	}
	
	public void Movement(Vector2 input, bool sprint)
	{
		//Rotation
		var turnVelocity = 60f * ((sprint) ? runTurnSpeed : turnSpeed);
		transform.Rotate(0,input.x * turnVelocity * Time.deltaTime,0);
		
		//Movement
		var targetVelocity = ((sprint) ? runSpeed : walkSpeed) * input.y;
		currentSpeed = Mathf.SmoothDamp(currentSpeed, targetVelocity, ref velocitySmoothSpeed, speedSmoothTime);
		velocity = transform.forward * currentSpeed + Vector3.up * velocity.y;
		
		_controller.Move(velocity * Time.deltaTime);
		currentSpeed = new Vector2(_controller.velocity.x, _controller.velocity.z).magnitude;
		
		//Checks gravity
		velocity.y = ((_controller.isGrounded) ? 0 : velocity.y + Time.deltaTime * gravity);
	}
	
	public void Interact(bool interact)
	{
		if (!interact) return;
		
		
	}
}
