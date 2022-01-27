using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Morreu : MonoBehaviour
{

    RaycastHit hit;
    Vector3 pos;
    public Vector3 offset = Vector3.up * 3;
    public Vector3 dir = Vector3.left;
    public float dis = 2;

    public GameObject Explo;
    public PlayerFz1 player;
    public float PuloPulo;
    private float velQueda = 30f;

    public AudioSource boom;



    // Start is called before the first frame update
    void Start()
    {
       
        Explo.SetActive(false);
        
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
           
            
            if(hit.transform.tag == "Player")
            {
                boom.Play();
                Explo.SetActive(true);
                transform.Translate(0, -(velQueda * Time.deltaTime), 0);
                Invoke("Destroy", 1.5f);
                player.rigidbody.velocity = Vector3.up * PuloPulo;
                
            }
        }
    }

    void Destroy()
    {
        Destroy(this.gameObject);
        Explo.SetActive(true);
    }
    

}
