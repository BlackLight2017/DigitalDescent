﻿//----------------------------------------------------------------------------------------------------
// AUTHOR: Gabriel Pilakis 
// EDITED BY: Jeremy Zoitas
//----------------------------------------------------------------------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletTest : MonoBehaviour
{
    private float m_fspawn_time = 5;
    private float m_fspawn_timer = 0;
    public float m_fSpeed = 1.0f;

    GameObject Player;
    PlayerHealth PlayerScripts;
    Vector3 MoveDirection;


    // Use this for initialization
    void Start()
    {
        //m_fspawn_timer = spawn_time;
        Player = GameObject.FindGameObjectWithTag("Player");
        if(Player)
            PlayerScripts = Player.GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        //m_fspawn_timer = spawn_time;
        m_fspawn_timer += Time.deltaTime;
        if(Player)
        {
            if (m_fspawn_timer >= 0 && m_fspawn_timer <= 0.1 && !PlayerScripts.m_bIsDead)
            {
                MoveDirection += (Player.transform.position + Vector3.up * 2.0f) - transform.position;
                MoveDirection.Normalize();
            }
            if (m_fspawn_timer >= 2)
            {
                Destroy(gameObject);
            }
            transform.position += MoveDirection * m_fSpeed * Time.deltaTime;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
		if (other.gameObject.tag == "Player")
		{
		//	//Destroy(gameObject);
		}
		if(other.gameObject.tag == "RangedEnemy" || other.gameObject.tag == "Enemy" || other.gameObject.tag == "Gun" || other.gameObject.tag == "EnemyStunGun" || other.gameObject.tag == "Sword")
		{

		}
		else
		{
			Destroy(gameObject);
		}
    }
}
