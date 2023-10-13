using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerConteroller : MonoBehaviour
{
    public LineRenderer lineRenderer;

    public GameObject bullet;
    public float thrust = 1f;
    public float revSpeed = 1f;
    public float maxLaserDist = 10;
    private Rigidbody2D rb;
    private float Laserdist;

    private float zoomAcsr = 0;
    private float timeToFire;

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
        var bulInst = Instantiate(bullet, transform.position, transform.rotation);
        bulInst.GetComponent<Rigidbody2D>().AddForce(transform.up  * 5000  * Time.deltaTime);
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
        
        
        
        if(Input.GetMouseButton(0) && Time.time > timeToFire + 1) {
                timeToFire = Time.time;
                Shoot();
            }
    }
    void Update(){
        //if (zoomAcsr !=0) zoomAcsr -= 0.1f;
        //if (Input.mouseScrollDelta.y !=0 && zoomAcsr < 2) zoomAcsr += Input.mouseScrollDelta.y;
        cam.fieldOfView += Input.mouseScrollDelta.y + zoomAcsr;
    }
}
