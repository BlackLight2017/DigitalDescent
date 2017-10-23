using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

    public float m_fHealth;
    public float m_fDamage;
    public bool m_bIsDead = false;
    GameObject RangedEnemy;
    RangedEnemy RangedEnemyScript;
	public Image LeftHealthBar;
    public Image RightHealthBar;
    private PlayerController playercon;

    // Use this for initialization
    void Awake ()
    {

        RangedEnemy = GameObject.FindGameObjectWithTag("RangedEnemy");
        if(RangedEnemy)
            RangedEnemyScript = RangedEnemy.GetComponent<RangedEnemy>();
		playercon = GetComponent<PlayerController> ();		
        //Enemy = GameObject.FindGameObjectWithTag("Enemy");
        //EnemyScript = Enemy.GetComponent<Enemy>();
    }
	
	// Update is called once per frame
	void Update ()
    {
		float fHealth = m_fHealth;
		 fHealth = fHealth / 100.0f;
		if(LeftHealthBar)
			LeftHealthBar.fillAmount = fHealth;
		if (RightHealthBar)
			RightHealthBar.fillAmount = fHealth;
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "EnemyBullet" && playercon.m_bDashing == false)
        {
            //RangedEnemyScript.DoDamage();
            TakeDamage(RangedEnemyScript.m_fDamage);
        }
        if (col.gameObject.tag == "Regen" && m_fHealth < 90)
        {
            m_fHealth += 10;
            Destroy(col.gameObject); 
        }
    }
	
    public void TakeDamage(float fDamage)
    {
        if (m_bIsDead)
            return;

        m_fHealth -= fDamage;

        if (m_fHealth <= 0) 
            Death();
    }

    private void Death()
    {
		m_bIsDead = true;
		Debug.Log("PlayerDead");
        gameObject.SetActive(false);
		SceneManager.LoadScene(1);
        //Destroy(gameObject);
    }
}
