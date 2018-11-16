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
			_playerController.Move(new Vector3(Input.GetAxisRaw("Horizontal"),0 , Input.GetAxisRaw("Vertical")));
		}
	}
}
