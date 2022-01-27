using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Boss_2 : MonoBehaviour
{

    float _velocidadeFrente;
    float _velocidadeTras;
    float _velocidadeUP;
    float _velocidadeDown;

    private float speedItem = 40.0f;

    bool girar = false;
    bool onRigth;
    bool pode_correr = true;
    bool pode_jogar = false;
    bool pedrada = false;
    bool pode_virar = true;

    new Rigidbody rigidbody;

        

    public List<GameObject> ItemArremessar = new List<GameObject>();
    public GameObject ItemMao;    
    public GameObject ItemVoando;
    

    private Animator anim;
    private float _gravity = 0.0f;
    private float _yVelocity = 0.0f;

    
    Vector3 direction = new Vector3(0, 0, 1);
   
    private Animator AnimChefe;
    public Camera cam;
    private Animator AnimPedra;

          
    void Start()
    {
        _velocidadeFrente = 10;
        _velocidadeTras = 10;
        _velocidadeUP = 1;
        _velocidadeDown = 10;       

        anim = GetComponentInChildren<Animator>();
        AnimPedra = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
        onRigth = true;

        ItemMao.SetActive(false);
        ItemVoando.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
        
        anim.SetFloat("Speed", 0);

        if(pode_correr)
        {
            if (Input.GetKey(KeyCode.RightArrow) || Input.GetAxis("Horizontal") > 0.3f)
            {
                anim.SetFloat("Speed", 1);
                transform.Translate(0, 0, (_velocidadeFrente * Time.deltaTime));

                if (onRigth == false)
                {
                    onRigth = true;
                    transform.Rotate(Vector3.up * 180);
                }
            }
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetAxis("Horizontal") < -0.3f)
            {
                anim.SetFloat("Speed", 1);
                transform.Translate(0, 0, (_velocidadeTras * Time.deltaTime));
                if (onRigth)
                {
                    onRigth = false;
                    transform.Rotate(Vector3.up * 180);
                }
            }
        }

        if (pode_jogar)
        {
            if (Input.GetKeyDown(KeyCode.Keypad0) && pedrada == false)
            {
                transform.Rotate(0, -90, 0);
                AnimPedra.SetTrigger("Pedra");
                Debug.Log("PEDRADA");
                pode_correr = false;
                Invoke("Pedrada", 2.0f);
                Invoke("PegarItem", 0.5f);

            }
        }
              

        
    }
    
    void Pedrada()
    {
        pedrada = false;
        pode_correr = true;
        pode_jogar = false;
        transform.Rotate(0, 90, 0);

    }

    void PegarItem()
    {
        Destroy(ItemArremessar[0].gameObject);
        ItemArremessar.Remove(ItemArremessar[0].gameObject);
        ItemMao.SetActive(true);
        Invoke("VoarItem", 0.8f);
    }

    void VoarItem()
    {
        ItemMao.SetActive(false);
        ItemVoando.SetActive(true);
        
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Pedra")
        {
            pode_jogar = true;

        }
        
    }

    
           


}
