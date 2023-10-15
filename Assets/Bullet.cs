using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Asteroid")
        {
            collision.rigidbody.AddForceAtPosition(transform.up, transform.position);
            Debug.Log(collision.transform.position);
            Destroy(gameObject);
        }
    }
}
