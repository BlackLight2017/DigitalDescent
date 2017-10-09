using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput; 
public class SwordTEST : MonoBehaviour
{
    //// Damage of the attack a
    public float fDamage = 15.0f;
    public float m_fAttackTime = 1.0f;
    public AudioSource swingsound;

    private bool Attacking = false;
    private bool RangedAttacking = false;
    Enemy EnemyScript;
    RangedEnemy RangedEnemyScript;

    //// The speed of the animation (cant be used yet)
    // public float fSpeed = 2.0f;

    //// When the enemy is hit they will be knocked back 
    // public float force = 5;
    private void FixedUpdate()
    {
        m_fAttackTime -= Time.deltaTime;
        if (XCI.GetButton(XboxButton.X))
        {
            if (Attacking && m_fAttackTime <= 0)
            {
                EnemyScript.TakeDamage(fDamage);
                m_fAttackTime = 1;
            }
            if (RangedAttacking && m_fAttackTime <= 0)
            {
                RangedEnemyScript.TakeDamage(fDamage);
                m_fAttackTime = 1;
            }
            


        }
    }


    private void OnTriggerEnter(Collider other)
    {

        

        EnemyScript = other.GetComponent<Enemy>();
        if (EnemyScript != null)
        {
            Debug.Log("HitEnemy");
            if (EnemyScript.m_fHealth > 0)
            {
                Attacking = true;
            }
            else
                Attacking = false;
        }
        else
            Attacking = false;

        RangedEnemyScript = other.GetComponent<RangedEnemy>();
        if (EnemyScript != null)
        {
            Debug.Log("HitEnemy");
            if (RangedEnemyScript.m_fHealth > 0)
            {
                RangedAttacking = true;
            }
            else
                RangedAttacking = false;
        }
        else
            RangedAttacking = false;

        
    
  
    }
}
