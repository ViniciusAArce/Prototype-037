using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_2 : MonoBehaviour
{
    public GameObject Jogador;
    public GameObject Bullet;
    public float speed;
    public Move_Boss_2 JogadorMove;

    
    Vector3 direction = new Vector3(0, 0, 1);

    Vector3 tiro;

    
    void Start()
    {
        JogadorMove = Jogador.GetComponent<Move_Boss_2>();
    }

    
    void Update()
    {
        
        transform.LookAt(Jogador.transform);

        if (Input.GetKeyDown(KeyCode.T))
        {
            GameObject bullet_inst = Instantiate(Bullet, this.transform.position, this.transform.rotation);
        }
        
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
