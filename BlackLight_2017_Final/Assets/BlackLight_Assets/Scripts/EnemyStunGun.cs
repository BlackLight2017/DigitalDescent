//----------------------------------------------------------------------------------------------------
// AUTHOR: Jeremy Zoitas.
// EDITED BY: Gabriel Pilakis.
//----------------------------------------------------------------------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStunGun : MonoBehaviour {
	//----------------------------------------------------------------------------------------------------
	// Sets up references to other objects and creates variables
	//----------------------------------------------------------------------------------------------------
	// access to bullet prefab 
	public GameObject Bullet_prefab;
    public ParticleSystem Charge; 
    // access to bullet spawn 
    public GameObject Bullet_Spawn;
    // how much time between shots 
    public float spawn_time = 1;
    public float m_fChargeTime = 2; 
	public float m_fGunRange;
    public float m_fChargeDistance;
    public float time = 0;
    // Timer for bullets being shot 
    private float spawn_timer;
    bool CanFire = false;
    bool IsStunned;
    float f_Stunned;
    float m_fDist;
    private Transform Target;
    RangedEnemy RangedEnemy;
	public PlayerController PlayerController;
    GameObject rangedEnemy;
	AudioSource Audio;
	//----------------------------------------------------------------------------------------------------
	// Use this for initialization
	//----------------------------------------------------------------------------------------------------
	void Start () {
		// stunned starts false.
        IsStunned = false;
		// sets a target.
        Target = GameObject.FindGameObjectWithTag("Player").transform;
		// gets ranged enemy and the script.
        rangedEnemy = GameObject.FindGameObjectWithTag("RangedEnemy");
        RangedEnemy = rangedEnemy.GetComponent<RangedEnemy>();
		// gets player script
		
		// gets audio source.
		Audio = GetComponent<AudioSource>();
	}

	//----------------------------------------------------------------------------------------------------
	// Update is called once per frame, shoots from a spawn when it is allowed.
	//----------------------------------------------------------------------------------------------------
	void Update () {
        m_fDist = Vector3.Distance(transform.position, Target.position);
        // if canfire equals false the timer counts down and player cannot shoot.
        if (CanFire == false)
            spawn_timer -= Time.deltaTime;
        // if the timer is below 0 player can shoot again.
        if (spawn_timer <= 0)
        {
            CanFire = true;
        }
		// if canfire equals ture, distance is less then m_fChargeDistance, and stunned is false then shoot.
		if (CanFire == true)
        {
            if (m_fDist < m_fChargeDistance)
            {
                if (m_fDist < m_fGunRange)
                {
                    if (!IsStunned)
                    {
                        Fire();
                    }
                }
            }
        }
		// starts stunned cooldown.
        if (IsStunned == true)
        {
            f_Stunned -= Time.deltaTime;
        }
        // once the timer hits 0 speed is restored .
        if (f_Stunned <= 0)
        {
            IsStunned = false;
            f_Stunned += 3.0f;
        }
    }

	//----------------------------------------------------------------------------------------------------
	// OnTriggerEnter is called every time it is colliding with another object, Sets stunned to true.
	//
	// Param: 
	//      Other: Is the object that is being collided with.
	//----------------------------------------------------------------------------------------------------
	private void OnTriggerEnter(Collider other)
    {
        if (PlayerController) { }
        if (other.gameObject.tag == "Player" && PlayerController.m_bDashing)
        {
            IsStunned = true;
        }
    }

	//----------------------------------------------------------------------------------------------------
	// Spawn a bullet and fires it.
	//----------------------------------------------------------------------------------------------------
	public void Fire()
    {
        time += Time.deltaTime;
        Charge.Play();
        if (time >= 1)
        {
            Charge.Stop();
            if (CanFire == true)
            {
                spawn_timer = spawn_time;
                CanFire = false;
                // Instanciate a new Bullet Prefab
                float spawn_angle = Random.Range(0, 2 * Mathf.PI);

                // Bullet wil spawn in direction where player is looking (work in progress) 
                ////Vector3 spawn_direction = new Vector3(Mathf.Sin(spawn_angle), 0, Mathf.Cos(spawn_angle)); 

                // Bullet moves 
                Instantiate(Bullet_prefab, Bullet_Spawn.transform.position, Quaternion.identity);

                Audio.Play();
                time = 0;
            }
        }
    }
}
