using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nave : MonoBehaviour
{
    public Gun theGun;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            theGun.isFiring = true;

        if (Input.GetKeyUp(KeyCode.Space))
            theGun.isFiring = true;
    }
}
