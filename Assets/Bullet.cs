using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float lifeTime = 0.5f;
    
    private float spawnTime;

    void Start() {
        spawnTime = Time.time;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Asteroid")
        {
            collision.rigidbody.AddForceAtPosition(transform.up, transform.position);
            
            
            collision.gameObject.SendMessage("ApplyDamage", Random.Range(4.2f, 5));
            Destroy(gameObject);
            
        }
    }
    void Update() {
        if (Time.time > spawnTime + lifeTime) {
            Destroy(gameObject);
        }
    }
}
