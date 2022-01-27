using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player1 : MonoBehaviour
{
    
    [SerializeField]
    public float _speed = 10.0f;
    public float _jumpHeight = 30.0f;

    public bool onRigth;


    public List<GameObject> Vida = new List<GameObject>();

    public int vidaAtual;

    [SerializeField]
    private float _gravity = 0.0f;
    private float _yVelocity = 0.0f;

    public GameObject spawnAtual;


    bool girar = false;
           

    new public Rigidbody rigidbody;
        
    public bool podePular;

    
    private Animator AnimPlay;
    private Animator play;
    private Animator SinalPlay;



    // Direction to Travel (Vector3)

    Vector3 direction = new Vector3(0, 0, 1);
    Vector3 velocity = new Vector3(0, 1, 0);

    private object other;
    

    


    // Start is called before the first frame update
    void Start()
    {
        onRigth = true;
        AnimPlay = GetComponent<Animator>();
        SinalPlay = GetComponent<Animator>();

        rigidbody = GetComponent<Rigidbody>();
               

    }


   
    // Update is called once per frame
    void Update()
    {
        
        //Direction to Travel (Vector3)
        if (girar == false)
        {
            direction = new Vector3 (0, 0, 1);
        }

        
        //velocity
        velocity = direction * _speed;

        

        if ((Input.GetKeyDown(KeyCode.RightArrow) || Input.GetAxis("Horizontal") > 0.3f) && onRigth == false)
        {
            this.transform.RotateAround(this.transform.position,Vector3.up, 180);
            direction = new Vector3(0, 0, 1);
            girar = false;

            if (onRigth == false)
            {
                onRigth = true;
            }

        } 
        if ((Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetAxis("Horizontal") < -0.3f) && onRigth == true)
        {
            this.transform.RotateAround(this.transform.position, Vector3.up, 180);
            direction = new Vector3(0, 0, -1);
            girar = true;

            if (onRigth == true)
            {
                onRigth = false;
            }
        }

        

        if (podePular)
        {
            

            if (Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Jump"))
            {              
                rigidbody.velocity = Vector3.up * _jumpHeight;
                AnimPlay.SetBool("Jump", true);
                AnimPlay.SetBool("Grounded", false);
                
                podePular = false;                          
                                
            }
                        
        }
        else
        {
            AnimPlay.SetBool("Jump", false);
            //add gravity 
            _yVelocity -= _gravity;
            
        }

        

        velocity.y = _yVelocity;                       
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);

        
    }

    
    private void AtualizaHud()
    {
        if (Vida[vidaAtual] != null && vidaAtual > -1)
        {
            Vida[vidaAtual].SetActive(false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.CompareTag("DirPlataforma"))
        {
            
            podePular = true;
            //AnimPlay.SetBool("Jump", false);
            //AnimPlay.SetBool("Grounded", true);
        }
    }
    private void SetSpawn()
    {
        this.transform.position = spawnAtual.transform.position;
        this.transform.rotation = spawnAtual.transform.rotation;
        onRigth = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "TriggerRotacao")
        {
            transform.Rotate(0, -90, 0);
            direction = new Vector3(0, 1, 0);
            
        }
        

        if (other.tag == "TR2")
        {
            transform.Rotate(0, 90, 0);
            direction = new Vector3(0, 1, 0); 
        }

        if (other.tag == "MorteEnemy")
        {
            vidaAtual -= 1;
            AtualizaHud();
        }

        if (other.tag == "TR3")
        {
            transform.Rotate(0, 45, 0);
            direction = new Vector3(0, 1, 0); 
        }
        

        if (other.tag == "slide")
        {
            transform.Rotate(0, -90, 0);
            direction = new Vector3(0, 1, 0);
            AnimPlay.gameObject.GetComponent<Animator>().SetTrigger("Slide");
        }

        if (other.tag == "Morte")
        {
            SetSpawn();
        }

        if (other.tag == "sinal")
        {
            Invoke("sinal_AM", 2.0f);
        }

        if (other.tag == "GoCarros")
        {
            SinalPlay.SetBool("Sobe", true);
        }

        if (other.tag == "chefe")
        {
            SceneManager.LoadScene(5);
        }

        if (other.tag == "spawn")
        {
            spawnAtual = other.transform.gameObject;
        }

    }

   

}
