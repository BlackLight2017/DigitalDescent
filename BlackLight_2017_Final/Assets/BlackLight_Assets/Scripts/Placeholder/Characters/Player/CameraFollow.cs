using UnityEngine;
using XboxCtrlrInput;
public class CameraFollow : MonoBehaviour {
    //----------------------------------------------------------------------------------------------------
    // Sets up references to other objects
    //----------------------------------------------------------------------------------------------------
    public Transform target;

    public float m_fsmoothSpeed;
    public Vector3 offset;
    public float m_fSpeedChangeTime;
    private float m_fTmier = 0;

    //----------------------------------------------------------------------------------------------------
    // Update is called once per frame, the camera follows the players position and tracks the player with a 
    // smooth delay
    //----------------------------------------------------------------------------------------------------
    void FixedUpdate()
    {
        // adds offse to camera thats targeted at the player 
       
        Vector3 desiredPosition = target.position + offset;
        // moves the camera with the position of the player and the offset of the camera giving it a smooth look 
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, m_fsmoothSpeed);

        transform.position = smoothedPosition;

       // transform.position = new Vector3(m_fsmoothSpeed, transform.position.y, -10); 
        // when the left stick is tilted to the left it moves the camera to the left 
        if (XCI.GetAxis(XboxAxis.LeftStickX) < 0 )
        {
            m_fTmier += Time.deltaTime;
            if(m_fTmier >= m_fSpeedChangeTime)
            {
                m_fsmoothSpeed = 0.06f;
            }
            offset.x = -7;
        }
   
     
        // when the left stick is tilted to the right it moves the camera to the right 
        if (XCI.GetAxis(XboxAxis.LeftStickX) > 0)
        {
            m_fTmier += Time.deltaTime;
            if (m_fTmier >= m_fSpeedChangeTime)
            {
                m_fsmoothSpeed = 0.06f;
            }
            offset.x = 7;
        }
        // when the left stick isnt being used the camera is set to the default position 
        if(XCI.GetAxis(XboxAxis.LeftStickX) == 0)
        {
            m_fTmier = 0;
            m_fsmoothSpeed = 0.04f;

        }


    }
}
