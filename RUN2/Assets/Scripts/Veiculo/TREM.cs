using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TREM : MonoBehaviour
{

    public GameObject viagem;
    public float velTrem;

    // Start is called before the first frame update
    void Start()
    {
        velTrem = 20;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(viagem.transform);
        transform.Translate(0, 0, (velTrem * Time.deltaTime));
    }
}
