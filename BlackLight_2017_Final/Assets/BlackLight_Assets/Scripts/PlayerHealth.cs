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
	public Canvas DeathCanvas;
	public GameObject Restart;
	public GameObject Exit;
	GameObject RangedEnemy;
    RangedEnemy RangedEnemyScript;
	public Image LeftHealthBar;
    public Image RightHealthBar;
    private PlayerController playercon;
    public EventSystem ES;

    //----------------------------------------------------------------------------------------------------
    // Use this for initialization.
    //----------------------------------------------------------------------------------------------------
    void Awake ()
    {
        RangedEnemy = GameObject.FindGameObjectWithTag("RangedEnemy");
        if(RangedEnemy)
            RangedEnemyScript = RangedEnemy.GetComponent<RangedEnemy>();
		playercon = GetComponent<PlayerController> ();
		DeathCanvas.enabled = false;
		Restart.SetActive(false);
		Exit.SetActive(false);
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

        float currentHealth = m_fHealth;

        m_fHealth -= fDamage;

        if (m_fHealth < currentHealth)
            Damage.Play();

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
		DeathCanvas.enabled = true;
		Restart.SetActive(true);
		Exit.SetActive(true);
        ES.SetSelectedGameObject(Restart);
        Time.timeScale = 0;
    }
}
