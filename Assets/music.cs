using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class music : MonoBehaviour
{

    public AudioClip[] musics;
    private AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        audio.clip = musics[Random.Range(0, musics.Length-1)];
        audio.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if(!audio.isPlaying)
        {
            audio.clip = musics[Random.Range(0, musics.Length-1)];
            audio.Play();
        }
    }
}
