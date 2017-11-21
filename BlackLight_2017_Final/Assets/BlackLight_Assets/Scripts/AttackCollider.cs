using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCollider : MonoBehaviour {

	public Enemy EnemyScript;
	public RangedEnemy RangedEnemyScript;
	public bool m_bAttacking;
	public bool m_bRangedAttacking;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerStay(Collider other)
	{
		// checks if colliding object has an enemy script or ranged enemyscript
		EnemyScript = other.GetComponent<Enemy>();
		if (EnemyScript != null)
		{
			// if the player hits the enemy is logged
			Debug.Log("HitEnemy");
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

		RangedEnemyScript = other.GetComponent<RangedEnemy>();
		if (RangedEnemyScript != null)
		{
			// if the player hits the enemy is logged
			Debug.Log("HitEnemy");
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
	private void OnTriggerExit()
	{
		m_bAttacking = false;
		m_bRangedAttacking = false;
		//EnemyScript = null;
		//RangedEnemyScript = null;
	}
}
