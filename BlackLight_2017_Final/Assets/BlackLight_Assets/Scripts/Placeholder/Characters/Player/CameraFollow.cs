using UnityEngine;
using XboxCtrlrInput;
public class CameraFollow : MonoBehaviour {
    //----------------------------------------------------------------------------------------------------
    // Sets up references to other objects
    //----------------------------------------------------------------------------------------------------
    public Transform target;
    public GameObject falling;
    public float m_fsmoothSpeed;
    public Vector3 offset;
    public float m_fSpeedChangeTime;
    private float m_fTmier = 0;
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
        print(m_fsmoothSpeed);
        // adds offse to camera thats targeted at the player 
       
        Vector3 desiredPosition = target.position + offset ;
        // moves the camera with the position of the player and the offset of the camera giving it a smooth look 
        //Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, m_fsmoothSpeed);
        float posx = Mathf.Lerp(transform.position.x, desiredPosition.x, m_fsmoothSpeed);
        float posy = Mathf.Lerp(transform.position.y, desiredPosition.y, 0.1f);
        float posz = Mathf.Lerp(transform.position.z, desiredPosition.z, m_fsmoothSpeed);
        //lower smoother

        //Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, desiredPosition, ref vel, m_fsmoothSpeed);

        Vector3 smoothedPosition = new Vector3(posx, posy, posz);
        transform.position = smoothedPosition;

       // transform.position = new Vector3(m_fsmoothSpeed, transform.position.y, -10); 
        // when the left stick is tilted to the left it moves the camera to the left 
        if (XCI.GetAxis(XboxAxis.LeftStickX) < 0 )
        {
            m_fTmier += Time.deltaTime;
            if(m_fTmier >= m_fSpeedChangeTime)
            {
                m_fsmoothSpeed = 0.05f;
            }
            offset.x = -7;
        }
   
     
        // when the left stick is tilted to the right it moves the camera to the right 
        if (XCI.GetAxis(XboxAxis.LeftStickX) > 0)
        {
            m_fTmier += Time.deltaTime;
            if (m_fTmier >= m_fSpeedChangeTime)
            {
                m_fsmoothSpeed = 0.05f;
            }
            offset.x = 7;
        }
        // when the left stick isnt being used the camera is set to the default position 
        if(XCI.GetAxis(XboxAxis.LeftStickX) == 0)
        {
            //if (target.GetComponent<Rigidbody>().velocity.y < 0)
            //{
            //    Debug.Log(target.GetComponent<Rigidbody>().velocity.y);
            //    m_fsmoothSpeed = 0.1f;
            //}
            m_fTmier = 0;
            m_fsmoothSpeed = 0.02f;
        }
    }

}
