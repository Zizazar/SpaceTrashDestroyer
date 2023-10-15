using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidHandler : MonoBehaviour
{

    [SerializeField] private Sprite[] sprites;
    [SerializeField] public float size;
    

    public float durability;
    private Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        size = Random.Range(3.0f, 15.0f);
        durability = size * Random.Range(1f, 5f);
        rb.mass = size * 50;
        transform.localScale = new Vector3(size, size, 1);
    }

    public void ApplyDamage(float damage)
    {
        if (durability > 1)
        {
            durability -= damage;
            Debug.Log(durability);
        } else
        {
            durability = 0;
            Destroy(gameObject);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
