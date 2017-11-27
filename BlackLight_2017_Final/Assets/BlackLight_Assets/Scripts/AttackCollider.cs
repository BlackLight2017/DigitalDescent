//----------------------------------------------------------------------------------------------------
// AUTHOR: Jeremy Zoitas.
//----------------------------------------------------------------------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCollider : MonoBehaviour {
	//----------------------------------------------------------------------------------------------------
	// Sets up references to other objects and variables.
	//----------------------------------------------------------------------------------------------------
	public Enemy EnemyScript;
	public RangedEnemy RangedEnemyScript;
	public bool m_bAttacking;
	public bool m_bRangedAttacking;

	//----------------------------------------------------------------------------------------------------
	// Use this for initialization
	//----------------------------------------------------------------------------------------------------
	void Start () {
		
	}

	//----------------------------------------------------------------------------------------------------
	// Update is called once per frame,
	//----------------------------------------------------------------------------------------------------
	void Update () {
		
	}
	//----------------------------------------------------------------------------------------------------
	// OnTriggerStay is called every time it is colliding with another object, and sets attacking to true.
	//
	// Param: 
	//      Other: Is the object that is being collided with.
	//----------------------------------------------------------------------------------------------------
	private void OnTriggerStay(Collider other)
	{
		// checks if colliding object has an enemy script or ranged enemyscript
		EnemyScript = other.GetComponent<Enemy>();
		if (EnemyScript != null)
		{
			// if the player hits the enemy is logged
			//Debug.Log("HitEnemy");
			// if the enemies health is above 0 the player can still attack
			if (EnemyScript.m_fHealth > 0)
			{
				m_bAttacking = true;
			}
			// else the player cannot attack the enemy
			else
				m_bAttacking = false;
		}
		else
			m_bAttacking = false;
		// checks if colliding object has an ranged enemyscript
		RangedEnemyScript = other.GetComponent<RangedEnemy>();
		if (RangedEnemyScript != null)
		{
			// if the player hits the enemy is logged
			//Debug.Log("HitEnemy");
			// if the enemies health is above 0 the player can still attack
			if (RangedEnemyScript.m_fHealth > 0)
			{
				m_bRangedAttacking = true;
			}
			// else the player cannot attack the enemy
			else
				m_bRangedAttacking = false;
		}
		else
			m_bRangedAttacking = false;
	}
	//----------------------------------------------------------------------------------------------------
	// OnTriggerEnter is called every time it exits colliding with another object, makes things false and 
	// null.
	//----------------------------------------------------------------------------------------------------
	private void OnTriggerExit()
	{
		// makes it so the player can not do damage.
		m_bAttacking = false;
		m_bRangedAttacking = false;
		EnemyScript = null;
		RangedEnemyScript = null;
	}
}
