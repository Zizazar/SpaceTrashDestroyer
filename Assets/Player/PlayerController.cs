using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerConteroller : MonoBehaviour
{
    public float thrust = 1f;
    public float revSpeed = 1f;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        rb.drag = 2;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetAxis("Vertical") != 0) {
            rb.AddForce(transform.up * Input.GetAxis("Vertical") * thrust);
        } 
        if (Input.GetAxis("Horizontal") != 0) {
            rb.MoveRotation(rb.rotation + revSpeed * Input.GetAxis("Horizontal"));
        }
        
    }
}
