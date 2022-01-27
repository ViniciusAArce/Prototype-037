using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DR_SEGUE : MonoBehaviour
{
    public GameObject Drone1;
    public GameObject Drone2;
    public GameObject Drone3;
    public GameObject Drone4;
    public GameObject Drone5;
    public GameObject Drone6;
    public GameObject Drone7;
    public GameObject Drone8;
    public GameObject Drone9;
    public GameObject Drone9_1;
    public GameObject Drone10;
    public GameObject Drone10_1;
    public GameObject Drone10_2;
    public GameObject Drone10_3;
    public GameObject DroneS1;
    public GameObject DroneS2;
    public GameObject DroneS3;
    public GameObject DroneS4;
    public GameObject DroneS5;
    public GameObject DroneS6;

    public float tempo;

    public GameObject Cx1;
    public GameObject Cx2;
    public GameObject Cx3;
    public GameObject Cx4;
    public GameObject Cx5;
    public GameObject Cx6;
    public GameObject Cx7;
    public GameObject Cx8;
    public GameObject Cx9;
    public GameObject Cx10;
    



    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "D1")
        {
            Drone1.SetActive(true);
            Cx1.SetActive(false);


        }

        if (other.tag == "D2")
        {
            Drone2.SetActive(true);
            Cx2.SetActive(false);
        }

        if (other.tag == "D3")
        {
            Drone3.SetActive(true);
            Cx3.SetActive(false);
        }

        if (other.tag == "D4")
        {
            Drone4.SetActive(true);
            Cx4.SetActive(false);
        }

        if (other.tag == "D5")
        {
            Drone5.SetActive(true);
            Cx5.SetActive(false);
        }

        if (other.tag == "D6")
        {
            Drone6.SetActive(true);
            Cx6.SetActive(false);
        }

        if (other.tag == "D7")
        {
            Drone7.SetActive(true);
            Cx7.SetActive(false);
        }

        if (other.tag == "D8")
        {
            Drone8.SetActive(true);
            Cx8.SetActive(false);
        }

        if (other.tag == "D9")
        {
            Drone9.SetActive(true);
            Drone9_1.SetActive(true);
            Cx9.SetActive(false);
        }
        if (other.tag == "D10")
        {
            Drone10.SetActive(true);
            Drone10_1.SetActive(true);
            Drone10_2.SetActive(true);
            Drone10_3.SetActive(true);
            Cx10.SetActive(false);
        }


    }

    

}
