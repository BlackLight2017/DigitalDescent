using System.Collections;
using System.Collections.Generic;

using UnityEngine;


public class PlayerController : MonoBehaviour {
  // public GameObject Bullet_prefab;
  // public GameObject Bullet_Spawn;

    public float VerticalJumpForce;
    public float MovementSpeed;// = 10;
    private Rigidbody rb;
    public bool isGrounded = false;
    private float spawn_timer;
    public float spawn_radius;
    public float spawn_time = 1;




    float DashTimer = 0.4f;
    bool Grounded = true;
    public bool Dashing = false;

    //Timer for dash count
    public float DashCooldown = 5;
    // int for CurrentDashCount
    public float CurrentDashCount = 0;

    bool CanFire = false;


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
        float moveHorizontal = Input.GetAxis("Horizontal");
       
        transform.position = new Vector3(transform.position.x + (moveHorizontal * MovementSpeed), transform.position.y, transform.position.z);

        //Vector3 movement = new Vector3(moveHorizontal, 0.0f, 0.0f);
        rb.AddForce(Vector3.down * 10);
        // If left shift is pressed Adds force for the cube to move right
        // If i have a dash avaliable 
        if (Input.GetKeyDown(KeyCode.LeftShift) && Dashing == false && CurrentDashCount > 0)
        {
            Dashing = true;
            CurrentDashCount -= 1;
        }

        if (Dashing == true && DashTimer > 0)
        {
           // takes 1 second per second from DashTimer 
            DashTimer -= Time.deltaTime;

            if (Input.GetKey(KeyCode.D))
            {
               
                rb.AddForce(Vector3.right * 400);
                //new Vector3(-100,rb.velocity.y,0)
                // rb.velocity = new  Vector3();
                if (DashTimer <= 0)
                {
                    //KICK BACK//rb.velocity = Vector3.left * 30;
                    //rb.AddForce(Vector3.right * 0);
                  //CurrentDashCount -= 1;
                    // Adds seconds back to Timer 
                    DashTimer += 0.4f;
                    Dashing = false;
                }
               
            }
            if (Input.GetKey(KeyCode.A))
            {

                // 200 force is added to the Players left side 
            
                rb.AddForce(Vector3.left * 400);
                if (DashTimer <= 0)
                {
                    //KICK BACK//rb.velocity = Vector3.right * 30;
                    // rb.velocity = new Vector3();

                    // Adds one second back to Timer 
                   //CurrentDashCount -= 1;

                    DashTimer += 0.4f;
                    Dashing = false;
                }
            }
        }


        if(Input.GetKeyUp(KeyCode.LeftShift) && Dashing == true)
        {
            Dashing = false;
        }

        //JUMPING
        if (Grounded == true)
        {
            //Then do jump code
            if (Input.GetAxis("Jump") > 0.1f)
            {
                //VerticalJumpForce = 5.0f;
                Vector3 Jump = new Vector3(0, VerticalJumpForce, 0);
                transform.GetComponent<Rigidbody>().AddForce(Jump, ForceMode.Impulse);
                Grounded = false;
            }
        }

    }

//   public void Fire()
//   {
//       if (CanFire == true)
//       {
//           spawn_timer = spawn_time;
//           CanFire = false;
//           // Instanciate a new Bullet Prefab
//           float spawn_angle = Random.Range(0, 2 * Mathf.PI);
//           Vector3 spawn_direction = new Vector3(Mathf.Sin(spawn_angle), 0, Mathf.Cos(spawn_angle));
//           spawn_direction *= spawn_radius;
//           Instantiate(Bullet_prefab, Bullet_Spawn.transform.position, Quaternion.identity);
//
//
//
//       }
//   }
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

   



