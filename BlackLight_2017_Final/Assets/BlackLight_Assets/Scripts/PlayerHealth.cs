﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

    public float m_fHealth;
    public float m_fDamage;
    private Transform Target;
    public bool m_bIsDead = false;
    // Enemy EnemyScript;
    //GameObject Enemy;

    // Use this for initialization
    void Awake ()
    {
        m_fHealth = 100;
        m_fDamage = 25;

        //Enemy = GameObject.FindGameObjectWithTag("Enemy");
        //EnemyScript = Enemy.GetComponent<Enemy>();
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void OnCollisionEnter(Collision col)
    {
		Enemy EnemyScript = col.collider.GetComponent<Enemy>();
		if (EnemyScript != null)
		{
			Debug.Log("HitEnemy");
			if (EnemyScript.m_fHealth > 0)
			{
				EnemyScript.TakeDamage(m_fDamage);
			}
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
        Destroy(gameObject);
    }
}
