using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using TMPro;


public class PlayerConteroller : MonoBehaviour
{
    [SerializeField] private TMP_Text ScoreText;
    public AudioSource ShootAudio;
    public ParticleSystem thrustParticle;

    public GameObject bullet;
    public float thrust = 1f;
    public float revSpeed = 1f;
    public float maxLaserDist = 10;


    private Rigidbody2D rb;
    private Vector3 mousePos;
    private float zoomAcsr = 0;
    private float timeToFire;
    private bool canFire;
    private int score = 0;
    private AudioSource jetAudio;
   

    public Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        jetAudio = GetComponent<AudioSource>();
        rb.drag = 0.4f;
        
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if(col.tag == "Shard") {
            var fdir = transform.position - col.transform.position;
            col.gameObject.GetComponent<Rigidbody2D>().AddForce(fdir*2);
        }
        //Debug.Log(col.gameObject.name + col.tag);
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.tag == "Shard") {
            
            AddScore();
            Destroy(collision.gameObject);
        }
    }


    void Shoot() 
    {

        var bulInst = Instantiate(bullet, transform.position, Quaternion.Euler(0, 0, transform.eulerAngles.z + Random.Range(-10, 10)));
        Rigidbody2D bulRb = bulInst.GetComponent<Rigidbody2D>();
        Physics2D.IgnoreCollision(bulInst.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        bulRb.AddForce(bulInst.transform.up  * 5000);
        ShootAudio.pitch = Random.Range(0.8f, 1.5f);
        ShootAudio.Play();
    }   

    public void AddScore() {
        score +=1;
        ScoreText.text =  string.Empty + score;
    }

    


    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetAxis("Vertical") != 0) {
            rb.AddForce(transform.up * Input.GetAxis("Vertical") * (thrust + rb.totalForce.magnitude));
            thrustParticle.Play();
            thrustParticle.startLifetime = Mathf.Abs(rb.velocity.magnitude)/60;

            if (!jetAudio.isPlaying) jetAudio.Play();
            jetAudio.pitch = 0.4f + Mathf.Round(rb.velocity.magnitude)/ 10;
            Debug.Log(jetAudio.pitch);
            
        } else {
            thrustParticle.Stop(); 
            jetAudio.Stop();       
            }
        if (Input.GetAxis("Horizontal") != 0) {
            rb.freezeRotation = false;
            rb.MoveRotation(rb.rotation - revSpeed * Input.GetAxis("Horizontal"));
        } else {
            rb.freezeRotation = true;
        }
        
        
        
        
    }

    void Update(){
        
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        cam.fieldOfView += Input.mouseScrollDelta.y + zoomAcsr;

        if (Input.GetMouseButton(0) && Time.time > timeToFire + Random.Range(0.4f, 1))
        {
            timeToFire = Time.time;
            Shoot();

        
    }
}
}
