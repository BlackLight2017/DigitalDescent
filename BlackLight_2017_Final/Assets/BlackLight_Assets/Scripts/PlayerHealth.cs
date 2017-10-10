using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

    public float m_fHealth;
    public float m_fDamage;
    public bool m_bIsDead = false;
    GameObject RangedEnemy;
    RangedEnemy RangedEnemyScript;


    // Use this for initialization
    void Awake ()
    {
        m_fHealth = 100;
        m_fDamage = 25;

        RangedEnemy = GameObject.FindGameObjectWithTag("RangedEnemy");
        if(RangedEnemy)
            RangedEnemyScript = RangedEnemy.GetComponent<RangedEnemy>();
        //Enemy = GameObject.FindGameObjectWithTag("Enemy");
        //EnemyScript = Enemy.GetComponent<Enemy>();
    }
	
	// Update is called once per frame
	void Update ()
    {

	}

    void OnCollisionEnter(Collision col)
    {
		//Enemy EnemyScript = col.collider.GetComponent<Enemy>();
		//if (EnemyScript != null)
		//{
		//	Debug.Log("HitEnemy");
		//	if (EnemyScript.m_fHealth > 0)
		//	{
		//		EnemyScript.TakeDamage(m_fDamage);
		//	}
		//}
	}

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "EnemyBullet")
        {
            RangedEnemyScript.DoDamage();
        }
        //Enemy EnemyScript = col.GetComponent<Enemy>();
        //if (EnemyScript != null)
        //{
        //	Debug.Log("HitEnemy");
        //	if (EnemyScript.m_fHealth > 0)
        //	{
        //		EnemyScript.TakeDamage(m_fDamage);
        //	}
        //}
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
        //Destroy(gameObject);
    }
}
