﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject bullet;
    public GameObject missile;

    private Transform rightBarrel;
    private Transform leftBarrel;

    private bool _shootLeft = false;

    enum weaponType
    {
        SEMI = 0,
        AUTO,
        MISSILE
    };

    private weaponType gun = weaponType.SEMI;

    // Start is called before the first frame update
    void Start()
    {
        rightBarrel = GameObject.Find("Right Barrel").transform;
        leftBarrel = GameObject.Find("Left Barrel").transform;
    }

    // Update is called once per frame
    void Update()
    {
        //check to see if we should fire the weapon
        fireGun();

        if (Input.GetButtonDown("Weapon Switch"))
            switchGun();
    }

    void switchGun()
    {
        if (gun == weaponType.MISSILE)
            gun = weaponType.SEMI;

        else
            gun += 1;

        Debug.Log(gun);
    }

    void fireGun()
    {
        //TODO: split SEMI and AUTO if we actually implement auto...
        if (Input.GetButtonDown("Fire1"))
        {
            Camera camera = GameObject.Find("Main Camera").GetComponent<Camera>();
            Ray ray = camera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hit;
            Vector3 lookPoint;

            if (Physics.Raycast(ray, out hit))
                lookPoint = hit.point;
            else
                lookPoint = ray.GetPoint(1000);
            
            if (gun == weaponType.SEMI || gun == weaponType.AUTO)
            {
                if (_shootLeft)
                {
                    GameObject bull = Instantiate(bullet, leftBarrel.position, transform.rotation);
                    //bull.GetComponent<Rigidbody>().velocity = ray.direction * bull.GetComponent<Bullet>().speed;
                    bull.transform.LookAt(lookPoint);
                    _shootLeft = false;
                }

                else
                {
                    GameObject bull = Instantiate(bullet, rightBarrel.position, transform.rotation);
                    //bull.GetComponent<Rigidbody>().velocity = bull.GetComponent<Bullet>().speed * ray.direction;
                    bull.transform.LookAt(lookPoint);
                    _shootLeft = true;
                }
            }

            else
                Debug.Log("Insert missile here");
        }

    }
}
