using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{

    [SerializeField]
    private GameObject[] AsteroidPrefabs;

    // Start is called before the first frame update
    void Start()
    {
        for (int i=0; i < 1000; i++) 
         {
              var pos = new Vector3(Random.Range(-500, 500), Random.Range(-500, 500), 0);
              var rot = Quaternion.Euler(0, 0, Random.Range(0, 360));
              var chosenAsteroid = AsteroidPrefabs[Random.Range(0, AsteroidPrefabs.Length)];
              var asteroid = Instantiate(chosenAsteroid , pos, rot);

              //asteroid.size = Random.Range(2.0f, 10.0f);
         }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }
}
