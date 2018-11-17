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

    public int type = 0;

    public GameObject impact;

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
        }
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 t = new Vector3(0, 0, 1);
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
            if (type == 0)
            {
                collision.gameObject.GetComponent<Enemy>().Damage(damage);
                Destroy(gameObject);
            }
            if (type == 1)
            {

                Collider[] hitCollider = Physics.OverlapSphere(collision.transform.position, 20);
                Destroy(gameObject);
                foreach(Collider c in hitCollider)
                {
                    Enemy enemy = c.GetComponent<Enemy>();
                    if(enemy != null)
                    {
                        enemy.Damage(damage);
                    }
                    


                }
                
            }
            if (type == 2)
            {
                collision.gameObject.GetComponent<Enemy>().Damage(damage);
            }
            
        }
        if(collision.gameObject.tag == "PILLOWWALL")
        {
            Physics.IgnoreCollision(collision.collider, this.GetComponent<Collider>(), true);
        }
        if(collision.gameObject.tag == "PROJECTILE")
        {
            Physics.IgnoreCollision(collision.collider, this.GetComponent<Collider>(), true);
        }
    }
    public void Awake()
    {
        viewCam = FindObjectOfType<Camera>();
    }

}
