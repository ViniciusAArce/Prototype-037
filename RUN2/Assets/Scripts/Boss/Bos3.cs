using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bos3 : MonoBehaviour
{
   

    public GameObject Jogador;
    // public Move_Boss_3 JogadorMove;
    public int vida = 4;


    public float cdtiro;
    public float delay;
    float contador;
    
    Vector3 direction = new Vector3(0, 0, 1);

    
    bool atirando;

    
    void Start()
    {
       
        //JogadorMove = Jogador.GetComponent<Move_Boss_3>();        
    }

    
    void Update()
    {
        
        contador += Time.deltaTime;

        if (contador >= cdtiro-delay)
        {

            atirando = true;
        }

        if (contador >= cdtiro)
        {
            Atirar();
            
        }

        if(atirando == false)
        {
            transform.LookAt(Jogador.transform);

        }
                
        
    }
   private void Atirar()
    {
        contador = 0;
        atirando = false;
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "TriggerRotacao")
        {
            transform.Rotate(0, -90, 0);
            direction = new Vector3(0, 1, 0);          

        }
    }
}
