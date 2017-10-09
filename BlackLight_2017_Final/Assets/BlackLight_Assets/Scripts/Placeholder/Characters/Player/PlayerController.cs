using System.Collections;
using System.Collections.Generic;
using XboxCtrlrInput; 

using UnityEngine;


public class PlayerController : MonoBehaviour {
    // public GameObject Bullet_prefab;
    // public GameObject Bullet_Spawn;
    public Animation Idle;
    public Animation Walk;
    public Animation Run;
    public Animation Jump;
    public Animation Dash;
    public Animation SwingWeapon;


    public float m_fVerticalJumpForce;
    public float m_fMovementSpeed;// = 10;
    private Rigidbody rb;
  //  private float spawn_timer;
  //  public float spawn_radius;
  //  public float spawn_time = 1;


    // how long the dash lasts 
    float m_fDashTimer = 0.4f;
    bool m_bGrounded = true;
    public bool m_bDashing = false;

    //cooldown for dash 
    public float m_fDashCooldown = 5;
    // how many dashes the player has 
    public float m_fCurrentDashCount = 0;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        //if the timer goes under 1 
        //Timer goes down 
     m_fDashCooldown -= Time.deltaTime;
    ////  //m_fDashCooldown
      if (m_fDashCooldown <= 1)
          {
    
          m_fCurrentDashCount += 1; 
          {
              // if you have more than 1 dash count then you can dash
    
              if (m_fCurrentDashCount > 0)
              {
                  // Dash is gone 
                  //Adds 5 seconds to the timer 
                  m_fDashCooldown += 5.0f;
              }
    
              //else
              // no m_bDashing
          }
      }
        
        float moveHorizontal = XCI.GetAxis(XboxAxis.LeftStickX);

        transform.position = new Vector3(transform.position.x + (moveHorizontal * m_fMovementSpeed), transform.position.y, transform.position.z);
        
       

        //Vector3 movement = new Vector3(moveHorizontal, 0.0f, 0.0f);
        rb.AddForce(Vector3.down * 10);
        // If left shift is pressed Adds force for the cube to move right
        // If i have a dash avaliable 
        if (XCI.GetButton(XboxButton.LeftBumper) && m_bDashing == false && m_fCurrentDashCount > 0)
        {
            m_bDashing = true;
            rb.AddForce(Vector3.left * 2700);

            m_fCurrentDashCount -= 1;
        }
        if (XCI.GetButton(XboxButton.RightBumper) && m_bDashing == false && m_fCurrentDashCount > 0)
        {
            m_bDashing = true;
            rb.AddForce(Vector3.right * 2700);

            m_fCurrentDashCount -= 1;
        }
        if (m_bDashing == true && m_fDashTimer > 0)
        {
           // takes 1 second per second from m_fDashTimer 
            m_fDashTimer -= Time.deltaTime;
           gameObject.GetComponent<BoxCollider>().isTrigger = true;
            // Freezes the players y position during the dash to prevent player falling through the ground 
             rb.constraints =
              RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ |
              RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY |
              RigidbodyConstraints.FreezeRotationZ;

                if (m_fDashTimer <= 0)
                {
                    //KICK BACK//rb.velocity = Vector3.left * 30;
                    //rb.AddForce(Vector3.right * 0);
                  //m_fCurrentDashCount -= 1;
                    // Adds seconds back to Timer 
                    m_fDashTimer += 0.4f;
                    m_bDashing = false;
                    gameObject.GetComponent<BoxCollider>().isTrigger = false;
                    // returns players constraints back to normal
                    rb.constraints =  RigidbodyConstraints.FreezePositionZ |
              RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY |
              RigidbodyConstraints.FreezeRotationZ; ;
                    transform.Rotate(0, 0, 0);


                }

            }
   
        //JUMPING
        if (m_bGrounded == true)
        {
            //Then do jump code
            // if (Input.GetAxis("Jump") > 0.1f) // Add jump test for control 
            if (XCI.GetButton(XboxButton.A))
            {
                //m_fVerticalJumpForce = 5.0f;
                Vector3 Jump = new Vector3(0, m_fVerticalJumpForce, 0);
                transform.GetComponent<Rigidbody>().AddForce(Jump, ForceMode.Impulse);
                m_bGrounded = false;
            }
        }

    }

    //when the player collides with an object with the tag "Ground"
    //The player can jump
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            m_bGrounded = true;
        }
        //turn on m_bGrounded   
    }
}
            
        




   



