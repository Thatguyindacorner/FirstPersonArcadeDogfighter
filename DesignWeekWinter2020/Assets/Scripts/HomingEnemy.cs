using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingEnemy : MonoBehaviour
{
    public GameObject player;
    public float speed = 250.0f;
    private bool lockedOn = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player 1");
    }

    // Update is called once per frame
    void Update()
    {
        if (!lockedOn)
        {
            if (Vector3.Distance(transform.position, player.transform.position) <= 1000)
            {
                transform.LookAt(player.transform.position);
                lockedOn = true;
            }
        }

        else
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
