using UnityEngine;
using XboxCtrlrInput;
public class CameraFollow : MonoBehaviour {
    //----------------------------------------------------------------------------------------------------
    // Sets up references to other objects
    //----------------------------------------------------------------------------------------------------
    public Transform target;

    public float smoothSpeed;
    public Vector3 offset;
    public float SpeedChangeTime;
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
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        // when the left stick is tilted to the left it moves the camera to the left 
        if (XCI.GetAxis(XboxAxis.LeftStickX) < 0 )
        {
            m_fTmier += Time.deltaTime;
            if(m_fTmier >= SpeedChangeTime)
            {
                smoothSpeed = 0.06f;
            }
            offset.x = -5;
        }
        // when the left stick is tilted to the right it moves the camera to the right 
        if (XCI.GetAxis(XboxAxis.LeftStickX) > 0)
        {
            m_fTmier += Time.deltaTime;
            if (m_fTmier >= SpeedChangeTime)
            {
                smoothSpeed = 0.06f;
            }
            offset.x = 5;
        }
        // when the left stick isnt being used the camera is set to the default position 
        if(XCI.GetAxis(XboxAxis.LeftStickX) == 0)
        {
            m_fTmier = 0;
            smoothSpeed = 0.02f;
        }
    }
}
