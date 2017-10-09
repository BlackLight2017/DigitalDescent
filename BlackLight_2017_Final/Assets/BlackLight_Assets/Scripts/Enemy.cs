using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour {

    [Header("Stats")]
    public float m_fHealth = 50.0f;
    public float m_fDamage = 15.0f;
    public float f_Stunned = 3.0f;
    private float dist;
    float damping = 2;

    [Header("Animations")]
    public Animation Idle;
    public Animation Run;
    public Animation Attack;
    public Animation Die;

    private Transform Target;
    private NavMeshAgent nav;
    private bool m_bIsDead;
    private bool IsStunned = false;
    private float m_fTimer;
    private bool Attacking;

    PlayerController PlayerCon;
    PlayerHealth PlayerHealth;
    GameObject Player;

	// Use this for initialization
	void Awake ()
    {
		Target = GameObject.FindGameObjectWithTag("Player").transform;
        nav = GetComponent<NavMeshAgent>();
        Player = GameObject.FindGameObjectWithTag("Player");
		PlayerHealth = Player.GetComponent<PlayerHealth>();
        PlayerCon = Player.GetComponent<PlayerController>();
        m_fTimer = 0;
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        dist = Vector3.Distance(transform.position, Target.position);
        m_fTimer += Time.deltaTime;
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
            m_fDamage = 15;

            nav.enabled = true;
            GetComponent<Renderer>().material.color = Color.red;

            f_Stunned += 3.0f;
        }
        if (dist > 15)
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
            if (nav.isOnNavMesh)
                nav.SetDestination(Target.position);
            if(Attacking)
            {
                if (m_fTimer >= 1)
                {
                    DoDamage();
                    m_fTimer = 0;
                }
            }            
        }
	}
    
  //  void OnCollisionEnter(Collision col)
  //  {
		//if (col.gameObject.tag == "Player")
  //      {
		//	DoDamage();
  //      }
  //  }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && PlayerCon.m_bDashing == true)
        {
            IsStunned = true;
        }
        if (other.gameObject.tag == "Player")
        {
            Attacking = true;
        }

        //  if (GetComponent<PlayerController>().Dashing == true)
        //  {
        //      gameObject.GetComponent<BoxCollider>().isTrigger = true; 
        //  }
        //  else
        //  {
        //      gameObject.GetComponent<BoxCollider>().isTrigger = false;
        //
        //  }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Attacking = false;
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
        gameObject.SetActive(false);
        //Destroy(gameObject);
    }
}
