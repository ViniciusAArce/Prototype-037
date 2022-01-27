using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vidra : MonoBehaviour
{
    public Bos3 chefe;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "MorteEnemy")
        {
            chefe.vida -= 1;
            if(chefe.vida == 0)
            {
                chefe.gameObject.SetActive(false);                
            }
            drone = other.gameObject;
            drone.transform.position = chefe.transform.position;
            this.gameObject.SetActive(false);
            Invoke("Delay", 3.0f);
            
        }
    }
    GameObject drone;
    void Delay()
    {
        drone.transform.position = chefe.transform.position;
    }
}
