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
    //public Image playerHealthBarEmpty;
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

        weapOverheatMax = 20;
        weapCurrentOverheat = player.GetComponent<Weapon>().coolDown;
    }

    // Update is called once per frame
    void Update()
    {
        float retX = player.GetComponent<Weapon>().aimX;
        float retY = player.GetComponent<Weapon>().aimY;

        //Debug.Log(player.GetComponent<Weapon>().aimX);
        //Debug.Log(retX * 100);

        reticle.transform.position = new Vector3(retX * 100, retY * 200, transform.position.z);

        playerCurrentHealth = player.GetComponent<Fly>().health;
        weapCurrentOverheat = player.GetComponent<Weapon>().coolDown;

        playerHealthBarFilled.fillAmount = playerCurrentHealth / playerMaxHealth;

        if (playerCurrentHealth <= 0)
            Destroy(this.gameObject);

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
