using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstShardHandler : MonoBehaviour
{
    
    [SerializeField] private SpriteRenderer sprite;
    public Sprite[] sprites;
    private bool animInv = false;

    // Start is called before the first frame update
    void Start()
    {
        sprite.sprite = sprites[Random.Range(0, sprites.Length-1)];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
