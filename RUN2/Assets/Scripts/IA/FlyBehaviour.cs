using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyBehaviour : MonoBehaviour
{
    GameObject target;

    enum gameState { patrolling, returning, chasing };
    gameState state;

    Vector3 SP;

    public float speed = 0.1f;

    float timer = 2f;
    public bool direction = true;

    bool inicialPos = true;


    // Start is called before the first frame update
    void Start()
    {
        state = gameState.patrolling;
        SP = this.transform.position;
        target = GameObject.FindWithTag("Target");
    }

    // Update is called once per frame
    void Update()
    {
        verifyState();

        switch (state)
        {
            case gameState.patrolling:
                patrol();
                break;

            case gameState.chasing:
                followPlayer();
                break;

            case gameState.returning:
                goBack();
                break;

            default:
                patrol();
                break;
        }
    }

    void goBack()
    {
        if (inicialPos == false)
        {
            if (Vector3.Distance(transform.position, SP) >= 0.2f)
            {
                transform.position = Vector3.MoveTowards(transform.position, SP, speed * Time.deltaTime);
            }
            else
                inicialPos = true;
        }
    }

    void followPlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
        //Debug.Log("Follow");
        if (inicialPos == true)
        {
            inicialPos = false;
        }
    }

    void patrol()
    {
            if (!direction)
                transform.Translate(0.0f, 0.0f, 0.05f);

            if (direction)
                transform.Translate(-0.0f, -0.0f, -0.05f);

            if (timer >= 2)
            {
                direction = !direction;
                timer = 0;
            }

            timer += Time.deltaTime;    
    }

    void verifyState()
    {
        if (Vector3.Distance(target.transform.position, transform.position) < 10f)
        {
            state = gameState.chasing;
        }
        else
        {
            if (inicialPos == true)
            {
                state = gameState.patrolling;
            }
            else
            {
                if (inicialPos == false)
                {
                    state = gameState.returning;
                }
            }


        }
    }
}
