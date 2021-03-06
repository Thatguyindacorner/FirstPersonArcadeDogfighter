﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject bullet;
    public GameObject smokeCD;

    public GameObject aim;

    private Transform rightBarrel;
    private Transform leftBarrel;

    private bool _shootLeft = false;
    public bool onePlayer = false;

    public float retMoveRate = 500;

    
    public AudioSource laserSoundEffect;

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
      
       smokeCD.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //check to see if we should fire the weapon
        ControlReticle();
        fireGun();

        //if (Input.GetButtonDown("Weapon Switch"))
            //switchGun();

        if (coolDown == 25)
        {
            smokeCD.SetActive(true);
            coolDownState = true;
        }

        if (coolDownState || Time.time - lastShot > 1)
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

        if (Input.GetButtonDown("Fire1"))
        {
            if (_shootLeft)
            {
                GameObject bull = Instantiate(bullet, leftBarrel.position, transform.rotation);
                bull.transform.LookAt(aim.transform.position);
                _shootLeft = false;
            }

            else
            {
                GameObject bull = Instantiate(bullet, rightBarrel.position, transform.rotation);
                bull.transform.LookAt(aim.transform.position);
                _shootLeft = true;
            }

            coolDown += 1;
            lastShot = Time.time;
            laserSoundEffect.Play();
            
        }

    }

    void ControlReticle()
    {
        if (Input.GetAxis("Horizontal2") < 0) //left
        {
            if (aim.transform.localPosition.x > -640)
                aim.transform.Translate(-retMoveRate * Time.deltaTime, 0, 0);
        }

        else if (Input.GetAxis("Horizontal2") > 0) //right
        {
            if (aim.transform.localPosition.x < 640)
                aim.transform.Translate(retMoveRate * Time.deltaTime, 0, 0);
        }

        if (Input.GetAxis("Vertical2") < 0) //down
        {
            if (aim.transform.localPosition.y > -640)
                aim.transform.Translate(0, -retMoveRate * Time.deltaTime, 0);
        }

        else if (Input.GetAxis("Vertical2") > 0) //up
        {
            if (aim.transform.localPosition.y < 640)
                aim.transform.Translate(0, retMoveRate * Time.deltaTime, 0);
        }
    }

    void replenishAmmo()
    {
        if (Time.time - lastReplenish > 0.15 && coolDown > 0)
        {
            // Instantiate(smokeCD, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            smokeCD.SetActive(true);
            //print("smokeisactive");
            coolDown -= 1;
            lastReplenish = Time.time;
        }

        if (coolDown == 0)
        {
            coolDownState = false;
            smokeCD.SetActive(false);
        }
       // Destroy(smokeCD, 3);

        if (coolDown == 0) { 
            coolDownState = false;
        smokeCD.SetActive(false);
           
        }
    }

    void lockOn()
    {
        int objsLockedOn = 0;
        while (objsLockedOn < 5)
        {

        }
    }
}

