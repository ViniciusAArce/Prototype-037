using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public float PuloPulo;
    public Player1 player;



    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "Player")
        {
            player = other.gameObject.GetComponent<Player1>();
            player.rigidbody.AddForce(0, PuloPulo, 0, ForceMode.Impulse);
        }
    }


}
