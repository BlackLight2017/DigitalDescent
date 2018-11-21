//----------------------------------------------------------------------------------------------------
// AUTHOR: Gabriel Pilakis 
// EDITED BY: Jeremy Zoitas
//----------------------------------------------------------------------------------------------------

using UnityEngine;
using XboxCtrlrInput;
public class CameraFollow : MonoBehaviour {
    //----------------------------------------------------------------------------------------------------
    // Sets up references to other objects
    //----------------------------------------------------------------------------------------------------
    public XboxController controller;
    // Aims at the Player 
    public Transform target;
    // References PlayerControllerScript
    public PlayerController jump;
    public Vector3 offset;
    // How smooth The camera is going to move when the player moves
    public float m_fsmoothSpeed;
    // Y position of Player 
    public float PlayerY;
    // the speed of the camera when turning from left to right or right to left
    public float m_fSpeedChangeTime;
    // timer for m_fSpeedChangeTime
    private float m_fTimer = 0;

    //----------------------------------------------------------------------------------------------------
    // Update is called once per frame, the camera follows the players position and tracks the player with a 
    // smooth delay
    //----------------------------------------------------------------------------------------------------
    void FixedUpdate()
    {
        PlayerY = 0.1f;
        // While Player is on the ground 
        if (jump.m_bGrounded == true) 
        {
            //Camera follows Players y position
            PlayerY = 0.1f;  
        }

        // while Player is off the ground
        if (jump.m_bGrounded == false) 
        {
            // Camera stops following Plays y position
            PlayerY = 0.0f; 
        }

        Vector3 desiredPosition = target.position + offset ;

        // Moves the camera with the position of the player and the offset of the camera giving it a smooth look 
        float posx = Mathf.Lerp(transform.position.x, desiredPosition.x, m_fsmoothSpeed);
        float posy = Mathf.Lerp(transform.position.y, desiredPosition.y, PlayerY);
        float posz = Mathf.Lerp(transform.position.z, desiredPosition.z, m_fsmoothSpeed);

        Vector3 smoothedPosition = new Vector3(posx, posy, posz);
        transform.position = smoothedPosition;
        
        // when the left stick is tilted to the left it moves the camera to the left 
        if (XCI.GetAxis(XboxAxis.LeftStickX, controller) < 0)
        {
            m_fTimer += Time.deltaTime;
            if(m_fTimer >= m_fSpeedChangeTime)
            {
               m_fsmoothSpeed = 0.038f;
            }
            offset.x = -2.0f; // 7 
        }

        // when the left stick is tilted to the right it moves the camera to the right 
        if (XCI.GetAxis(XboxAxis.LeftStickX, controller) > 0)
        {
            m_fTimer += Time.deltaTime;
            if (m_fTimer >= m_fSpeedChangeTime)
            {
                m_fsmoothSpeed = 0.045f;
            }
            offset.x = 4.5f;
        }
        // when the left stick isnt being used the camera is set to the default position 
        if(XCI.GetAxis(XboxAxis.LeftStickX, controller) == 0 )
        {
            m_fTimer = 0;
            m_fsmoothSpeed = 0.02f; // 0.01 
        }
        
    }
   
}
