using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DANOIMPULSO : MonoBehaviour
{
    public float PuloPulo;
    public PlayerFz1 player;



    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "Player")
        {
            player = other.gameObject.GetComponent<PlayerFz1>();
            player.rigidbody.AddForce(PuloPulo, 0, 0, ForceMode.Impulse);
        }
    }


}
