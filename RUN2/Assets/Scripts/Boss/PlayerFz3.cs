using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerFz3 : MonoBehaviour
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

    public GameObject spawnAtual;
    bool girar = false;    
    
    


    new public Rigidbody rigidbody;
        
    public bool podePular;
        


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

        
        
            AnimPlay.SetFloat("Speed", 0);

            if (Input.GetKey(KeyCode.RightArrow))
            {
                AnimPlay.SetFloat("Speed", 1);
                transform.Translate(0, 0, (_speed * Time.deltaTime));

                if (onRigth == false)
                {
                    onRigth = true;
                    transform.Rotate(Vector3.up * 180);
                }
            }
            if (Input.GetKey(KeyCode.LeftArrow))
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


                if (Input.GetKeyDown(KeyCode.Space))
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

    

    private void Death()
    {
        SetSpawn();
        RestauraVida(); RestauraVida(); RestauraVida();
        onRigth = true;        
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


        //if (other.tag == "chefe")
        //{
        //    SceneManager.LoadScene(3);
       // }

        
    }


}
