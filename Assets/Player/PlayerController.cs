using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PlayerConteroller : MonoBehaviour
{
    public LineRenderer lineRenderer;

    public GameObject bullet;
    public float thrust = 1f;
    public float revSpeed = 1f;
    public float maxLaserDist = 10;


    private Rigidbody2D rb;
    private Vector3 mousePos;
    private float zoomAcsr = 0;
    private float timeToFire;
    private bool canFire;

    public Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        rb.drag = 0.4f;
        lineRenderer.positionCount = 2;
    }

    void Shoot() 
    {

        var bulInst = Instantiate(bullet, transform.position,  transform.rotation);
        Rigidbody2D bulRb = bulInst.GetComponent<Rigidbody2D>();
        Physics2D.IgnoreCollision(bulInst.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        bulRb.AddForce(bulInst.transform.up  * 5000);
    }

    


    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetAxis("Vertical") != 0) {
            rb.AddForce(transform.up * Input.GetAxis("Vertical") * (thrust + rb.totalForce.magnitude));
            
        } 
        if (Input.GetAxis("Horizontal") != 0) {
            rb.freezeRotation = false;
            rb.MoveRotation(rb.rotation - revSpeed * Input.GetAxis("Horizontal"));
        } else {
            rb.freezeRotation = true;
        }
        
        
        
        
    }
    void Update(){
        
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        cam.fieldOfView += Input.mouseScrollDelta.y + zoomAcsr;

        if (Input.GetMouseButton(0) && Time.time > timeToFire + Random.Range(0.4f, 1))
        {
            timeToFire = Time.time;
            Shoot();
        }
    }
}
