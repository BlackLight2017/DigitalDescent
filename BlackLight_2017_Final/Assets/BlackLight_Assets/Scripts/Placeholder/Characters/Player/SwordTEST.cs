using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordTEST : MonoBehaviour
{
    //// Damage of the attack a
    public float fDamage = 15.0f;
  
    

    //// The speed of the animation (cant be used yet)
    // public float fSpeed = 2.0f;

    //// When the enemy is hit they will be knocked back 
    // public float force = 5;
    private void start()
    {
    
    }

    private void OnTriggerEnter(Collider other)
    {
       
        // Enemy equals Gameobjects with the tag "Enemy" 
        GameObject Enemy12 = GameObject.FindGameObjectWithTag("Enemy");
        // enemy test gets the variables from the EnemyTEST class
        Enemy enemytest = Enemy12.GetComponent<Enemy>();
        //Enemy health is taken away from the amount of damage done
        // Enemy equals Gameobjects with the tag "Enemy" 
      //  GameObject Enemy21 = GameObject.FindGameObjectWithTag("RangedEnemy");
        // enemy test gets the variables from the EnemyTEST class
        //RangedEnemy enemy = Enemy21.GetComponent<RangedEnemy>();
        //Enemy health is taken away from the amount of damage done
        enemytest.TakeDamage(fDamage);
    //   enemy.TakeDamage(fDamage);

    }
}
//private void OnCollisionEnter(Collider other)
//{
//    // Enemy equals Gameobjects with the tag "Enemy" 
//    if (other.gameObject.tag == "Enemy")
//    {
//        GameObject Enemy = GameObject.FindGameObjectWithTag("Enemy");
//
//        // enemy test gets the variables from the EnemyTEST class
//        EnemyTEST enemytest = Enemy.GetComponent<EnemyTEST>();
//        //Enemy health is taken away from the amount of damage done
//        enemytest.fHealth -= fDamage;
//    }
//}