using UnityEngine;

public class PlayerInput : MonoBehaviour
{
	[HideInInspector] public bool paused;
	
	private PlayerController _playerController;
	private Camera _viewCamera;
    
	private void Awake ()
	{
		_playerController = GetComponent<PlayerController>();
		_viewCamera = FindObjectOfType<Camera>();
	}
	
	private void Update ()
	{	
		if (!paused)
		{
			//Movement
			_playerController.Move(new Vector3(-Input.GetAxisRaw("Vertical"), 0, Input.GetAxisRaw("Horizontal")));
			
			// Look input
			Ray ray = _viewCamera.ScreenPointToRay (Input.mousePosition);
			Plane groundPlane = new Plane (Vector3.up, Vector3.up);
			float rayDistance;

			if (groundPlane.Raycast(ray,out rayDistance)) {
				Vector3 point = ray.GetPoint(rayDistance);
				//Debug.DrawLine(ray.origin,point,Color.red);
				_playerController.LookAt(point);
			}
            if (Input.GetMouseButton(0))
            {
                _playerController.gun.Shoot();
            }
            else if (!Input.GetMouseButton(0))
            {
                _playerController.gun.StopShooting();
            }

		}
	}
}
