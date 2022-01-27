using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sinal : MonoBehaviour
{
    private Animator AnimPlay;


    RaycastHit hit;
    Vector3 pos;
    public Vector3 offset = Vector3.up * 3;
    public Vector3 dir = Vector3.left;
    public float dis = 2;
    // Start is called before the first frame update
    void Start()
    {
        AnimPlay = GetComponent<Animator>();
    }
    

    // Update is called once per frame
    void Update()
    {
        RayCastCima();
    }
    void RayCastCima()
    {
        pos = this.transform.position;
        pos += offset;
        Debug.DrawRay(pos, dir * dis, Color.blue);

        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(pos, dir, out hit, dis))
        {

            Debug.Log("Did Hit");
            if (hit.transform.tag == "Player")
            {
                AnimPlay.SetBool("Sobe", true);
            }
        }
    }
}
