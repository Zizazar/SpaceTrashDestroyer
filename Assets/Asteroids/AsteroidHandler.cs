using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AsteroidHandler : MonoBehaviour
{

    
    [SerializeField] private GameObject HealthBar;
    [SerializeField] public float size;
    [SerializeField] private GameObject DropShard;
    [SerializeField] private GameObject Explosion;

    [SerializeField] private AudioSource audio;
    [SerializeField] private AudioClip[] hurtClips;
    [SerializeField] private AudioClip destClip;
    
    public float durability;
    private Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {
        Explosion.SetActive(false);
        rb = GetComponent<Rigidbody2D>();
        size = Random.Range(3.0f, 15.0f);
        durability = size * Random.Range(1f, 5f);
        rb.mass = size * 50;
        transform.localScale = new Vector3(size, size, 1);

        HealthBar.GetComponent<HealthBar>().maxHealth = durability;
    }

    
    private void DropShards()
    {
        for(int i=0; i < size; i++)
        
        {
            //gameObject.enabled = false;
            Vector3 spawnPosition = new Vector2(transform.position.x, transform.position.y) + Random.insideUnitCircle.normalized * size/6;
            var shard = Instantiate(DropShard, spawnPosition, Quaternion.Euler(0.0f, 0.0f, Random.Range(0.0f, 360.0f)));
            Rigidbody2D shardRb = shard.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                float speed = Random.Range(0.3f, 2);
                Vector2 direction = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;

                shardRb.velocity = direction * speed;
            }
        }
    }

    private void DestroyObject()
     {
        
        Destroy(gameObject);
     }

    public void ApplyDamage(float damage)
    {
        if (durability > 1)
        {
            durability -= damage;
            HealthBar.GetComponent<HealthBar>().SetHealth(durability);

            audio.clip = hurtClips[Random.Range(0, hurtClips.Length-1)];
            audio.Play();
        } else
        {
            durability = 0;
            Explosion.SetActive(true);
            GetComponent<SpriteRenderer>().enabled = false;
            DropShards();
            audio.volume = size/10;
            audio.clip = destClip;
            audio.Play();
            Invoke("DestroyObject", 0.9f);
        }
        
    }

    void FixedUpdate()
    {
        HealthBar.transform.rotation = Camera.main.transform.rotation;
    }
}
