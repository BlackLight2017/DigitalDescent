using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput; 
public class SwordTEST : MonoBehaviour
{
    //// Damage of the attack a
    public float fDamage = 15.0f;

    public AudioSource swingsound;

    //// The speed of the animation (cant be used yet)
    // public float fSpeed = 2.0f;

    //// When the enemy is hit they will be knocked back 
    // public float force = 5;
    private void FixedUpdate()
    {
        
      
    }

    
    private void OnTriggerEnter(Collider other)
    {
        //   if (other.gameObject.tag == "Enemy" )//&& (Input.GetKey(KeyCode.F)))
        //   {
        //  if (Input.GetKey(KeyCode.F) )
        //    if (Input.GetAxis("Attack") > 0)
        if (XCI.GetButton(XboxButton.X))
        {

            Enemy EnemyScript = other.GetComponent<Enemy>();
            if (EnemyScript != null)
            {
                Debug.Log("HitEnemy");
                if (EnemyScript.m_fHealth > 0)
                {
                    EnemyScript.TakeDamage(fDamage);
                }
            }

            RangedEnemy RangedEnemyScript = other.GetComponent<RangedEnemy>();
            if (EnemyScript != null)
            {
                Debug.Log("HitEnemy");
                if (RangedEnemyScript.m_fHealth > 0)
                {
                    RangedEnemyScript.TakeDamage(fDamage);
                }
            }

            //// Enemy equals Gameobjects with the tag "Enemy" 
            //GameObject Enemy12 = GameObject.FindGameObjectWithTag("Enemy");
            //// enemy test gets the variables from the EnemyTEST class
            //Enemy enemytest = Enemy12.GetComponent<Enemy>();

            //enemytest.TakeDamage(fDamage);
        }
    
    ///   // Enemy equals Gameobjects with the tag "Enemy" 
    ///   GameObject Enemy12 = GameObject.FindGameObjectWithTag("Enemy");
    ///  // enemy test gets the variables from the EnemyTEST class
    ///  Enemy enemytest = Enemy12.GetComponent<Enemy>();
    ///
    ///  enemytest.TakeDamage(fDamage);
    ///  //   enemy.TakeDamage(fDamage);

    // }
    }
}
////    if (Input.GetKey(KeyCode.F) )
////        {
////
////            // Enemy equals Gameobjects with the tag "Enemy" 
////            GameObject Enemy12 = GameObject.FindGameObjectWithTag("Enemy");
////// enemy test gets the variables from the EnemyTEST class
////Enemy enemytest = Enemy12.GetComponent<Enemy>();
////
////enemytest.TakeDamage(fDamage);
////            //   enemy.TakeDamage(fDamage);
        