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


    public float VerticalJumpForce;
    public float MovementSpeed;// = 10;
    private Rigidbody rb;
    public bool isGrounded = false;
  //  private float spawn_timer;
  //  public float spawn_radius;
  //  public float spawn_time = 1;


    // how long the dash lasts 
    float DashTimer = 0.4f;
    bool Grounded = true;
    public bool Dashing = false;

    //cooldown for dash 
    public float DashCooldown = 5;
    // how many dashes the player has 
    public float CurrentDashCount = 0;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        //if the timer goes under 1 
        //Timer goes down 
     DashCooldown -= Time.deltaTime;
    ////  //DashCooldown
      if (DashCooldown <= 1)
          {
    
          CurrentDashCount += 1; 
          {
              // if you have more than 1 dash count then you can dash
    
              if (CurrentDashCount > 0)
              {
                  // Dash is gone 
                  //Adds 5 seconds to the timer 
                  DashCooldown += 5.0f;
              }
    
              //else
              // no dashing
          }
      }
        
        float moveHorizontal = XCI.GetAxis(XboxAxis.LeftStickX);

        transform.position = new Vector3(transform.position.x + (moveHorizontal * MovementSpeed), transform.position.y, transform.position.z);
        
       

        //Vector3 movement = new Vector3(moveHorizontal, 0.0f, 0.0f);
        rb.AddForce(Vector3.down * 10);
        // If left shift is pressed Adds force for the cube to move right
        // If i have a dash avaliable 
        if (XCI.GetButton(XboxButton.LeftBumper) && Dashing == false && CurrentDashCount > 0)
        {
            Dashing = true;
            rb.AddForce(Vector3.left * 2700);

            CurrentDashCount -= 1;
        }
        if (XCI.GetButton(XboxButton.RightBumper) && Dashing == false && CurrentDashCount > 0)
        {
            Dashing = true;
            rb.AddForce(Vector3.right * 2700);

            CurrentDashCount -= 1;
        }
        if (Dashing == true && DashTimer > 0)
        {
           // takes 1 second per second from DashTimer 
            DashTimer -= Time.deltaTime;
           gameObject.GetComponent<BoxCollider>().isTrigger = true;
            // Freezes the players y position during the dash to prevent player falling through the ground 
             rb.constraints =
              RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ |
              RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY |
              RigidbodyConstraints.FreezeRotationZ;

                if (DashTimer <= 0)
                {
                    //KICK BACK//rb.velocity = Vector3.left * 30;
                    //rb.AddForce(Vector3.right * 0);
                  //CurrentDashCount -= 1;
                    // Adds seconds back to Timer 
                    DashTimer += 0.4f;
                    Dashing = false;
                    gameObject.GetComponent<BoxCollider>().isTrigger = false;
                    // returns players constraints back to normal
                    rb.constraints =  RigidbodyConstraints.FreezePositionZ |
              RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY |
              RigidbodyConstraints.FreezeRotationZ; ;
                    transform.Rotate(0, 0, 0);


                }

            }
   
        //JUMPING
        if (Grounded == true)
        {
            //Then do jump code
            // if (Input.GetAxis("Jump") > 0.1f) // Add jump test for control 
            if (XCI.GetButton(XboxButton.A))
            {
                //VerticalJumpForce = 5.0f;
                Vector3 Jump = new Vector3(0, VerticalJumpForce, 0);
                transform.GetComponent<Rigidbody>().AddForce(Jump, ForceMode.Impulse);
                Grounded = false;
            }
        }

    }

    //when the player collides with an object with the tag "Ground"
    //The player can jump
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            Grounded = true;
        }
        //turn on grounded   
    }
}
            
        




   



