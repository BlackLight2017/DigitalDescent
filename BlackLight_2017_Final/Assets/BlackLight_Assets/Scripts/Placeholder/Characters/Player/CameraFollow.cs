using UnityEngine;
using XboxCtrlrInput;
public class CameraFollow : MonoBehaviour {
    //----------------------------------------------------------------------------------------------------
    // Sets up references to other objects
    //----------------------------------------------------------------------------------------------------
    public Transform target;
    public GameObject falling;
    public PlayerController jump; 
    public float m_fsmoothSpeed;
    public Vector3 offset;
    private float PlayerY;
    private bool Timer;
    private bool m_bJumpCooldownTimer = false;
    private float m_fJumpTime;
    private float m_fJumpCoolDown;
    public float m_fSpeedChangeTime;
    private float m_fTmier = 0;
    public float m_test;

    Vector3 vel = Vector3.zero;
    float targetPos;
    void Start()
    {
        targetPos = target.position.y;
    }

    //----------------------------------------------------------------------------------------------------
    // Update is called once per frame, the camera follows the players position and tracks the player with a 
    // smooth delay
    //----------------------------------------------------------------------------------------------------
    void FixedUpdate()
    {
        // print(m_fsmoothSpeed);
        // adds offse to camera thats targeted at the player 
        if (Timer == true)
        {
            m_fJumpTime += Time.deltaTime;

        }
        m_test += Time.deltaTime; 
        if (m_bJumpCooldownTimer == true)
        {
            m_fJumpCoolDown -= Time.deltaTime;
        }
        if (m_fJumpCoolDown <= 0)
        {
            m_bJumpCooldownTimer = false;
        }
        Vector3 desiredPosition = target.position + offset ;
        // moves the camera with the position of the player and the offset of the camera giving it a smooth look 
        //Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, m_fsmoothSpeed);
        float posx = Mathf.Lerp(transform.position.x, desiredPosition.x, m_fsmoothSpeed);
        float posy = Mathf.Lerp(transform.position.y, desiredPosition.y, PlayerY);
        float posz = Mathf.Lerp(transform.position.z, desiredPosition.z, m_fsmoothSpeed);
        //lower smoother

        //Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, desiredPosition, ref vel, m_fsmoothSpeed);

        Vector3 smoothedPosition = new Vector3(posx, posy, posz);
        transform.position = smoothedPosition;
        
       // transform.position = new Vector3(m_fsmoothSpeed, transform.position.y, -10); 
        // when the left stick is tilted to the left it moves the camera to the left 
        if (XCI.GetAxis(XboxAxis.LeftStickX) < 0)
        {
            m_fTmier += Time.deltaTime;
            if(m_fTmier >= m_fSpeedChangeTime)
            {
               m_fsmoothSpeed = 0.038f;
            }
            offset.x = -2.0f; // 7 
        }
        if (m_bJumpCooldownTimer == false && m_test >= 0.00000000003f)
        {
            m_test = 0; 
            if (XCI.GetButton(XboxButton.A))
            {
                Timer = true;
                PlayerY = 0.0f;
                m_fJumpCoolDown = 0.10f;
            }
            if (m_fJumpTime >= 0.39f)
            {
                PlayerY = 0.1f;
                m_fJumpTime = 0;
                Timer = false;
                m_bJumpCooldownTimer = true;
            }
        }
        //      else if (XCI.GetButtonUp(XboxButton.A))
        //      {
        //          PlayerY = 0.1f;
        //
        //      }
        // when the left stick is tilted to the right it moves the camera to the right 
        if (XCI.GetAxis(XboxAxis.LeftStickX) > 0)
        {
            m_fTmier += Time.deltaTime;
            if (m_fTmier >= m_fSpeedChangeTime)
            {
                m_fsmoothSpeed = 0.045f;
            }
            offset.x = 4.5f;
        }
        // when the left stick isnt being used the camera is set to the default position 
        if(XCI.GetAxis(XboxAxis.LeftStickX) == 0 )
        {
            //if (target.GetComponent<Rigidbody>().velocity.y < 0)
            //{
            //    Debug.Log(target.GetComponent<Rigidbody>().velocity.y);
            //    m_fsmoothSpeed = 0.1f;
            //}
            m_fTmier = 0;
            m_fsmoothSpeed = 0.02f; // 0.01 
        }
    }

}
