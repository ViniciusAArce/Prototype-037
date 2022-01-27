using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elevador : MonoBehaviour
{
    public Vector3 vel;
    public float count;
    public int mod;
    public int tempo;

    void Start()
    {
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        count += 1 * Time.deltaTime;
        Debug.Log(count);
        if (count < tempo)
        {
            mod = 1;
        }
        else  
        {
            mod = -1;
        }

        if(count >= tempo*2)
        {
            count = 0;
        }

        this.transform.position += vel * Time.deltaTime * mod;

    }
}
