using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyCon : MonoBehaviour
{
    [Header("Follow the Player")]
    public float detectionRange;
    public GameObject player;
    private NavMeshAgent navAgent;

    [Header("Health Variables")]
    public float health;
    public float startHealth = 100;

    public float damageAmount;

    public GameObject deathEffect;

    // Use this for initialization
    void Start ()
    {
        health = startHealth;

        player = GameObject.FindGameObjectWithTag("Player");
        navAgent = GetComponent <NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (Vector3.Distance (transform.position, player.transform.position) < detectionRange)
        {
            navAgent.destination = player.transform.position;
        }

        if (health <= 0)
        {
            Instantiate(deathEffect, transform.position, transform.rotation);
            Die();
        }
	}

    public void OnTriggerEnter (Collider other)
    {
        if (other.tag == "Bullet")
        {
            health -= damageAmount;
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
