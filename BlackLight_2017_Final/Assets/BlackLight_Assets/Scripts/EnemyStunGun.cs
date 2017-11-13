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
    private Rigidbody rb;
    // Timer for bullets being shot 
    private float spawn_timer;
    bool CanFire = false;
    bool IsStunned;
    float f_Stunned;
    float m_fDist;
    private Transform Target;
    RangedEnemy RangedEnemy;
    GameObject rangedEnemy;
	AudioSource Audio;
	//----------------------------------------------------------------------------------------------------
	// Use this for initialization
	//----------------------------------------------------------------------------------------------------
	void Start () {
        IsStunned = false;
        rb = GetComponent<Rigidbody>();
        Target = GameObject.FindGameObjectWithTag("Player").transform;
        rangedEnemy = GameObject.FindGameObjectWithTag("RangedEnemy");
        RangedEnemy = rangedEnemy.GetComponent<RangedEnemy>();
		Audio = GetComponent<AudioSource>();
	}

	//----------------------------------------------------------------------------------------------------
	// Update is called once per frame, shoots from a spawn when it is allowed.
	//----------------------------------------------------------------------------------------------------
	void Update () {
        m_fDist = Vector3.Distance(transform.position, Target.position);
        // if canfire equals false the timer counts down and player cannot shoot 
        if (CanFire == false)
            spawn_timer -= Time.deltaTime;
        // if the timer is below 0 player can shoot again 

        if (spawn_timer <= 1.25f)
        {
           // Charge.Play();
            // play particle 
        }

        if (spawn_timer <= 0)
        {
            //stop particle 
            CanFire = true;
        }
   //   
   //     if (spawn_timer <= 0.35f)
   //     {
   //         Charge.Stop();
   //
   //     }
        // if canfire equals ture, distance is less then 5, and stunned is false then shoot,
        if (CanFire == true)
        {
            if (m_fDist < m_fChargeDistance)
            {
                //Charge.Play();
                if (m_fDist < m_fGunRange)
                {
                    if (!IsStunned)
                    {
                        Fire();
                        //Charge.Stop();
                    }
                }
            }
        }
        if (IsStunned == true)
        {
            f_Stunned -= Time.deltaTime;
        }
        // once the timer hits 0 speed is restored 
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
        if (other.gameObject.tag == "Player")
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
