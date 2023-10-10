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
        for (int i=0; i < 10; i++) 
         {
              var pos = new Vector3(Random.Range(-150, 150), Random.Range(-150, 150), Random.Range(-150, 150));
              var chosenAsteroid = AsteroidPrefabs[Random.Range(0, AsteroidPrefabs.Length)];
              var asteroid = Instantiate(chosenAsteroid , pos, Quaternion.identity);

              // You can still manipulate asteroid afterwards like .AddComponent etc
         }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }
}
