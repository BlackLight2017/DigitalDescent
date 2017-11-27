//----------------------------------------------------------------------------------------------------
// AUTHOR: Jeremy Zoitas.
// EDITED BY: Gabriel Pilakis.
//----------------------------------------------------------------------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayerHealth : MonoBehaviour {
    //----------------------------------------------------------------------------------------------------
    // Sets up references to other objects and variables.
    //----------------------------------------------------------------------------------------------------
    public ParticleSystem Damage; 

    public float m_fHealth;
    public float m_fDamage;
    public float HealthRegen; 
    public bool m_bIsDead = false;
	//public Canvas DeathCanvas;
	//public GameObject Restart;
	//public GameObject Exit;
	GameObject RangedEnemy;
    RangedEnemy RangedEnemyScript;
	public Image LeftHealthBar;
    public Image RightHealthBar;
    private PlayerController playercon;
    //public EventSystem ES;

    //----------------------------------------------------------------------------------------------------
    // Use this for initialization.
    //----------------------------------------------------------------------------------------------------
    void Awake ()
    {
		// Gets the ranged enemy and the script.
        RangedEnemy = GameObject.FindGameObjectWithTag("RangedEnemy");
        if(RangedEnemy)
            RangedEnemyScript = RangedEnemy.GetComponent<RangedEnemy>();
		// Gets the player controller script.
		playercon = GetComponent<PlayerController> ();
		// Sets DeathCanvas to false.
		//DeathCanvas.enabled = false;
		//// Sets Restart SetActive to false.
		//Restart.SetActive(false);
		//// Sets Exit SetActive to false.
		//Exit.SetActive(false);
	}

	//----------------------------------------------------------------------------------------------------
	// Update is called once per frame, Adjusts the health canvas to the players health.
	//----------------------------------------------------------------------------------------------------
	void Update ()
    {
		// Creates a temp variable.
		float fHealth = m_fHealth;
		// Sets the temp variable to 0-1 so it can be used with fillAmount.
		 fHealth = fHealth / 100.0f;
		// Changes the health canvas if it exists.
		if(LeftHealthBar)
			LeftHealthBar.fillAmount = fHealth;
		// Changes the health canvas if it exists.
		if (RightHealthBar)
			RightHealthBar.fillAmount = fHealth;
    }

	//----------------------------------------------------------------------------------------------------
	// OnTriggerStay is called every time it is colliding with another object, if the player is colliding
	// with the bullet when not dashing they take damage or if they run into a health box it heals them.
	//
	// Param: 
	//      Other: Is the object that is being collided with.
	//----------------------------------------------------------------------------------------------------
	private void OnCollisionEnter(Collision col)
    {
		// checks if the bullet hits the player when they are not dashing and does damage.
        if (col.gameObject.tag == "EnemyBullet" && playercon.m_bDashing == false)
        {
            TakeDamage(RangedEnemyScript.m_fDamage);
			Destroy(col.gameObject);
		}
		// checks if the player runs into the health box and healths them.
        if (col.gameObject.tag == "Regen" && m_fHealth < 90)
        {
            m_fHealth += HealthRegen / 2;
            Destroy(col.gameObject); 
        }
    }

	//----------------------------------------------------------------------------------------------------
	// Does damage to the enemy if it is not dead.
	// 
	// Param: 
	//      fDamage: Is the amount of damage to be dealt to the Player.
	//----------------------------------------------------------------------------------------------------
	public void TakeDamage(float fDamage)
    {
		// if the player is dead do nothing.
        if (m_bIsDead)
            return;
		// plays damage sound if damage is dealt.
        float currentHealth = m_fHealth;
        m_fHealth -= fDamage;
        if (m_fHealth < currentHealth)
            Damage.Play();
      
		// if the health is lower then 0 then the player dies.
        if (m_fHealth <= 0) 
            Death();
    }

	//----------------------------------------------------------------------------------------------------
	// Sets Player active to false and makes the Player dissapear and restart the level.
	//----------------------------------------------------------------------------------------------------
	private void Death()
    {
		//// sets timeScale to 0.
		//Time.timeScale = 0;
		// sets dead to true.
		m_bIsDead = true;
		//Debug.Log("PlayerDead");
		// sets gameObject SetActive to false.
		gameObject.SetActive(false);
		//// sets DeathCanvas to true.
		//DeathCanvas.enabled = true;
		//// sets Restart SetActive to true.
		//Restart.SetActive(true);
		//// sets Exit SetActive to true.
		//Exit.SetActive(true);
		
		//// sets SetSelectedGameObject to Restart.
		//ES.SetSelectedGameObject(Restart);
		
	}
}
