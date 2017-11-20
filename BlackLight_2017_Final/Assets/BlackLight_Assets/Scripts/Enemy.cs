using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour {
    //----------------------------------------------------------------------------------------------------
    // Sets up references to other objects and creates variables with Headers
    //----------------------------------------------------------------------------------------------------
    [Header("Stats")]
    public ParticleSystem PunchParticle;
    public float m_fHealth;
    public float m_fDamage;
    public float f_Stunned = 3.0f;
	public float m_fOutOfRange;
	public float m_fStoppingDistance;
    public float ChargePunch; 
    private int dist;
    float damping = 2;

    [Header("Animations")]
    public Animation Idle;
    public Animation Run;
    public Animation Attack;
    public Animation Die;
    Animator anim; 
    private Transform Target;
    private NavMeshAgent nav;
    private bool m_bIsDead;
    private bool IsStunned = false;
    private float m_fTimer;
    private bool Attacking;

    PlayerController PlayerCon;
    PlayerHealth PlayerHealth;
    GameObject Player;
	public GameObject Body;
	public GameObject LeftArm;
	public GameObject RightArm;

	public AudioSource AttackSound;
	public AudioSource DeathSound;

	//----------------------------------------------------------------------------------------------------
	// Use this for initialization
	//----------------------------------------------------------------------------------------------------
	void Awake ()
    {
        // Sets the target position to the players position.
		Target = GameObject.FindGameObjectWithTag("Player").transform;
        // Sets nav to NavMeshAgent.
        nav = GetComponent<NavMeshAgent>();
        // Sets the Player to Player.
        Player = GameObject.FindGameObjectWithTag("Player");
        // Sets PlayerHealth script.
		PlayerHealth = Player.GetComponent<PlayerHealth>();
        // Sets PlayerController script.
        PlayerCon = Player.GetComponent<PlayerController>();
        // Sets Timer to 0.
        m_fTimer = 0;
        anim = GetComponent<Animator>();

	}

    //----------------------------------------------------------------------------------------------------
    // Update is called once per frame, Makes the enemy move to the players position. If they become 
    // stunned then they stop moving and do no damage. If they are to far from the player they wont move.
    // Enemy does damage to the player if they are in range to attack and if the player is not dashing.
    //----------------------------------------------------------------------------------------------------
    void Update ()
    {
        if (!m_bIsDead)
		{
			// Dist equals the distance from the enemy to player.
			dist = (int)Vector3.Distance(transform.position, Target.position);
			// Increases the time.
			m_fTimer += Time.deltaTime;
			if (IsStunned == true)
			{
				// Stops moving.
				nav.enabled = false;
				// Sets damage to 0.
				m_fDamage = 0;
				// Changes colour to it being stunned.
				Body.GetComponent<Renderer>().material.color = Color.yellow;
				LeftArm.GetComponent<Renderer>().material.color = Color.yellow;
				RightArm.GetComponent<Renderer>().material.color = Color.yellow;
				// Counts down the stun timer.
				f_Stunned -= Time.deltaTime;
			}
			// once the timer hits 0 speed is restored 
			if (f_Stunned <= 0)
			{
				// Sets stunned to false.
				IsStunned = false;
				// Sets damage to 15.
				m_fDamage = 15;
				// Starts moving.
				nav.enabled = true;
				// Changes colour again.

				Body.GetComponent<Renderer>().material.color = new Color(0.18f, 0.18f, 0.18f);
				LeftArm.GetComponent<Renderer>().material.color = new Color(0.18f, 0.18f, 0.18f);
				RightArm.GetComponent<Renderer>().material.color = new Color(0.18f, 0.18f, 0.18f);

				// Resets stun timer.
				f_Stunned += 3.0f;
			}
			// If to far from player then stops moving and looks towards the player.
			if (dist > m_fOutOfRange || dist < m_fStoppingDistance)
			{
				Vector3 LookPos = Target.position - transform.position;
				LookPos.y = 0;
				Quaternion Rotation = Quaternion.LookRotation(LookPos);
				transform.rotation = Quaternion.Slerp(transform.rotation, Rotation, Time.deltaTime * damping);
				nav.enabled = false;
			}
			else
			{
				// Continues moving.
				nav.enabled = true;
			}
			// If player is dead do nothing.
			if (PlayerHealth.m_bIsDead)
			{
			}
			else
			{
				// Checks if they are on the NavMesh then move.
				if (nav.isOnNavMesh)
					nav.SetDestination(Target.position);
                // If Attacking is true then attack every second.
                
                if (dist < ChargePunch)
                {
                    if (m_fTimer >= 1)
                    {
                        Debug.Log("Particle is playing");
                        if (!PunchParticle.isPlaying)
                            PunchParticle.Play();
                    }
                }
                //PunchParticle.Stop();
                if (Attacking)
                {
                    PunchParticle.Stop();

                        if (m_fTimer >= 2 && PlayerCon.m_bDashing == false)
                        {
                            //PunchParticle.Stop();
                            DoDamage();
                            m_fTimer = 0;
                        }

                }

            }
		}
		if(m_bIsDead)
		{
            Body.GetComponent<Renderer>().material.color = new Color(1f, 0, 0);
            LeftArm.GetComponent<Renderer>().material.color = new Color(1f, 0, 0);
            RightArm.GetComponent<Renderer>().material.color = new Color(1f, 0, 0);
            //  if (!DeathSound.isPlaying)
            //{
            //	// Sets active false.
            //	gameObject.SetActive(false);
            //}
            gameObject.SetActive(false);

        }

    }


    //----------------------------------------------------------------------------------------------------
    // OnTriggerEnter is called every time it is colliding with another object, Sets attacking to true if
    // the player is being collided with but if dashing is true the enemy becomes stunned.
    //
    // Param: 
    //      Other: Is the object that is being collided with.
    //----------------------------------------------------------------------------------------------------
    private void OnTriggerEnter(Collider other)
    {
        // Checks  if the player is dashing through them if so then they become stunned.
        if (other.gameObject.tag == "Player" && PlayerCon.m_bDashing == true)
        {
            IsStunned = true;
        }
        // Checks if the player is colliding with them if so then attacking equals true.
        if (other.gameObject.tag == "Player")
        {
            Attacking = true;
        }
    }

    //----------------------------------------------------------------------------------------------------
    // OnTriggerExit is called every time it exits collision with another object, Sets attacking to false.
    // 
    // Param: 
    //      Other: Is the object that is being collided with.
    //----------------------------------------------------------------------------------------------------
    private void OnTriggerExit(Collider other)
    {
        // Checks if the player is colliding with them if so then attacking equals false.
        if (other.gameObject.tag == "Player")
        {
            Attacking = false;
        }
    }

    //----------------------------------------------------------------------------------------------------
    // Deals damage to the player.
    //----------------------------------------------------------------------------------------------------
    private void DoDamage()
    {
        // Prints out a message to see if it hits
		Debug.Log("HitPlayer");
        
        // If the player has health then attack.
        if(PlayerHealth.m_fHealth > 0)
        {
            // Does damage to the player.
            PlayerHealth.TakeDamage(m_fDamage);
		}
		AttackSound.Play();
    }

    //----------------------------------------------------------------------------------------------------
    // Does damage to the enemy if it is not dead.
    // 
    // Param: 
    //      fDamage: Is the amount of damage to be dealt to the enemy.
    //----------------------------------------------------------------------------------------------------
    public void TakeDamage(float fDamage)
    {
        // If they are dead then do nothing.
        if (m_bIsDead)
            return;
        // Takes damage
        m_fHealth -= fDamage;
        // If their health is 0 or less then call death.
        if (m_fHealth <= 0)
        {
            Death();
        }
    }

    //----------------------------------------------------------------------------------------------------
    // Sets enemy active to false and makes the enemy dissapear.
    //----------------------------------------------------------------------------------------------------
    private void Death()
    {
		DeathSound.Play();
		// Sets dead true.
		m_bIsDead = true; 
    }
}
