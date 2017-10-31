using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {
	//----------------------------------------------------------------------------------------------------
	// Sets up references to other objects and variables.
	//----------------------------------------------------------------------------------------------------
	public float m_fHealth;
    public float m_fDamage;
    public float HealthRegen; 
    public bool m_bIsDead = false;
    GameObject RangedEnemy;
    RangedEnemy RangedEnemyScript;
	public Image LeftHealthBar;
    public Image RightHealthBar;
    private PlayerController playercon;

	//----------------------------------------------------------------------------------------------------
	// Use this for initialization.
	//----------------------------------------------------------------------------------------------------
	void Awake ()
    {
        RangedEnemy = GameObject.FindGameObjectWithTag("RangedEnemy");
        if(RangedEnemy)
            RangedEnemyScript = RangedEnemy.GetComponent<RangedEnemy>();
		playercon = GetComponent<PlayerController> ();		
    }

	//----------------------------------------------------------------------------------------------------
	// Update is called once per frame,
	//----------------------------------------------------------------------------------------------------
	void Update ()
    {
		float fHealth = m_fHealth;
		 fHealth = fHealth / 100.0f;
		if(LeftHealthBar)
			LeftHealthBar.fillAmount = fHealth;
		if (RightHealthBar)
			RightHealthBar.fillAmount = fHealth;
    }

	//----------------------------------------------------------------------------------------------------
	// OnTriggerEnter is called every time it is colliding with another object,
	//
	// Param: 
	//      Other: Is the object that is being collided with.
	//----------------------------------------------------------------------------------------------------
	private void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "EnemyBullet" && playercon.m_bDashing == false)
        {
            TakeDamage(RangedEnemyScript.m_fDamage);
        }
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
        if (m_bIsDead)
            return;

        m_fHealth -= fDamage;

        if (m_fHealth <= 0) 
            Death();
    }

	//----------------------------------------------------------------------------------------------------
	// Sets Player active to false and makes the Player dissapear and restart the level.
	//----------------------------------------------------------------------------------------------------
	private void Death()
    {
		m_bIsDead = true;
		Debug.Log("PlayerDead");
        gameObject.SetActive(false);
		SceneManager.LoadScene(1);
    }
}
