using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTEST : MonoBehaviour
{
    // References the Playerclass 
    private PlayerController player;
    // speed of enemy 
    public float f_Speed;
    // Renderer that changes the color of the enemy stunned 
    private Renderer Render; 
    //Stun Timer 
    public float f_Stunned = 3.0f;

    Rigidbody rb; 
    public float fHealth = 100; 
    bool IsStunned = false;
    // Use this for initialization
    void Start()
    {
        // the word 'player' is used to refernece player class 
        player = GameObject.FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        // Enemy goes to player position 
        Vector3 dirtoplayer;
        dirtoplayer = player.transform.position - this.transform.position;
        dirtoplayer.Normalize();

        transform.position += dirtoplayer * f_Speed * Time.deltaTime;
        // if stun equals true speed is 0 and timer counts down 
        if (IsStunned == true)
        {
            f_Speed = 0;
            f_Stunned -= Time.deltaTime;
        }
        // once the timer hits 0 speed is restored 
        if (f_Stunned <= 0)
        {
            IsStunned = false;
            f_Speed = 5; 

            f_Stunned += 3.0f;
        }

    }
    // when the enemy collides with a bullet isStunned is equal true stunning the enemy 
   
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {

            IsStunned = true;

        }
    
    }
   
     

    
}
