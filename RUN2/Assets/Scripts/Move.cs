using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Move : MonoBehaviour
{
    public float vel;
    public float _jumpHeight = 30.0f;
    
    bool girar = false;
    public bool onRigth;
    bool pode_correr = true;
    bool shotting = false;    
   

    new Rigidbody rigidbody;

    public bool podePular;
    public List<GameObject> Vida = new List<GameObject>();

    public Animator anim;
    private float _gravity = 0.0f;
    private float _yVelocity = 0.0f;
    
    Vector3 direction = new Vector3(0, 0, 1);

    void Start()
    {
        
             
        anim = GetComponentInChildren<Animator>();
        
        rigidbody = GetComponent<Rigidbody>();
        
       
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("Speed", 0);

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetAxis("Horizontal") > 0.3f) 
        {
            Movimento();
            if (onRigth == true)
            {
                onRigth = false;
                transform.Rotate(Vector3.up * 180);
            }
        }
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetAxis("Horizontal") < -0.3f)
        {
            Movimento();
            if (onRigth == false)
            {
                onRigth = true;
                transform.Rotate(Vector3.up * 180);
            }
        }
                
        if (podePular)
        {


            if (Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Jump"))
            {
                rigidbody.velocity = Vector3.up * _jumpHeight;
                anim.SetBool("Jump", true);
                anim.SetBool("Grounded", false);

                podePular = false;

            }

        }
        else
        {
            anim.SetBool("Jump", false);
            //add gravity 
            _yVelocity -= _gravity;

        }


    }

    void Movimento()
    {
        anim.SetFloat("Speed", 1);
        transform.Translate(0, 0, (vel * Time.deltaTime));
    }
       
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("DirPlataforma"))
        {
           
            podePular = true;
            anim.SetBool("Jump", false);
            anim.SetBool("Grounded", true);
        }
    }

 


}
