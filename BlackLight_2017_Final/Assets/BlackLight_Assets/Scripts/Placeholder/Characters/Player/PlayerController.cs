using System.Collections;
using System.Collections.Generic;
using XboxCtrlrInput;
using UnityEngine.UI;
using UnityEngine.EventSystems;

using UnityEngine;


public class PlayerController : MonoBehaviour {
    //----------------------------------------------------------------------------------------------------
    // Sets up references to other objects
    //----------------------------------------------------------------------------------------------------
    public XboxController controller;
    public SwordTEST sword;
    public ParticleSystem particles; 
    // animations for the player that will be added later
    public Animation Idle;
    public Animation Walk;
    public Animation Run;
    public Animation Jump;
    public Animation Dash;
    public Animation SwingWeapon;
    public AudioSource Dashing;
    public Animator Attackings; 
    public float DownForce;

    public GameObject LegR;
    public GameObject LegL;
    public GameObject ArmR;
    public GameObject ArmL;
    public GameObject Neck; 
                      
    Animator anim;
   
    public Image DashDisplay; 

    // how high the player can jump 
    public float m_fVerticalJumpForce;
    // how fast the player can move 
    // THE DEFAULT SPEED OF KEYBOARD AND CONTROLLER
    public float m_fDefaultPlayerSpeed;
    private float m_fDefaultControllerPlayerSpeed;
    // THE RESULTING RAMP UP SPEED 
    public float m_fRampUpSpeed;// = 10;
    // ADDS THE AMOUNT OF TO THE CONTROLLER AND KEYBAORD SPEED 
    private float m_fControllerRampUp; //0.00005f
    // ADDS TO RAMP UP SPEED 
    public float m_fAddingRampSpeed;   //0.00090f

    public float MaxVel;
   
    private Rigidbody rb;

    // how long the dash lasts 
    float m_fDashTimer = 0.5f;
    public bool m_bGrounded = true;
    public bool m_bDashing = false;

    public bool timer = true;
    public bool RampUp = true;  
    //cooldown for dash 
    public float m_fDashCooldown = 1.35f;
    // how many dashes the player has 
    public float m_fCurrentDashCount = 0.0f;
    public float RampUpTime = 0; 

	public Canvas PauseMenu;
	private SelectOnInput Select;
	public GameObject Resume;
	public GameObject Restart;
	public GameObject Quit;
	public EventSystem ES;

	//---------------------------------------------------------------------------------------------------
	// Use this for initialization
    //* try to revert keyboard speed back to normal after ramp up 
	//----------------------------------------------------------------------------------------------------
	void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
		PauseMenu.enabled = false;
        Time.timeScale = 1;
		Select = PauseMenu.GetComponent<SelectOnInput>();
		Select.enabled = false;
	}

    //----------------------------------------------------------------------------------------------------
    // FixedUpdate is called once per frame, when the game load up the user wil be able to control the players 
    // movement, jump and dash abilities. The user can control the player using the keyboard or an xbox Controller.
    // Particles are also called in the update when the player dashes                                            
    //----------------------------------------------------------------------------------------------------
    void FixedUpdate()
    {
        

        m_fCurrentDashCount = m_fCurrentDashCount + 0;
		if(DashDisplay)
			DashDisplay.fillAmount = m_fCurrentDashCount;
        // if the timer is on dash cooldown counts down 
        if (timer == true)
        {
            m_fDashCooldown += Time.deltaTime;
            float DashFill = m_fDashCooldown;
            DashFill = DashFill / 1.35f;
			if(DashDisplay)
				DashDisplay.fillAmount = DashFill;
        }
 
        // if the dashcooldown is less or equal to zero add 1 to CurrentDashCount 
        if (m_fDashCooldown >= 1.35f)
      {
			if(DashDisplay)
				DashDisplay.fillAmount = m_fCurrentDashCount; 
            m_fCurrentDashCount = 1;          
            // if they're is more than one dash 
              if (m_fCurrentDashCount > 0)
              {
                  //Adds 5 seconds to dashcooldown
                  // Timer is turned off  
                  m_fDashCooldown -= 1.35f;
                   timer = false; 
              }      
             
      }
       // if they're no more dashes the timer resets
      else if (m_fCurrentDashCount == 0)
        {
            timer = true; 
        }
        
        // Movement is controled by the xbox360 controller 
        // This input is for the left stick 
        float moveHorizontal = XCI.GetAxis(XboxAxis.LeftStickX, controller);
        //float m_fKeyboardMoveHorizontal = Input.GetAxis("Horizontal");
        // movement of the player 
       transform.position = new Vector3(transform.position.x + (moveHorizontal * m_fRampUpSpeed), transform.position.y, transform.position.z);

        // when the left stick is tiled to the left it rotates the player 90 degrees (face playerto the left)
        if (XCI.GetAxis(XboxAxis.LeftStickX, controller) < 0)
        {
            // RAMP UP WHEN RUNNING TO LEFT
          // if (RampUp == true)
          // {
          //     RampUpTime += Time.deltaTime;
          //     if (RampUpTime >= 1)
          //     {
          //         m_fRampUpMovementSpeed += 0.00015f;
          //         m_fRampUpSpeed += 0.00120f;
          //     }
          // }
            if (transform.eulerAngles.y == 270)
            {
                transform.eulerAngles = new Vector3 (0, 90,0);
              
            }
         //  if (RampUpTime >= 3)
         //  {
         //      RampUp = false;
         //
         //
         //  }
        }
        // when the left stick is tiled to the right it rotates the player -90 degrees (faces player to the right) 
        if (XCI.GetAxis(XboxAxis.LeftStickX, controller) > 0)
        {

            if (RampUp == true)
            {
                RampUpTime += Time.deltaTime;
                if (RampUpTime >= 1)
                {
                    m_fRampUpSpeed += m_fAddingRampSpeed;//0.00120f

                }
            }
                if (transform.eulerAngles.y == 90)
                {

                    transform.eulerAngles = new Vector3(0, -90, 0);

                }        
             
                if (RampUpTime >= 2.5f)
                {
                    RampUp = false;                                            
            }                
        }
       
        if (XCI.GetAxis(XboxAxis.LeftStickX, controller) == 0 )
        {

            RampSpeed();

           // m_fRampUpMovementSpeed = 0.005f;
          //  m_fRampUpSpeed = 0.25f;
            RampUpTime = 0.0f;
            RampUp = true;

        }

        // adds gravity to the player to avoid the player being floaty 
        rb.AddForce(Vector3.down * DownForce);
      
        // if the left bumper of the xbox360 control is pressed and m_bDashing is false and there are more than one available dash         
        if (XCI.GetButton(XboxButton.B, controller) && m_bDashing == false && m_fCurrentDashCount > 0 && XCI.GetAxis(XboxAxis.LeftStickX, controller) < 0
            || XCI.GetButton(XboxButton.RightBumper, controller) && m_bDashing == false && m_fCurrentDashCount > 0 && XCI.GetAxis(XboxAxis.LeftStickX, controller) < 0
           )
        {
            Dashing.Play();
            particles.Play(); 
            // dashing is true 
            m_bDashing = true;
            // force is added to the left of the player 
            rb.AddForce(Vector3.left * 3200);
            // currentdashcount is deducted by one giving the player no more dashes 
            m_fCurrentDashCount -= 1;

        }
        // if the right bumper of the xbox360 control is pressed and m_bDashing is false and there are more than one available dash         
        if (XCI.GetButton(XboxButton.B, controller) && m_bDashing == false && m_fCurrentDashCount > 0 && XCI.GetAxis(XboxAxis.LeftStickX, controller) > 0
            || XCI.GetButton(XboxButton.RightBumper, controller) && m_bDashing == false && m_fCurrentDashCount > 0 && XCI.GetAxis(XboxAxis.LeftStickX, controller) > 0)
        {
            Dashing.Play();
            particles.Play();

            GetComponent<Renderer>().material.color = Color.yellow;
            LegL.GetComponent<Renderer>().material.color = Color.yellow;
            LegR.GetComponent<Renderer>().material.color = Color.yellow;
            ArmR.GetComponent<Renderer>().material.color = Color.yellow;
            ArmL.GetComponent<Renderer>().material.color = Color.yellow;
            Neck.GetComponent<Renderer>().material.color = Color.yellow;

            m_bDashing = true;
            rb.AddForce(Vector3.right * 3200);

            m_fCurrentDashCount -= 1;

        }
        if (m_bDashing == true && m_fDashTimer > 0)
        {
           // takes 1 second per second from m_fDashTimer 
            m_fDashTimer -= Time.deltaTime;
            // turns the players boxcollider into a trigger 
            // Freezes the players y position during the dash to prevent player falling through the ground 
             rb.constraints =
             RigidbodyConstraints.FreezePositionZ |
              RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY |
              RigidbodyConstraints.FreezeRotationZ;

                if (m_fDashTimer <= 0)
                {
                    // Adds seconds back to Timer 
                    m_fDashTimer += 0.4f;
                    // dashing is false ending the dash 
                    m_bDashing = false;

                GetComponent<Renderer>().material.color = new Color(0.18f, 0.18f, 0.18f);
                LegL.GetComponent<Renderer>().material.color = new Color(0.18f, 0.18f, 0.18f);
                LegR.GetComponent<Renderer>().material.color = new Color(0.18f, 0.18f, 0.18f);
                ArmR.GetComponent<Renderer>().material.color = new Color(0.18f, 0.18f, 0.18f);
                ArmL.GetComponent<Renderer>().material.color = new Color(0.18f, 0.18f, 0.18f);
                Neck.GetComponent<Renderer>().material.color = new Color(0.18f, 0.18f, 0.18f);

                // returns players constraints back to normal
                rb.constraints =  RigidbodyConstraints.FreezePositionZ |
              RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY |
              RigidbodyConstraints.FreezeRotationZ; ;
                    transform.Rotate(0, 0, 0);
                }
            }  
        if ( XCI.GetButton(XboxButton.X, controller))
        {
          
            Attackings.SetTrigger("isAttacking") ;
            sword.StartAttack(0.5f);

        }
        //JUMPING
        if (m_bGrounded == true)
        {
            // when the 'A' button the xbox360 Control is pressed 
            if (XCI.GetButton(XboxButton.A, controller))
            {
                // add jumpforce to players Y position 
                Vector3 Jump = new Vector3(0, m_fVerticalJumpForce, 0);
                // gives the player a more respoinsive jump with Forcemode.Impulse
                transform.GetComponent<Rigidbody>().AddForce(Jump, ForceMode.Impulse);
                // jump is disabled when in the air
                m_bGrounded = false;
            }
          
        }

		// Pause
		if (XCI.GetButton(XboxButton.Start, controller) )
		{
			// Sets the pause menu true.
			if(Time.timeScale == 1)
			{
				Time.timeScale = 0;
				PauseMenu.enabled = true;
				Resume.SetActive(true);
				Restart.SetActive(true);
				Quit.SetActive(true);
				Select.enabled = true;
				ES.firstSelectedGameObject = Resume;
			}
		}

		// Stops the player from flying away of a ramp.
		if (rb.velocity.y > MaxVel)
		{
			rb.velocity = new Vector3 (0,MaxVel,0);
		}
	}
    //----------------------------------------------------------------------------------------------------
    // OnCollisionStay is called when the player is colliding with an object, when this is called the player
    // can jump 
    //----------------------------------------------------------------------------------------------------
    public void RampSpeed()
    {
        m_fRampUpSpeed = m_fDefaultPlayerSpeed;

    }
    private void OnCollisionStay(Collision collision)
    {
        // if the player is collided with an object with the tagged 'Ground' the player can jump  
        {
            m_bGrounded = true;
        }
    }
  }
            
        




   



