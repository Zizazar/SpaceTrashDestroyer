using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidHandler : MonoBehaviour
{

    [SerializeField] private Sprite[] sprites;
    [SerializeField] public float size;
    [SerializeField] public float durability;

    [SerializeField] private GameObject drop;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        size = Random.Range(3.0f, 15.0f);
        rb.mass = size * 50;
        transform.localScale = new Vector3(size, size, 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
