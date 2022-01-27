using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float vel;

    // Start is called before the first frame update
    void Start()
    {
        
        Invoke("DestroyThis", 4.0f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * vel * Time.deltaTime);
    }

    void DestroyThis()
    {
        Destroy(this.gameObject);
    }
}
