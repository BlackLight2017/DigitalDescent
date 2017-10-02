using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RangedEnemy : MonoBehaviour {

	public float m_fHealth;
	public float m_fDamage;
    public float f_Speed;
    public float f_Stunned;
    public bool IsStunned;

    private Transform Target;
	private NavMeshAgent nav;
	private bool m_bIsDead;


    PlayerHealth PlayerHealth;
 //   EnemyStunGun EnemyStunGun;
	GameObject Player;
	float m_fTimer;

	float dist;

	// Use this for initialization
	void Awake()
	{
		m_fHealth = 50;
		m_fDamage = 30;
		m_fTimer = 0;
        f_Stunned = 3.0f;
        IsStunned = false;

        Target = GameObject.FindGameObjectWithTag("Player").transform;
		nav = GetComponent<NavMeshAgent>();
		Player = GameObject.FindGameObjectWithTag("Player");
		PlayerHealth = Player.GetComponent<PlayerHealth>();
       // EnemyStunGun = GetComponent<EnemyStunGun>();

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
        if (dist < 5 || dist > 15)
		{
            transform.LookAt(Target);
			nav.enabled = false;
		}
		else
		{
			nav.enabled = true;
		}
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
        if (PlayerHealth.m_bIsDead)
        {
        }
        else
        {
            if(nav.isOnNavMesh)
                nav.SetDestination(Target.position);
        }

    }
	//public void DoDamage()

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            IsStunned = true;
        }
    }

    public void DoDamage()
	{
		Debug.Log("HitPlayer");
		if (PlayerHealth.m_fHealth > 0)
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
