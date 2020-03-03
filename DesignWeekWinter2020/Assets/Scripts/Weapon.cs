using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject bullet;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Quaternion rotation = transform.rotation;

            Instantiate(bullet, transform.position, rotation);
        }

        //TODO: Make it so that whenever the weapon switch button is pressed, the bullet variable is set to the next type of bullet prefab
    }
}
