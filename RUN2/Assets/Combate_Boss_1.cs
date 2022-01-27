using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combate_Boss_1 : MonoBehaviour
{
    public Move move;
    public GameObject spawnAtual;
    public bool ajuste = false;

    public Tirochefe inimigo;

    public bool atirando = false;
    public bool emposicao = false;

    void Start()
    {
        move = this.GetComponent<Move>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad0) && atirando == false)
        {
            move.anim.SetTrigger("Gun");
            atirando = true;            
            Invoke("NaoAtira", 2.0f);
            if (emposicao)
            {
                inimigo.Damage();
            }
        }

        if (atirando)
        {
            move.vel = 0;

        }
        else
        {
            move.vel = 20;
        }

        if (this.transform.position.y <= -2)
        {
            SetSpawn();
        }
    }

    void NaoAtira()
    {
        atirando = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("chefe"))
        {
            this.transform.Rotate(new Vector3(0, -45, 0)); 
        }

        if (other.CompareTag("Pedra"))
        {
            SetSpawn();
            ajuste = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("chefe") && ajuste == false)
        {
            this.transform.Rotate(new Vector3(0, 45, 0));
            emposicao = false;
        }

    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("chefe"))
        {
            emposicao = true;
        }
    }

    private void SetSpawn()
    {
        this.transform.position = spawnAtual.transform.position;
        this.transform.rotation = spawnAtual.transform.rotation;
        ajuste = false;
        move.onRigth = false;
    }

}
