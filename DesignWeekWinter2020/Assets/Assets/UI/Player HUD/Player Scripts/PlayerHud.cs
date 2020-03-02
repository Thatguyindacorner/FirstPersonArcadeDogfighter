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

    public Text ammoCount;
    public Image currentWeapon;

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
    }

    public void TakeDamage (int damage)
    {
        playerMaxHealth -= damage; 
    }
}
