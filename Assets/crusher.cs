using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crusher : MonoBehaviour
{

    public Animator shraderAnim;
    public Animator itemAnim;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Idle(){
        itemAnim.gameObject.SetActive(false);
        shraderAnim.Play("Idle.Crusher");
    }

    void Crushing() {
        itemAnim.gameObject.SetActive(true);
        itemAnim.Play("Base Layer.CrushAsteroids");
    }


    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(1)){
           Crushing(); 
        }else {
            Idle();
        }
    }
}
