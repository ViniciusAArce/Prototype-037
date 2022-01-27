using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCRLEGAS : MonoBehaviour
{
    public Renderer meurender;
    

    public float scrollSpeed = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        meurender = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float offset = Time.time * scrollSpeed;
        meurender.material.mainTextureOffset = new Vector2(offset,0);
    }
}
