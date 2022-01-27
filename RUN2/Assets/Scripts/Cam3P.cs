using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam3P : MonoBehaviour
{
    public GameObject cabeca;
    public GameObject[] posicoes;
    public int indice = 0;
    public float VelocidadeDeMovimento = 2;
    private RaycastHit hit;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(cabeca.transform);
        //checar se tem colisor
        if (!Physics.Linecast (cabeca.transform.position, posicoes [indice].transform.position))
        {
            transform.position = Vector3.Lerp(transform.position, posicoes[indice].transform.position, VelocidadeDeMovimento*Time.deltaTime);
            Debug.DrawLine(cabeca.transform.position, posicoes[indice].transform.position);
        }
        else
        if (Physics.Linecast(cabeca.transform.position, posicoes[indice].transform.position, out hit))
        {
            transform.position = Vector3.Lerp(transform.position, hit.point, (VelocidadeDeMovimento * 2) * Time.deltaTime);
            Debug.DrawLine(cabeca.transform.position, hit.point);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow) && indice < (posicoes.Length - 1))
        {
            indice++;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow) && indice >= (posicoes.Length - 1))
        {
            indice = 0;
        }
        

    }

    void LateUpdate()
    {
        transform.LookAt(cabeca.transform);
        //checar se tem colisor
        if (!Physics.Linecast(cabeca.transform.position, posicoes[indice].transform.position))
        {
            transform.position = Vector3.Lerp(transform.position, posicoes[indice].transform.position, VelocidadeDeMovimento * Time.deltaTime);
            Debug.DrawLine(cabeca.transform.position, posicoes[indice].transform.position);
        }
        else
        if(Physics.Linecast(cabeca.transform.position, posicoes[indice].transform.position,out hit))
        {
            transform.position = Vector3.Lerp(transform.position, hit.point, (VelocidadeDeMovimento*2)*Time.deltaTime);
            Debug.DrawLine(cabeca.transform.position, hit.point);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow) && indice < (posicoes.Length - 1))
        {
           indice++;
        }
        
        if (Input.GetKeyDown(KeyCode.RightArrow) && indice >= (posicoes.Length - 1))
        {
            indice = 0;
        }



    }




}
