using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;
public class SwordTEST : MonoBehaviour
{
    //----------------------------------------------------------------------------------------------------
    // Sets up references to other objects and creates variables
    //----------------------------------------------------------------------------------------------------
    Enemy EnemyScript;
    RangedEnemy RangedEnemyScript;
    public AudioSource swingsound;
    public GameObject Sword;
    // public Animation SwingWeapon;
    public Material[] material;

    public MeshRenderer rend;
    // the damage of the sword 
    public float fDamage = 15.0f;
    // the amount of time until the sword can attack again
    public float m_fAttackTime = 1.0f;
    public float m_fColorChange = 0.1f;

    private bool m_bSwordColor = false;
    private bool m_bAttacking = false;
    private bool m_bRangedAttacking = false;

    void start()
    {
        rend = gameObject.GetComponent<MeshRenderer>();
        rend.sharedMaterial = material[1]; 
    }
    //----------------------------------------------------------------------------------------------------
    // FixedUpdate is called once per frame, this function allows the player to attack using the xboxcontroller.
    // When the player attacks an enemy, the enemy takes damage. 
    //----------------------------------------------------------------------------------------------------
    private void FixedUpdate()
    {

        ///  Sword.GetComponent<Renderer>().material.color = Color.gray;

        // the attacktime is deducted by delta time 
        m_fAttackTime -= Time.deltaTime;
        //if (Input.GetKeyDown(KeyCode.Mouse0))
        //{
        //    m_bSwordColor = true;

        //}

        if (XCI.GetButtonUp(XboxButton.X) || Input.GetKeyUp(KeyCode.Mouse0))
        {
            m_bSwordColor = true;
            ColorChange();
          //  swingsound.Play();

            //          Sword.GetComponent<Renderer>().material.color = Color.red;
            // when the attack time is zero the player can attack 
            if (m_bAttacking && m_fAttackTime <= 0)
            {

              //  m_bSwordColor = true;
                //   SwingWeapon.Play(); 
                //   enemy takes damage 
                EnemyScript.TakeDamage(fDamage);
                //   one is added to attack time to reset timer
                m_fAttackTime = 1;
            }
            // when the attack time is zero the player can attack 
            if (m_bRangedAttacking && m_fAttackTime <= 0)
            {
         //       m_bSwordColor = true;
           //     Sword.GetComponent<Renderer>().material.color = Color.red;

                // enemy takes damage 
                RangedEnemyScript.TakeDamage(fDamage);
                // one is added to attack time to reset timer
                m_fAttackTime = 1;
            }
        }

        //Sword.GetComponent<Renderer>().material.color = Color.gray;
        if (m_bSwordColor == true)
        {
            ///    Sword.GetComponent<Renderer>().material.color = Color.red;

            rend.sharedMaterial = material[1];
            m_fColorChange -= Time.deltaTime;
        }
        if (m_fColorChange <= 0)
        {
            m_bSwordColor = false;
            ///     Sword.GetComponent<Renderer>().material.color = Color.grey;

            rend.sharedMaterial = material[0];

            m_fColorChange += 0.1f;
        }

    }
    public void ColorChange()
    {
      //if (m_bSwordColor == true)
      //{
      //      /    Sword.GetComponent<Renderer>().material.color = Color.red;

      //          rend.sharedMaterial = material[1];
      //          m_fColorChange -= Time.deltaTime; 
      //}
      if (m_fColorChange <= 0)
      {
                m_bSwordColor = false;
           ///     Sword.GetComponent<Renderer>().material.color = Color.grey;

                rend.sharedMaterial = material[0];

                m_fColorChange += 0.1f;
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
		EnemyScript = null;
		RangedEnemyScript = null;
	}
}
