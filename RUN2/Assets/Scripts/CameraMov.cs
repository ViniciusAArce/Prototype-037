using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMov : MonoBehaviour
{
    public GameObject cabeca;
    public GameObject[] posicoes;
    private int indice = 0;
    public float VelocidadeDeMovimento = 2;
    private RaycastHit hit;
    public GameObject player;
    void FixedUpdate()
    {
        transform.LookAt(cabeca.transform);
        //CHECAR SE TEM COLISOR
        if (!Physics.Linecast(cabeca.transform.position, posicoes[indice].transform.position))
        {
            transform.position = Vector3.Lerp(transform.position, posicoes[indice].transform.position, VelocidadeDeMovimento * Time.deltaTime);
            Debug.DrawLine(cabeca.transform.position, posicoes[indice].transform.position);
        }
        else if (Physics.Linecast(cabeca.transform.position, posicoes[indice].transform.position, out hit))
        {
            transform.position = Vector3.Lerp(transform.position, hit.point, (VelocidadeDeMovimento * 2) * Time.deltaTime);
            Debug.DrawLine(cabeca.transform.position, hit.point);
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            indice = 1;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            indice = 0;
        }
        //else if (player.GetComponent<Player>().RotacaoCamera == true)
        //{
         //   indice = 2;
        //}

    }

}
