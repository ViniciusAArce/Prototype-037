using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followpos : MonoBehaviour
{
    public GameObject pos;
    public float vel;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(pos.transform);
        transform.Translate(Vector3.forward * vel * Time.deltaTime);
    }
}
