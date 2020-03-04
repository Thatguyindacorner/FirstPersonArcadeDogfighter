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
    public bool onePlayer = true;

    new Camera camera;

    private float lastShot;

    public int coolDown = 0;
    private float lastReplenish;
    private bool coolDownState = false;

    enum weaponType
    {
        SEMI = 0,
        MISSILE
    };

    private weaponType gun = weaponType.SEMI;

    // Start is called before the first frame update
    void Start()
    {
        camera = GameObject.Find("Main Camera").GetComponent<Camera>();
        rightBarrel = GameObject.Find("Right Barrel").transform;
        leftBarrel = GameObject.Find("Left Barrel").transform;

        lastShot = Time.time;
        lastReplenish = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        //check to see if we should fire the weapon
        fireGun();

        if (Input.GetButtonDown("Weapon Switch"))
            switchGun();

        if (Time.time - lastShot > 1)
            replenishAmmo();

        if (coolDown == 20)
            coolDownState = true;

        if (coolDownState)
            replenishAmmo();
    }

    void switchGun()
    {
        if (gun == weaponType.MISSILE)
            gun = weaponType.SEMI;

        else
            gun += 1;
    }

    void fireGun()
    {
        if (coolDownState)
            return;

        //TODO: split SEMI and AUTO if we actually implement auto...
        if (Input.GetButtonDown("Fire1"))
        {
            Vector3 lookPoint = Vector3.one;
            if (onePlayer)
            {
                Ray ray = camera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                    lookPoint = hit.point;
                else
                    lookPoint = ray.GetPoint(1000);
            }

            else
            {
                
            }

            if (_shootLeft)
            {
                if (gun == weaponType.SEMI)
                {
                    GameObject bull = Instantiate(bullet, leftBarrel.position, transform.rotation);
                    bull.transform.LookAt(lookPoint);
                    _shootLeft = false;
                }

                else
                {
                    GameObject bull = Instantiate(missile, leftBarrel.position, transform.rotation);
                    bull.transform.LookAt(lookPoint);
                    _shootLeft = false;
                }
            }

            else
            {
                if (gun == weaponType.SEMI)
                {
                    GameObject bull = Instantiate(bullet, rightBarrel.position, transform.rotation);
                    bull.transform.LookAt(lookPoint);
                    _shootLeft = true;
                }

                else
                {
                    GameObject bull = Instantiate(missile, rightBarrel.position, transform.rotation);
                    bull.transform.LookAt(lookPoint);
                    _shootLeft = true;
                }
            }

            coolDown += 1;
            lastShot = Time.time;
        }

    }

    void replenishAmmo()
    {
        if (Time.time - lastReplenish > 0.25 && coolDown > 0)
        {
            coolDown -= 1;
            lastReplenish = Time.time;
        }

        if (coolDown == 0)
            coolDownState = false;
    }
}

