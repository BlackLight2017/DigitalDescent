using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordTEST : MonoBehaviour
{
    //  public Rigidbody Enemy;
    public GameObject Enemy; 
    public static float fDamage = 15.0f;
    public float fSpeed = 2.0f;
    public float force = 5;
    static private float health = 100;
    private void start()
    {
        EnemyTEST.fHealth  = health ;

    }
    // Damage from sword class is doing damage to Enemies in the enemy class 
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            health -= fDamage;

        }
        EnemyTEST.fHealth = health;

    }
}