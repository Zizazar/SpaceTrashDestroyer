using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstBackSpawner : MonoBehaviour
{
    public GameObject asteroidPrefab;
    public float spawnRate = 1f; 

    public Sprite[] sprites;

    private Camera mainCamera;
    private float maxSpawnYPos;

    void Start()
    {
        mainCamera = Camera.main;
        maxSpawnYPos = mainCamera.ScreenToWorldPoint(new Vector3(0, Screen.height, 0)).y;
        
        InvokeRepeating("SpawnAsteroid", spawnRate, spawnRate);
    }

   void SpawnAsteroid()
   {
       float randomYPos = Random.Range(-maxSpawnYPos, maxSpawnYPos);

       GameObject newAsteroid = Instantiate(asteroidPrefab, new Vector3(20f, randomYPos , 0), Quaternion.identity);

        float size = Random.Range(1.0f, 6.0f);
        newAsteroid.transform.localScale = new Vector3(size, size, 0);
        newAsteroid.transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 360));
        newAsteroid.GetComponent<SpriteRenderer>().sprite = sprites[Random.Range(0, sprites.Length)];
       Rigidbody2D asteroidRb = newAsteroid.GetComponent<Rigidbody2D>();

       
       asteroidRb.velocity = new Vector2(-5f, 0);
       
       Destroy(newAsteroid, mainCamera.orthographicSize * 8 / Mathf.Abs(asteroidRb.velocity.x));
   
}
}
