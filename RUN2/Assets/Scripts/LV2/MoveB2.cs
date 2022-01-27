using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveB2 : MonoBehaviour
{

    public float vel;
    
    
    public float _jumpHeight = 30.0f;

    
    public GameObject spawnAtual;
    public GameObject itemCheckpoint;

    bool girar = false;
    public bool onRigth;
    bool pode_correr = true;
    
    bool isGrounded = true;

    bool Livre;
    bool Linear;

    new Rigidbody rigidbody;
    public bool podePular;
    
    public List<GameObject> Vida = new List<GameObject>();

    public int vidaAtual;

    private Animator AnimPlay;
    private float _gravity = 0.0f;
    private float _yVelocity = 0.0f;

    
    Vector3 direction = new Vector3(0, 0, 1);    
    Vector3 velocity = new Vector3(0, 1, 0);
    







    void Start()
    {

        AnimPlay = GetComponentInChildren<Animator>();        
        rigidbody = GetComponent<Rigidbody>();
        onRigth = true;        
        Linear = true;
        Livre = false;
        AnimPlay.SetFloat("Speed", 1);
       
    }

    // Update is called once per frame
    void Update()
    {
        AnimPlay.SetFloat("Speed", 0);

        //Direction to Travel (Vector3)
        if (girar == false)
        {
            direction = new Vector3(0, 0, 1);
        }

        if (vidaAtual == 0)
        {
            Death();
        }


        //velocity
        velocity = direction * vel;

        if (Livre)
        {
            AnimPlay.SetFloat("Speed", 0);

            if (Input.GetKey(KeyCode.RightArrow))
            {
                AnimPlay.SetFloat("Speed", 1);
                transform.Translate(0, 0, (vel * Time.deltaTime));

                if (onRigth == false)
                {
                    onRigth = true;
                    transform.Rotate(Vector3.up * 180);
                }
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                AnimPlay.SetFloat("Speed", 1);
                transform.Translate(0, 0, (vel * Time.deltaTime));
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

        if (Linear)
        {

            if (Input.GetKeyDown(KeyCode.RightArrow) && girar == true)
            {
                this.transform.RotateAround(this.transform.position, Vector3.up, 180);
                direction = new Vector3(0, 0, 1);
                girar = false;


                onRigth = true;


            }
            if (Input.GetKeyDown(KeyCode.LeftArrow) && girar == false)
            {
                this.transform.RotateAround(this.transform.position, Vector3.up, 180);
                direction = new Vector3(0, 0, -1);
                girar = true;


                onRigth = false;


            }

            if (vidaAtual == 0)
            {
                Death();
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



            velocity.y = _yVelocity;

            transform.Translate(Vector3.forward * vel * Time.deltaTime);

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

    private void Atira() { }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("chao"))
        {
            isGrounded = true;
            podePular = true;
            AnimPlay.SetBool("Jump", false);
            AnimPlay.SetBool("Grounded", true);
        }
    }



}
