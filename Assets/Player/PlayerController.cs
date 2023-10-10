using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerConteroller : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public float thrust = 1f;
    public float revSpeed = 1f;
    public float maxLaserDist = 10;
    private Rigidbody2D rb;
    private float Laserdist;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        rb.drag = 0.4f;
        lineRenderer.positionCount = 2;
    }

    void Mine() 
    {
        if (Input.GetMouseButton(0)) // Проверяем нажатие на левую кнопку мыши
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 20));
            
            Vector2 direction = mousePosition - transform.position;

            RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, maxLaserDist);
            
            if(hit) {
                lineRenderer.SetPosition(1,hit.point);
                Debug.Log("Hit");
            } else {
                //if(maxLaserDist < Mathf.Abs(mousePosition.y - transform.position.y) || maxLaserDist < Mathf.Abs(mousePosition.x - transform.position.x)) Laserdist = maxLaserDist;
                lineRenderer.SetPosition(1,mousePosition);
                }

            lineRenderer.SetPosition(0,transform.position);
            
        } else {
            lineRenderer.SetPosition(1,transform.position);
            lineRenderer.SetPosition(0,transform.position);
        }
    }

    


    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetAxis("Vertical") != 0) {
            rb.AddForce(transform.up * Input.GetAxis("Vertical") * thrust);
        } 
        if (Input.GetAxis("Horizontal") != 0) {
            rb.MoveRotation(rb.rotation - revSpeed * Input.GetAxis("Horizontal"));
        }

        Mine();
    }
}
