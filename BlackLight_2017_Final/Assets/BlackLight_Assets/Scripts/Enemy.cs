﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour {

    public float m_fHealth;
    public float m_fDamage;
    public float f_Stunned = 3.0f;

    private Transform Target;
    private NavMeshAgent nav;
    private bool m_bIsDead;
    bool IsStunned = false;

    PlayerHealth PlayerHealth;
    GameObject Player;

	// Use this for initialization
	void Awake ()
    {
        m_fHealth = 50;
        m_fDamage = 15;

		Target = GameObject.FindGameObjectWithTag("Player").transform;
        nav = GetComponent<NavMeshAgent>();
        Player = GameObject.FindGameObjectWithTag("Player");
		PlayerHealth = Player.GetComponent<PlayerHealth>();
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (IsStunned == true)
        {
            nav.enabled = false;
            GetComponent<Renderer>().material.color = Color.yellow;
            f_Stunned -= Time.deltaTime;
        }
        // once the timer hits 0 speed is restored 
        if (f_Stunned <= 0)
        {
            IsStunned = false;
            nav.enabled = true;
            GetComponent<Renderer>().material.color = Color.red;

            f_Stunned += 3.0f;
        }
    //   if (PlayerHealth.m_bIsDead)
	//	{
	//	}
	//	else
	//	{
	//		nav.SetDestination(Target.position);
	//	}
	}
    
    void OnCollisionEnter(Collision col)
    {
		if (col.gameObject.tag == "Player")
        {
			DoDamage();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            IsStunned = true;
        }
    }
    private void DoDamage()
    {
		Debug.Log("HitPlayer");
        if(PlayerHealth.m_fHealth > 0)
        {
            PlayerHealth.TakeDamage(m_fDamage);
		}
    }

    public void TakeDamage(float fDamage)
    {
        if (m_bIsDead)
            return;

        m_fHealth -= fDamage;

        if (m_fHealth <= 0)
        {
            Death();
        }
    }

    private void Death()
    {
        m_bIsDead = true;

        Destroy(gameObject);
    }
}