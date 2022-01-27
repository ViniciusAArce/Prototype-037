using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dirigivel : MonoBehaviour
{

    public GameObject viagem;
    public float vel;

    // Start is called before the first frame update
    void Start()
    {
        vel = 20;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(viagem.transform);
        transform.Translate(0, 0, (vel * Time.deltaTime));
    }
}
