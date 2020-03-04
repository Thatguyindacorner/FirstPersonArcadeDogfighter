using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : MonoBehaviour
{
    public int health = 1;
    public int score = 100;
    private float speed = 5.0f;

    private GameObject player1;
    private GameObject player2;

    private bool player1LockOn = false;
    private bool player2LockOn = false;

    private BoxCollider _bounds;

    enum State
    {
        SEEKING = 0,    //looking for player
        PURSUIT,        //locked onto a player
        ATTACK,         //shooting at player
    };

    private State state;

    // Start is called before the first frame update
    void Start()
    {
        _bounds = GetComponent<BoxCollider>();

        player1 = GameObject.Find("Player 1");
        player2 = null;

        state = State.SEEKING;
    }

    // Update is called once per frame
    void Update()
    {
        if (state == State.SEEKING)
        {
            //TODO: Create a cone model that can be used to check if the player is within the ship's cone of vision.
            //This will lead to the pursuit state. For now, a simple distance check

            //TODO: if the enemy locks on to a player, forget about the other

            if (Vector3.Distance(transform.position, player1.transform.position) <= 100)
            {
                state = State.PURSUIT;
                player1LockOn = true;
            }
        }

        else if (state == State.PURSUIT)
        {
            if (player1LockOn)
            {
                Vector3 dist = player1.transform.position - transform.position;
                float dot = Vector3.Dot(dist, transform.forward);

                //player is pretty head-on, don't rotate
                if (dot > 0.9)
                {
                    state = State.ATTACK;
                }

                else
                {
                    Quaternion rot = Quaternion.LookRotation(player1.transform.position - transform.position);
                    transform.rotation = Quaternion.Lerp(transform.rotation, rot, 3.0f * Time.deltaTime);

                    transform.Translate(Vector3.forward * speed * Time.deltaTime);
                }
            }

            else if (player2LockOn)
            {

            }
        }

        else //move forward and START BLASTING
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);

            Debug.Log("BLASTING");

            if (player1LockOn)
            {
                Vector3 dist = player1.transform.position - transform.position;
                float dot = Vector3.Dot(dist, transform.forward);

                //player is pretty head-on, don't rotate
                if (dot < 0.5)
                {
                    state = State.SEEKING;
                    Debug.Log("Lost sight :(");
                }
            }
        }
    }

    public void Damage(int amt)
    {
        Debug.Log("Damaging");
        health -= amt;

        if (health <= 0)
            Die();
    }

    void Die()
    {
        Destroy(this.gameObject);
    }

    //colliding with bullets
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Bullet>() != null)
        {
            Damage(other.GetComponent<Bullet>().damage);
            Destroy(other.gameObject);
        }

    }
}
