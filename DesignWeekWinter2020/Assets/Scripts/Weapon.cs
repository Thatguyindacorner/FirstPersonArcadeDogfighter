using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject bullet;
    public GameObject missile;

    enum weaponType {
        SEMI = 0,
        AUTO,
        MISSILE
    };

    private weaponType gun = weaponType.SEMI;

    // Start is called before the first frame update
    void Start()
    {
        
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
            Quaternion rotation = transform.rotation;

            if (gun == weaponType.SEMI || gun == weaponType.AUTO)
                Instantiate(bullet, transform.position, rotation);
            else
                Debug.Log("Insert missile here");
        }

    }
}
