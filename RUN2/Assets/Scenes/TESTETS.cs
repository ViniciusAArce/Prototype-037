using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TESTETS : MonoBehaviour
{
    public GameObject Jogador;
    public GameObject bOSSaLVO;
    private float speedItem = 20.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.Translate(0, 0, (speedItem * Time.deltaTime));
        Invoke("vOLTATIRO",5.0f);
    }

    void vOLTATIRO()
    {
        transform.LookAt(bOSSaLVO.transform);
        transform.Translate(0, 0, (speedItem * Time.deltaTime));
    }
}
