using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public int health = 3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
