﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public int health = 3;
    public int scoreGiven = 100;

    public bool invulnerable = false;
    public bool explosive = false;

    public GameObject explosion;

    public AudioSource explodeSoundEffect;

    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z < player.transform.position.z - 25)
            Destroy(this.gameObject);
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
        Instantiate(explosion, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
        if (explosive)
            Explode();

        else
        {
          
            Destroy(this.gameObject);
        }
    }

    //colliding with bullets
    private void OnTriggerEnter(Collider other)
    {
        if (invulnerable)
            return;

        if (other.GetComponent<Bullet>() != null)
        {
           
            Damage(other.GetComponent<Bullet>().damage);
            Destroy(other.gameObject);
        }
    }

    void Explode()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, 300);
        int i = 0;
        while (i < hitColliders.Length)
        {
            if (hitColliders[i].gameObject.GetComponent<Obstacle>() != null && !hitColliders[i].gameObject.GetComponent<Obstacle>().explosive)
                hitColliders[i].gameObject.GetComponent<Obstacle>().Damage(5);

            i++;
        }

        explodeSoundEffect.Play();
        Destroy(this.gameObject);
    }
}
