using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Level1 : MonoBehaviour
{

    float _velocidadeFrente;
    float _velocidadeTras;    
    public float _jumpHeight = 30.0f;

    public GameObject AlvoBoss;
    public GameObject Bullet;


    bool onRigth;
    bool pode_correr = true;
    bool shotting = false;


   

    new Rigidbody rigidbody;

    public bool podePular;
    public Gun theGun;
    public List<GameObject> Vida = new List<GameObject>();

    private Animator AnimPlay;
    private float _gravity = 0.0f;
    private float _yVelocity = 0.0f;

    
    
    private Animator AnimChefe;
    public Camera cam;
    private Animator AnimGun;







    void Start()
    {
        _velocidadeFrente = 10;
        _velocidadeTras = 10;
        

        AnimPlay = GetComponentInChildren<Animator>();
        AnimGun = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
        onRigth = true;

       
    }

    // Update is called once per frame
    void Update()
    {
        AnimPlay.SetFloat("Speed", 0);

        if(pode_correr)
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                AnimPlay.SetFloat("Speed", 1);
                transform.Translate(0, 0, (_velocidadeFrente * Time.deltaTime));

                if (onRigth == false)
                {
                    onRigth = true;
                    transform.Rotate(Vector3.up * 180);
                }
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                AnimPlay.SetFloat("Speed", 1);
                transform.Translate(0, 0, (_velocidadeTras * Time.deltaTime));
                if (onRigth)
                {
                    onRigth = false;
                    transform.Rotate(Vector3.up * 180);
                }
            }
        }



        

        if (podePular)
        {


            if (Input.GetKeyDown(KeyCode.Space))
            {
                rigidbody.AddForce(Vector3.up * _jumpHeight, ForceMode.Impulse);
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

    private void Atira() { }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("chao"))
        {
            
            podePular = true;
            AnimPlay.SetBool("Jump", false);
            AnimPlay.SetBool("Grounded", true);
        }
    }


    void Shooting()
    {
        pode_correr = true;
        shotting = false;
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "chefe")
        {
            cam.gameObject.GetComponent<Animator>().SetTrigger("chefe");

            transform.Rotate(0, -45, 0);
            
            

        }
        
    }
    private void OnTriggerStay(Collider other)
    {

        if (Input.GetKeyDown(KeyCode.Keypad0) && shotting == false)
        {
            
            shotting = true;
            pode_correr = false;
            Invoke("Shooting", 1.5f);
        
                    
            AnimGun.SetTrigger("Gun");            
            Invoke("Fire", 1.5f);
        }
    }

    void Fire()
    {
        GameObject bullet_inst = Instantiate(Bullet, this.transform.position, this.transform.rotation);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "chefe")
        {
            cam.gameObject.GetComponent<Animator>().SetTrigger("chefe_stop");

            transform.Rotate(0, 45, 0);
        }
    }


}
