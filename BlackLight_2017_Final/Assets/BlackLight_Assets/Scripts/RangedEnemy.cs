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
    PlayerController PlayerCon;
	GameObject Player;
	float m_fTimer;
    float damping = 2;
	float dist;

	// Use this for initialization
	void Awake()
	{
		m_fTimer = 0;
        f_Stunned = 3.0f;
        IsStunned = false;

        Target = GameObject.FindGameObjectWithTag("Player").transform;
		nav = GetComponent<NavMeshAgent>();
		Player = GameObject.FindGameObjectWithTag("Player");
		PlayerHealth = Player.GetComponent<PlayerHealth>();
        PlayerCon = Player.GetComponent<PlayerController>();

    }

	// Update is called once per frame
	void Update()
	{
		dist = Vector3.Distance(transform.position, Target.position);
        if (IsStunned == true)
        {

            nav.enabled = false;
            m_fDamage = 0;
            GetComponent<Renderer>().material.color = Color.yellow;
            f_Stunned -= Time.deltaTime;
        }
        // once the timer hits 0 speed is restored 
        if (f_Stunned <= 0)
        {
            IsStunned = false;
            m_fDamage = 30;

            nav.enabled = true;
            GetComponent<Renderer>().material.color = Color.red;

            f_Stunned += 3.0f;
        }
        if (dist < 5 || dist > 15)
		{
            Vector3 LookPos = Target.position - transform.position;
            LookPos.y = 0;
            Quaternion Rotation = Quaternion.LookRotation(LookPos);
            transform.rotation = Quaternion.Slerp(transform.rotation, Rotation, Time.deltaTime * damping);
			nav.enabled = false;
		}
		else
		{
			nav.enabled = true;
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
        if (other.gameObject.tag == "Player" && PlayerCon.m_bDashing == true)
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
        gameObject.SetActive(false);
        //Destroy(gameObject);
	}
}
