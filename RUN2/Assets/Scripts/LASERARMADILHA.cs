using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LASERARMADILHA : MonoBehaviour
{
    private Animator AnimPlay;

    void Start()
    {
        AnimPlay = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            AnimPlay.SetBool("Go", true);            
        }
    }
}
