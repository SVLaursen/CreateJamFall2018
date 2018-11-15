using UnityEngine;

public class PlayerInput : MonoBehaviour
{
	[HideInInspector] public bool paused;
	
	private PlayerController _playerController;
    
	private void Awake ()
	{
		_playerController = GetComponent<PlayerController>();
	}
	
	private void Update ()
	{	
		if (!paused)
		{
			//Movement
			_playerController.Movement(new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")), Input.GetButton("Sprint"));
		
			//Interact
			_playerController.Interact(Input.GetButtonDown("Interact"));
		}
	}
}
