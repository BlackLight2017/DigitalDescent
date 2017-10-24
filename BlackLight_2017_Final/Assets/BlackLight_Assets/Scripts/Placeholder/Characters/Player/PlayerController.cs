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

    // animations for the player that will be added later
    public Animation Idle;
    public Animation Walk;
    public Animation Run;
    public Animation Jump;
    public Animation Dash;
    public Animation SwingWeapon;
    public float DownForce;
    

    public Image DashDisplay; 

    // how high the player can jump 
    public float m_fVerticalJumpForce;
    // how fast the player can move 
    public float m_fMovementSpeed;// = 10;
    public float MaxVel;
   
    private Rigidbody rb;

    // how long the dash lasts 
    float m_fDashTimer = 0.4f;
    bool m_bGrounded = true;
    public bool m_bDashing = false;

    public bool timer = true; 
    //cooldown for dash 
    public float m_fDashCooldown = 1;
    // how many dashes the player has 
    public float m_fCurrentDashCount = 0;

	public Canvas PauseMenu;
	//private SelectOnInput Select;
	public GameObject Resume;
	public GameObject Restart;
	public GameObject Quit;
	public EventSystem ES;

	//---------------------------------------------------------------------------------------------------
	// Use this for initialization
	//----------------------------------------------------------------------------------------------------
	void Start()
    {
        rb = GetComponent<Rigidbody>();
		PauseMenu.enabled = false;
		Time.timeScale = 1;
		//Select = PauseMenu.GetComponent<SelectOnInput>();
		//Select.enabled = false;
	}

    //----------------------------------------------------------------------------------------------------
    // FixedUpdate is called once per frame, when the game load up the user wil be able to control the players 
    // movement, jump and dash abilities.                                            
    //----------------------------------------------------------------------------------------------------
    void FixedUpdate()
    {

        m_fCurrentDashCount = m_fCurrentDashCount + 0;
		if(DashDisplay)
			DashDisplay.fillAmount = m_fCurrentDashCount;
        // if the timer is on dash cooldown counts down 
        if (timer == true)
        {
            m_fDashCooldown -= Time.deltaTime;
            float DashFill = m_fDashCooldown;
            DashFill = DashFill / 1;
			if(DashDisplay)
				DashDisplay.fillAmount = DashFill;
        }
 
        // if the dashcooldown is less or equal to zero add 1 to CurrentDashCount 
        if (m_fDashCooldown <= 0)
      {
			if(DashDisplay)
				DashDisplay.fillAmount = m_fCurrentDashCount; 
            m_fCurrentDashCount = 1;          
            // if they're is more than one dash 
              if (m_fCurrentDashCount > 0)
              {
                  //Adds 5 seconds to dashcooldown
                  // Timer is turned off  
                  m_fDashCooldown += 1.0f;
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
        float moveHorizontal = XCI.GetAxis(XboxAxis.LeftStickX);
 
        // movement of the player 
        transform.position = new Vector3(transform.position.x + (moveHorizontal * m_fMovementSpeed), transform.position.y, transform.position.z);
   
        // when the left stick is tiled to the left it rotates the player 90 degrees (face playerto the left)
        if (XCI.GetAxis(XboxAxis.LeftStickX) < 0)
        {
            if (transform.eulerAngles.y == 270)
            {
                transform.eulerAngles = new Vector3 (0, 90,0);
            }
        }
        // when the left stick is tiled to the right it rotates the player -90 degrees (faces player to the right) 
        if (XCI.GetAxis(XboxAxis.LeftStickX) > 0)
        {
            if (transform.eulerAngles.y == 90)
            {
                transform.eulerAngles = new Vector3(0, -90, 0);
            }
        }

        // adds gravity to the player to avoid the player being floaty 
        rb.AddForce(Vector3.down * DownForce);
      
        // if the left bumper of the xbox360 control is pressed and m_bDashing is false and there are more than one available dash         
        if (XCI.GetButton(XboxButton.B) && m_bDashing == false && m_fCurrentDashCount > 0 && XCI.GetAxis(XboxAxis.LeftStickX) < 0)
        {
            // dashing is true 
            m_bDashing = true;
            // force is added to the left of the player 
            rb.AddForce(Vector3.left * 2700);
            // currentdashcount is deducted by one giving the player no more dashes 
            m_fCurrentDashCount -= 1;

        }
        // if the right bumper of the xbox360 control is pressed and m_bDashing is false and there are more than one available dash         
        if (XCI.GetButton(XboxButton.B) && m_bDashing == false && m_fCurrentDashCount > 0 && XCI.GetAxis(XboxAxis.LeftStickX) > 0)
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
                    // boxcollider is no longer a trigger

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
            // when the 'A' button the xbox360 Control is pressed 
            if (XCI.GetButton(XboxButton.A))
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
		if (XCI.GetButton(XboxButton.Start))
		{
			// Sets the pause menu true.
			if(Time.timeScale == 1)
			{
				Time.timeScale = 0;
				PauseMenu.enabled = true;
				Resume.SetActive(true);
				Restart.SetActive(true);
				Quit.SetActive(true);
				//Select.enabled = true;
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
    private void OnCollisionStay(Collision collision)
    {
        // if the player is collided with an object with the tagged 'Ground' the player can jump  
        if (collision.gameObject.tag == "Ground")
        {
            m_bGrounded = true;
        }
      
    }
}
            
        




   



