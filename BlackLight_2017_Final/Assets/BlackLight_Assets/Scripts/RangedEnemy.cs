using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RangedEnemy : MonoBehaviour {

	public float m_fHealth;
	public float m_fDamage;

	private Transform Target;
	private NavMeshAgent nav;
	private bool m_bIsDead;
	PlayerHealth PlayerHealth;
	GameObject Player;
	float m_fTimer;

	float dist;

	// Use this for initialization
	void Awake()
	{
		m_fHealth = 50;
		m_fDamage = 30;
		m_fTimer = 0;

		Target = GameObject.FindGameObjectWithTag("Player").transform;
		nav = GetComponent<NavMeshAgent>();
		Player = GameObject.FindGameObjectWithTag("Player");
		PlayerHealth = Player.GetComponent<PlayerHealth>();
		
	}

	// Update is called once per frame
	void Update()
	{
		dist = Vector3.Distance(transform.position, Target.position);
		if (PlayerHealth.m_bIsDead)
		{
		}
		else
		{
			if (nav.enabled)
			{
				nav.SetDestination(Target.position);
			}		
		}
		if (dist < 5)
		{
			DoDamage();
			nav.enabled = false;
		}
		else
		{
			nav.enabled = true;
		}
	}

	private void DoDamage()
	{
		m_fTimer += Time.deltaTime;
		Debug.Log("HitPlayer");
		if (PlayerHealth.m_fHealth > 0 && m_fTimer > 2)
		{
			PlayerHealth.TakeDamage(m_fDamage);
			m_fTimer = 0;
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
