using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiroBoss2 : MonoBehaviour
{


    private float speedItem = 20.0f;

    
    // Use this for initialization
    void Start()
    {


    }
    // Update is called once per frame
    void Update()
    {
        Invoke("Shooting", 2.5f);
        
    }
    void Shooting()
    {
        transform.Translate(Vector3.forward * speedItem * Time.deltaTime);
    }
}
