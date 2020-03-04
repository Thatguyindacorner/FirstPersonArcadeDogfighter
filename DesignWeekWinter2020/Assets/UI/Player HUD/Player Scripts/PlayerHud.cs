using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerHud : MonoBehaviour
{

    //Player health components
    public float playerMaxHealth;
    public float playerCurrentHealth;
    public Image playerHealthBarFilled;
    //public Image playerHealthBarEmpty;


    //Player weapon cooldown
    public float weapOverheatMax;
    public float weapCurrentOverheat;
    public Image weapOverheatFilled;

    //Player special move components 
    //**MAYBE**
  /*public Image barrelRollCoolDownFilled;
    public Image barrelRollCoolDownEmpty;*/

   
  
    // Update is called once per frame
    void Update()
    {
       playerHealthBarFilled.fillAmount = playerCurrentHealth / playerMaxHealth;
        if (playerCurrentHealth < 0)
        {
            Destroy(this.gameObject);
        }
        weapOverheatFilled.fillAmount = weapCurrentOverheat / weapOverheatMax;
        if(weapCurrentOverheat > 1)
        {
            //When weapon bar reaches max, then set timer to prevent player from shooting current weapon. 
        }
    }

    public void TakeDamage (int damage)
    {
        playerMaxHealth -= damage; 
    }
}
