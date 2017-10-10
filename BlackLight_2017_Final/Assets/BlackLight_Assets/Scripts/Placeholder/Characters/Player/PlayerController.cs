using System.Collections;
using System.Collections.Generic;
using XboxCtrlrInput; 

using UnityEngine;


public class PlayerController : MonoBehaviour {
   // animations for the player that will be added later
    public Animation Idle;
    public Animation Walk;
    public Animation Run;
    public Animation Jump;
    public Animation Dash;
    public Animation SwingWeapon;

    // how high the player can jump 
    public float m_fVerticalJumpForce;
    // how fast the player can move 
    public float m_fMovementSpeed;// = 10;
    private Rigidbody rb;

    // how long the dash lasts 
    float m_fDashTimer = 0.4f;
    bool m_bGrounded = true;
    public bool m_bDashing = false;

    public bool timer = true; 
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
        if (timer == true)
        {
            m_fDashCooldown -= Time.deltaTime;
        }
    ////  //m_fDashCooldown
      if (m_fDashCooldown <= 0)
      {
    
          m_fCurrentDashCount = 1;          
              // if you have more than 1 dash count then you can dash
    
              if (m_fCurrentDashCount > 0)
              {
                  // Dash is gone 
                  //Adds 5 seconds to the timer 
                  m_fDashCooldown += 5.0f;
                   timer = false; 
              }
            
                //else
                // no m_bDashing         
      }
      else if (m_fCurrentDashCount == 0)
        {
            timer = true; 
        }
        
        // Movement is controled by the xbox360 controller 
        // This input is for the left stick 
        float moveHorizontal = XCI.GetAxis(XboxAxis.LeftStickX);
        // movement of the player 
        transform.position = new Vector3(transform.position.x + (moveHorizontal * m_fMovementSpeed), transform.position.y, transform.position.z);
      
        if (XCI.GetAxis(XboxAxis.LeftStickX) < 0)
        {
            if (transform.eulerAngles.y == 270)
            {
                transform.eulerAngles = new Vector3 (0, 90,0);
            }
        }
        if (XCI.GetAxis(XboxAxis.LeftStickX) > 0)
        {
            if (transform.eulerAngles.y == 90)
            {
                transform.eulerAngles = new Vector3(0, -90, 0);
            }
        }

        // adds gravity to the player to avoid the player being floaty 
        rb.AddForce(Vector3.down * 10);
      
        // if the left bumper of the xbox360 control is pressed and m_bDashing is false and there are more than one available dash         
        if (XCI.GetButton(XboxButton.LeftBumper) && m_bDashing == false && m_fCurrentDashCount > 0)
        {
            // dashing is true 
            m_bDashing = true;
            // force is added to the left of the player 
            rb.AddForce(Vector3.left * 2700);
            // currentdashcount is deducted by one giving the player no more dashes 
            m_fCurrentDashCount -= 1;
        }
        // if the right bumper of the xbox360 control is pressed and m_bDashing is false and there are more than one available dash         
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
            // turns the players boxcollider into a trigger 
         //  gameObject.GetComponent<BoxCollider>().isTrigger = true;
            // Freezes the players y position during the dash to prevent player falling through the ground 
             rb.constraints =
                // change constraints on demo version 
             RigidbodyConstraints.FreezePositionZ |
              RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY |
              RigidbodyConstraints.FreezeRotationZ;

                if (m_fDashTimer <= 0)
                {
                    // Adds seconds back to Timer 
                    m_fDashTimer += 0.4f;
                    // dashing is false ending the dash 
                    m_bDashing = false;
                    // boxcollider is no longer a trigger

            //        gameObject.GetComponent<BoxCollider>().isTrigger = false;
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
            
        




   



