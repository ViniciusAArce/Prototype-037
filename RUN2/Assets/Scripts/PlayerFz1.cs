using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerFz1 : MonoBehaviour
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
    
    
    //public GameObject Sinal_Verde;
    public GameObject Sinal_Verde;
    public GameObject Sinal_Amarelo;
    public GameObject Sinal_Vermelho;
    public GameObject spawnAtual;
    public GameObject Vida_EX;
    public GameObject itemCheckpoint;
    public GameObject pos1;
    public GameObject pos2;

    


    new public Rigidbody rigidbody;
        
    public bool podePular;

    bool Livre;
    bool Linear;


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
        
        AnimPlay = GetComponent<Animator>();
        SinalPlay = GetComponent<Animator>();

        rigidbody = GetComponent<Rigidbody>();

        onRigth = true;
        Linear = true;
        Livre = false;
        AnimPlay.SetFloat("Speed", 1);

    }


   
    // Update is called once per frame
    void Update()
    {
        //Debug.Log(onRigth);
        //Direction to Travel (Vector3)
        Correr();
        if (girar == false)
        {
            direction = new Vector3 (0, 0, 1);
        }

        if (vidaAtual == 0)
        {
            Death();
            return;
        }

       
        
    }

    private void Correr()
    {
        
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

            if ((Input.GetKeyDown(KeyCode.RightArrow) || Input.GetAxis("Horizontal") > 0.3f) && onRigth == false)
            {
                this.transform.RotateAround(this.transform.position, Vector3.up, 180);
                direction = new Vector3(0, 0, 1);
                girar = false;

                if(onRigth == false)
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

            //velocity
            //velocity = direction * _speed;


            velocity.y = _yVelocity;
            //Debug.Log(_speed);
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
        onRigth = true;
    }

    private void Death()
    {
        SetSpawn();
        RestauraVida(); RestauraVida(); RestauraVida();
                
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
            vidaAtual -= 1;
            AtualizaHud();
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

        if (other.tag == "sinal")
        {
            Invoke("sinal_AM", 2.0f);
        }

        if (other.tag == "GoCarros")
        {
            SinalPlay.SetBool("Sobe", true);
        }

        if (other.tag == "spawn")
        {
            spawnAtual = other.transform.gameObject;
        }

        if (other.tag == "chefe")
        {
            SceneManager.LoadScene(3);
        }

        
    }

    void sinal_AM()
    {
        Sinal_Amarelo.SetActive(true);
        Sinal_Vermelho.SetActive(false);
    }

}
