using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_2 : MonoBehaviour
{
    public float vel;
    public GameObject Bala;
    public GameObject AlvoBoss;

    // Start is called before the first frame update
    void Start()
    {
        
        Invoke("DestroyThis", 4.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad0))
        {
            transform.LookAt(AlvoBoss.transform);
            transform.Translate(Vector3.forward * vel * Time.deltaTime);
            Debug.Log("atirou");
        }
        
    }

    void DestroyThis()
    {
        Destroy(this.gameObject);
    }
}
