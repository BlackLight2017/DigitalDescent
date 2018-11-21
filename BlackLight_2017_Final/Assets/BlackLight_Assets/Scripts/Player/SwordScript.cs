//----------------------------------------------------------------------------------------------------
// AUTHOR: Gabriel Pilakis 
// EDITED BY: Jeremy Zoitas
//----------------------------------------------------------------------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;
public class SwordScript : MonoBehaviour
{
    //----------------------------------------------------------------------------------------------------
    // Sets up references to other objects and creates variables
    //----------------------------------------------------------------------------------------------------
    // Trail of the Sword
    public TrailRenderer Trails;
    // References the Enemy Script
    public Enemy EnemyScript;
    // References the RangedEnemy Script
    public RangedEnemy RangedEnemyScript;
    // Sound Effect of Sword
    public AudioSource swingsound;
    public GameObject Sword;
    // the damage of the sword 
    public float fDamage = 15.0f;
    // Timer for the countdown of the player attack 
    public float m_fAttackTimer;
    // How long until the player can attack again 
    public float m_fCoolDownTime;

    public bool m_bAttacking = false;
    public bool m_bRangedAttacking = false;

	// Checks to see if the Player is doing Damage 
	private bool m_bDamage = false;

    private bool isAttacking = false;
    //----------------------------------------------------------------------------------------------------
    // FixedUpdate is called once per frame, this function allows the player to attack using the xboxcontroller.
    // When the player attacks an enemy, the enemy takes damage. 
    //----------------------------------------------------------------------------------------------------
    private void FixedUpdate()
    {
		// the attacktime is deducted by delta time 
		m_fAttackTimer += Time.deltaTime;
     
        if (XCI.GetButtonDown(XboxButton.X) || Input.GetKeyDown(KeyCode.Mouse0))
        {
          // Plays Sword SoundEffect 
              swingsound.Play();

            // when the attack time is zero the player can attack 
            if (m_bAttacking && m_fAttackTimer >= m_fCoolDownTime)
            {
                // If damage has been done 
				if (m_bDamage)
				{
					// Stop doing damage
					m_bDamage = false;

				}
            }
            // when the attack time is zero the player can attack 
            if (m_bRangedAttacking && m_fAttackTimer >= m_fCoolDownTime)
            {
                // If damage has been done 
                if (m_bDamage)
				{
                    // Stop doing damage
                    m_bDamage = false;
				}
			
            }

        }

    }
  
    //----------------------------------------------------------------------------------------------------
    // OnTriggerEnter checks if the player is collided with another gameobject, if enemies exist in the game
    // the player can collide and do damage to the enemies. 
    //----------------------------------------------------------------------------------------------------
    private void OnTriggerStay(Collider other)
    {
        // checks if colliding object has an enemy script or ranged enemyscript
        EnemyScript = other.GetComponent<Enemy>();
        if (EnemyScript != null)
        {
            // if the player hits the enemy is logged
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

}
