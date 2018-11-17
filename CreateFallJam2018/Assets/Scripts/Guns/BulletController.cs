using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

    public float deathTime;
    private float lifeTime;
    public float speed;
    public float damage;
    private Camera viewCam;
    private Vector3 pointToFace;
    // Use this for initialization
    void Start () {
        Ray cameraRay = viewCam.ScreenPointToRay(Input.mousePosition);
        Vector3 height = new Vector3(0, gameObject.transform.position.y, 0);
        Plane groundPlane = new Plane(Vector3.up, height);
        float rayLenght;
        if (groundPlane.Raycast(cameraRay, out rayLenght))
        {
            pointToFace = cameraRay.GetPoint(rayLenght);
            transform.LookAt(pointToFace);
            Debug.DrawLine(gameObject.transform.position, pointToFace, Color.blue);
        }
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 t = new Vector3(0, 0, 1);
        Debug.DrawLine(this.transform.position, this.transform.forward*40, Color.red);
        transform.Translate(t * speed * Time.deltaTime);
        lifeTime += Time.deltaTime;
        if(lifeTime >= deathTime)
        {
            Destroy(this.gameObject);
        }
      
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "ENEMY")
        {
            collision.gameObject.GetComponent<Enemy>().Damage(damage);
            Destroy(gameObject);
            return;
        }
       // Destroy(gameObject);
    }
    public void Awake()
    {
        viewCam = FindObjectOfType<Camera>();
    }

}
