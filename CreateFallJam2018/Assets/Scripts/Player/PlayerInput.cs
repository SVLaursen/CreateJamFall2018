using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    // Audio
    public AudioController audioController;

    [HideInInspector] public bool paused;
    [HideInInspector] public bool chargeSound;
	
	private PlayerController _playerController;
	private Camera _viewCamera;
	private BuildMechanic _buildMechanic;
    public Vector3 point; //??????
	private void Awake ()
	{
		_playerController = GetComponent<PlayerController>();
		_viewCamera = FindObjectOfType<Camera>();
		_buildMechanic = FindObjectOfType<BuildMechanic>();
        audioController = FindObjectOfType<AudioController>();
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
				point = ray.GetPoint(rayDistance);
				//Debug.DrawLine(ray.origin,point,Color.red);
				_playerController.LookAt(point);
			}
            if (Input.GetMouseButtonUp(0))
            {
                _playerController.gun.hasShot = true;
                // Mouse released
                switch (_playerController.gun.id)
                {
                    case 0:
                        audioController.playCatapultShoot();
                        break;

                }
            }
            if (Input.GetMouseButton(0))
            {
                if (chargeSound == false)
                {
                    chargeSound = true;
                    // Mouse released
                    switch (_playerController.gun.id)
                    {
                        case 0:
                            audioController.playCatapultPull();
                            break;

                    }
                }
                _playerController.gun.Shoot(_playerController.gun.id);
            }
            else if (!Input.GetMouseButton(0))
            {
                chargeSound = false;
                _playerController.gun.StopShooting(_playerController.gun.id);
            }
            if(Input.GetKeyDown(KeyCode.R))
            {
                _playerController.gun.Reload();
            }
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                _playerController.gun.onWeaponChange(0);
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                _playerController.gun.onWeaponChange(1);
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                _playerController.gun.onWeaponChange(2);
            }
            
			//Build Mechanic
			if(Input.GetButton("Build")) _buildMechanic.BuildWall();
		}
	}
}
