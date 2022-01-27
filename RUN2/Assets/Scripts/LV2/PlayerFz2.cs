using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerFz2 : MonoBehaviour
{
    
    [SerializeField]
    public float _speed = 10.0f;
    public float _jumpHeight = 30.0f;

    
    public List<GameObject> Vida = new List<GameObject>();

    public int vidaAtual;

    [SerializeField]
    private float _gravity = 0.0f;
    private float _yVelocity = 0.0f;

    public bool onRigth;


    bool girar = false;
    
    
    public GameObject spawnAtual;
    public GameObject spawnAtual2;
    public GameObject spawnAtual3;
    public GameObject spawnAtual4;
    public GameObject Vida_EX;
    public GameObject itemCheckpoint; 


    new public Rigidbody rigidbody;
        
    public bool podePular;

    bool Livre;
    bool Linear;


    private Animator AnimPlay;
    


    // Direction to Travel (Vector3)

    Vector3 direction = new Vector3(0, 0, 1);
    Vector3 velocity = new Vector3(0, 1, 0);

    private object other;
    

    


    // Start is called before the first frame update
    void Start()
    {
        
        AnimPlay = GetComponent<Animator>();
        

        rigidbody = GetComponent<Rigidbody>();

        onRigth = true;
        Linear = true;
        Livre = false;
        AnimPlay.SetFloat("Speed", 1);

    }


   
    // Update is called once per frame
    void Update()
    {
        
        //Direction to Travel (Vector3)
        if (girar == false)
        {
            direction = new Vector3 (0, 0, 1);
        }

        if (vidaAtual == 0)
        {
            Death();
        }

        //velocity
        velocity = direction * _speed;

        if (Livre)
        {
            AnimPlay.SetFloat("Speed", 0);

            if (Input.GetKey(KeyCode.RightArrow) || Input.GetAxis("Horizontal") > 0.3f)
            {
                AnimPlay.SetFloat("Speed", 1);
                transform.Translate(0, 0, (_speed * Time.deltaTime));

                if (onRigth == false)
                {
                    onRigth = true;
                    transform.Rotate(Vector3.up * 180);
                }
            }
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetAxis("Horizontal") < -0.3f)
            {
                AnimPlay.SetFloat("Speed", 1);
                transform.Translate(0, 0, (_speed * Time.deltaTime));
                if (onRigth)
                {
                    onRigth = false;
                    transform.Rotate(Vector3.up * 180);
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

        }

        if (Linear)
        {

            if ((Input.GetKeyDown(KeyCode.RightArrow) || Input.GetAxis("Horizontal") > 0.3f) && girar == true)
            {
                this.transform.RotateAround(this.transform.position, Vector3.up, 180);
                direction = new Vector3(0, 0, 1);
                girar = false;


                onRigth = true;


            }
            if ((Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetAxis("Horizontal") < -0.3f) && girar == false)
            {
                this.transform.RotateAround(this.transform.position, Vector3.up, 180);
                direction = new Vector3(0, 0, -1);
                girar = true;


                onRigth = false;


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
        
    }

    

    private void RestauraVida()
    {
        Vida[vidaAtual].SetActive(true);
        vidaAtual += 1;
    }

    private void SetSpawn()
    {
        this.transform.position = spawnAtual.transform.position;
        this.transform.rotation = spawnAtual.transform.rotation;
    }

    private void SetSpawn2()
    {
        this.transform.position = spawnAtual2.transform.position;
        this.transform.rotation = spawnAtual2.transform.rotation;
    }

    private void SetSpawn3()
    {
        this.transform.position = spawnAtual3.transform.position;
        this.transform.rotation = spawnAtual3.transform.rotation;
    }

    private void SetSpawn4()
    {
        this.transform.position = spawnAtual4.transform.position;
        this.transform.rotation = spawnAtual4.transform.rotation;
    }

    private void Death()
    {
        SetSpawn();
        RestauraVida(); RestauraVida(); RestauraVida();
        onRigth = true;        
    }
    

    private void Checkpoint()
    {
        transform.position = itemCheckpoint.transform.position;
        //transform.rotation = spawnAtual.transform.rotation;
        

    }

    private void AtualizaHud()
    {
        if (Vida[vidaAtual] != null && vidaAtual > -1)
        {
            Vida[vidaAtual].SetActive(false);

            if(vidaAtual <= 0)
            {
                Death();
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.CompareTag("DirPlataforma"))
        {
            
            podePular = true;
            AnimPlay.SetBool("Jump", false);
            AnimPlay.SetBool("Grounded", true);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "MorteEnemy")
        {
            SetSpawn();
        }

        if (other.tag == "TR2")
        {
            Linear = false;
            Livre = true;
        }

        if (other.tag == "357")
        {
            SetSpawn();
        }

        if (other.tag == "Morte")
        {
            Death();
        }

        if (other.tag == "spawn")
        {
            SetSpawn();
        }

        if (other.tag == "spawn2")
        {
            SetSpawn2();
        }

        if (other.tag == "spawn3")
        {
            SetSpawn3();
        }

        if (other.tag == "spawn4")
        {
            SetSpawn4();
        }

        if (other.tag == "chefe")
        {
            SceneManager.LoadScene(3);
        }

        
    }


}
