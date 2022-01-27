using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCast : MonoBehaviour
{

    RaycastHit hit;
    Vector3 pos;
    public Vector3 offset = Vector3.up * 3;
    public Vector3 dir = Vector3.left;
    public float dis = 2;
    public LayerMask layerMask;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        dir = this.transform.forward + Vector3.up * -1;
        //Debug.Log(dir);
        RayCastCima();
    }

    public CameraController camcom;

    void RayCastCima()
    {
        pos = this.transform.position;
        pos += offset;
        Debug.DrawRay(pos, dir * dis, Color.blue);
        Debug.DrawRay(pos, (this.transform.right *- 1 + Vector3.up *-1) * dis, Color.blue);
        Debug.DrawRay(pos, (this.transform.right + Vector3.up * -1 )* dis, Color.blue);

        // Does the ray intersect any objects excluding the player layer
        if(!Physics.Raycast(pos, dir, out hit, dis, layerMask))
        {
            if (Physics.Raycast(pos, this.transform.right * -1 + Vector3.up * -1, out hit, dis, layerMask))
            {
                    this.transform.Rotate(Vector3.up * -90);     
                if(camcom != null)
                {
                    camcom.lerp = 0;
                }
                                
            }
            else
            {
                if (Physics.Raycast(pos, this.transform.right * 1 + Vector3.up * -1, out hit, dis, layerMask))
                {       this.transform.Rotate(Vector3.up * 90);
                    if (camcom != null)
                    {
                        camcom.lerp = 0;
                    }
                }
            }
        }
    }
}
