using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public int health = 3;
    public int scoreGiven = 100;

    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Damage(int amt)
    {
        health -= amt;

        if (health <= 0)
            Die();
    }

    void Die()
    {
        player.GetComponent<Fly>().score += scoreGiven;
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
