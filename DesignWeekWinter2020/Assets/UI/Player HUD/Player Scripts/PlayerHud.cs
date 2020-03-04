using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerHud : MonoBehaviour
{

    //Player health components
    public float playerMaxHealth = 5;
    public float playerCurrentHealth;
    public Image playerHealthBarFilled;
    //public Image playerHealthBarEmpty;

    public GameObject player;

    //Player weapon cooldown
    public float weapOverheatMax;
    public float weapCurrentOverheat;
    public Image weapOverheatFilled;

    //Player special move components 
    //**MAYBE**
    /*public Image barrelRollCoolDownFilled;
      public Image barrelRollCoolDownEmpty;*/

    private void Start()
    {
        playerCurrentHealth = player.GetComponent<Fly>().health;

        weapOverheatMax = 20;
        weapCurrentOverheat = player.GetComponent<Weapon>().coolDown;
    }

    // Update is called once per frame
    void Update()
    {
        playerCurrentHealth = player.GetComponent<Fly>().health;
        weapCurrentOverheat = player.GetComponent<Weapon>().coolDown;

        playerHealthBarFilled.fillAmount = playerCurrentHealth / playerMaxHealth;
        if (playerCurrentHealth <= 0)
        {
            Destroy(this.gameObject);
        }
        weapOverheatFilled.fillAmount = weapCurrentOverheat / weapOverheatMax;
    }

    public void TakeDamage (int damage)
    {
        playerMaxHealth -= damage; 
    }
}
