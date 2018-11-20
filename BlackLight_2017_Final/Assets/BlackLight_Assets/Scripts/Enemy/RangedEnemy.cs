//----------------------------------------------------------------------------------------------------
// AUTHOR: Jeremy Zoitas.
// EDITED BY: Gabriel Pilakis.
//----------------------------------------------------------------------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RangedEnemy : MonoBehaviour {
	//----------------------------------------------------------------------------------------------------
	// Sets up references to other objects and creates variables
	//----------------------------------------------------------------------------------------------------
	public float m_fHealth;
	public float m_fDamage;
    public float f_Speed;
    public float f_Stunned;
    public bool IsStunned;
	public float m_fShooting_Distance;
	public float m_fOutOfRange;

    private Transform Target;
	private NavMeshAgent nav;
	private bool m_bIsDead;

    public Material[] BaseMaterial;
    public Material[] TurbineRMaterial;
    public Material[] TurbineLMaterial;
    public Material[] BracketMaterial;
    public Material[] GunMaterial;

    private MeshRenderer Baserend;
    private MeshRenderer TurbineRendR;
    private MeshRenderer TurbineRendL;
    private MeshRenderer BracketRend;
    private MeshRenderer GunRend;

    public GameObject body;
    public GameObject Lturbine;
    public GameObject Rturbine;
    public GameObject bracket;
    public GameObject Gun;

    PlayerHealth PlayerHealth;
    PlayerController PlayerCon;
	GameObject Player;
    public AudioSource DeathSound;

    float damping = 2;
	float dist;

	//----------------------------------------------------------------------------------------------------
	// Use this for initialization
	//----------------------------------------------------------------------------------------------------
	void Awake()
	{
        f_Stunned = 3.0f;
        IsStunned = false;
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

        Baserend = body.GetComponent<MeshRenderer>();
        TurbineRendR = Lturbine.GetComponent<MeshRenderer>();
        TurbineRendL = Rturbine.GetComponent<MeshRenderer>();
        BracketRend = bracket.GetComponent<MeshRenderer>();
        GunRend = Gun.GetComponent<MeshRenderer>();

        Baserend.sharedMaterial = BaseMaterial[0];
        TurbineRendR.sharedMaterial = TurbineRMaterial[0];
        TurbineRendL.sharedMaterial = TurbineLMaterial[0];
        BracketRend.sharedMaterial = BracketMaterial[0];
        GunRend.sharedMaterial = GunMaterial[0];

    }

	//----------------------------------------------------------------------------------------------------
	// Update is called once per frame, Makes the enemy move to the players position. If they become 
	// stunned then they stop moving and do no damage. If they are to far from the player they wont move.
	// Enemy does damage to the player if they are in range to attack and if the player is not dashing.
	//----------------------------------------------------------------------------------------------------
	void Update()
	{
        if (!m_bIsDead)
        {
            // Dist equals the distance from the enemy to player.
            dist = Vector3.Distance(transform.position, Target.position);
            if (IsStunned == true)
            {
                // Stops moving.
                nav.enabled = false;
                // Sets damage to 0.
                m_fDamage = 0;
                // Changes colour to it being stunned.

                Baserend.sharedMaterial = BaseMaterial[1];
                TurbineRendR.sharedMaterial = TurbineRMaterial[1];
                TurbineRendL.sharedMaterial = TurbineLMaterial[1];
                BracketRend.sharedMaterial = BracketMaterial[1];
                GunRend.sharedMaterial = GunMaterial[1];

                // Counts down the stun timer.
                f_Stunned -= Time.deltaTime;
            }
            // once the timer hits 0 speed is restored 
            if (f_Stunned <= 0)
            {
                // Sets stunned to false.
                IsStunned = false;
                // Sets damage to 15.
                m_fDamage = 10;
                // Starts moving.
                nav.enabled = true;
                // Changes colour again.
                Baserend.sharedMaterial = BaseMaterial[0];
                TurbineRendR.sharedMaterial = TurbineRMaterial[0];
                TurbineRendL.sharedMaterial = TurbineLMaterial[0];
                BracketRend.sharedMaterial = BracketMaterial[0];
                GunRend.sharedMaterial = GunMaterial[0];

                // Resets stun timer.
                f_Stunned += 3.0f;
            }
            // If to far from player or close then stops moving and looks towards the player.
            if (dist < m_fShooting_Distance && !IsStunned || dist > m_fOutOfRange && !IsStunned)
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
            }
        }
        if (m_bIsDead)
        {

            Baserend.sharedMaterial = BaseMaterial[2];
            TurbineRendR.sharedMaterial = TurbineRMaterial[2];
            TurbineRendL.sharedMaterial = TurbineLMaterial[2];
            BracketRend.sharedMaterial = BracketMaterial[2];
            GunRend.sharedMaterial = GunMaterial[2];

            if (!DeathSound.isPlaying)
            {

                // Sets active false.
                gameObject.SetActive(false);
            }
        }

    }

	//----------------------------------------------------------------------------------------------------
	// OnTriggerEnter is called every time it is colliding with another object, if the player is being
	// collided with but if dashing is true the enemy becomes stunned.
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
    }

	//----------------------------------------------------------------------------------------------------
	// Deals damage to the player.
	//----------------------------------------------------------------------------------------------------
	public void DoDamage()
	{
		// Prints out a message to see if it hits
		// If the player has health then attack.
		if (PlayerHealth.m_fHealth > 0)
		{
			// Does damage to the player.
			PlayerHealth.TakeDamage(m_fDamage);
		}
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
		// Plays death sound.
        DeathSound.Play();
		// Sets dead true.
		m_bIsDead = true;
        // Turns of the shoot component.
        EnemyStunGun Shoot = GetComponent<EnemyStunGun>();
        Shoot.enabled = false;
	}
}
