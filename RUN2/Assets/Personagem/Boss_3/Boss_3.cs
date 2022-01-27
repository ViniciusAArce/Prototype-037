using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_3 : MonoBehaviour
{
    public GameObject target;
    public float vel;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target.transform);
        transform.Translate(Vector3.forward * vel * Time.deltaTime);
    }
}
