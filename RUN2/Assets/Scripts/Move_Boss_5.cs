using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Boss_5 : MonoBehaviour
{

    public float _vel;
    public bool onRigth;
    bool pode_correr = true;    
    
    
    private Animator anim;


    void Start()
    {              

        anim = GetComponentInChildren<Animator>();

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
                transform.Translate(0, 0, (_vel * Time.deltaTime));

                if (onRigth == false)
                {
                    onRigth = true;
                    transform.Rotate(Vector3.up * 180);
                }
            }
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetAxis("Horizontal") < -0.3f)
            {
                anim.SetFloat("Speed", 1);
                transform.Translate(0, 0, (_vel * Time.deltaTime));
                if (onRigth)
                {
                    onRigth = false;
                    transform.Rotate(Vector3.up * 180);
                }
            }

          
        }

       

    }

    







}
