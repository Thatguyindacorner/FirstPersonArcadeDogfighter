using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerHud : MonoBehaviour
{

    public static PlayerHud Instance;
    //Player health components
    public float playerMaxHealth = 5;
    public float playerCurrentHealth;
    public Image playerHealthBarFilled;
    public float healthRegen;

    public float playerHitTime;
    public Image playerDamaged;
    public Color m_startColor, m_endColor;

    public GameObject player;
    public GameObject reticle;

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
        Instance = this;
        playerCurrentHealth = player.GetComponent<Fly>().health;
        healthRegen = 1f;

        weapOverheatMax = 25;
        weapCurrentOverheat = player.GetComponent<Weapon>().coolDown;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        print(playerCurrentHealth);
        playerCurrentHealth = player.GetComponent<Fly>().health;
        weapCurrentOverheat = player.GetComponent<Weapon>().coolDown;

        playerHealthBarFilled.fillAmount = playerCurrentHealth / playerMaxHealth;

        //When the player takes damage, begin to regenerate health
     /*   if(playerCurrentHealth < 5)
        {
           //playerHealthBarFilled.fillAmount = playerCurrentHealth + healthRegen * Time.deltaTime;
           playerCurrentHealth += (healthRegen * Time.deltaTime);
        }*/

        if (playerCurrentHealth <= 0)
        {
            Destroy(this.gameObject);
        }

        weapOverheatFilled.fillAmount = weapCurrentOverheat / weapOverheatMax;
    }

    public void TakeDamage (int damage)
    {
        print("Ouch");
        playerMaxHealth -= damage;
        
    }


    public void UpdateHitUI()
    {
        if (m_hitCoroutine != null)
        {
            StopCoroutine(m_hitCoroutine);
        }
        m_hitCoroutine = StartCoroutine(RedScreen());
    }
    private Coroutine m_hitCoroutine;
    private IEnumerator RedScreen()
    {
        playerDamaged.color = m_startColor;
        float timer = 0;
        while(timer < playerHitTime)
        {
            playerDamaged.color = Color.Lerp(m_startColor, m_endColor, timer / playerHitTime);
            timer += Time.deltaTime;
            yield return null;

        }
        playerDamaged.color = m_endColor;
    }
}
