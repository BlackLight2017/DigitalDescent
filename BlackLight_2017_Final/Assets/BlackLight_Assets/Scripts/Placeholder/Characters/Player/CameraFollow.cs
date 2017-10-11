using UnityEngine;
using XboxCtrlrInput;
public class CameraFollow : MonoBehaviour {
    public Transform target;

    public float smoothSpeed;
    public Vector3 offset;
    public float SpeedChangeTime;
    private float m_fTmier = 0; 

    void FixedUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

      //  transform.LookAt(target); 

        if (XCI.GetAxis(XboxAxis.LeftStickX) < 0 )
        {
            m_fTmier += Time.deltaTime;
            if(m_fTmier >= SpeedChangeTime)
            {
                smoothSpeed = 0.06f;
            }
            offset.x = -5;
        }
        if (XCI.GetAxis(XboxAxis.LeftStickX) > 0)
        {
            m_fTmier += Time.deltaTime;
            if (m_fTmier >= SpeedChangeTime)
            {
                smoothSpeed = 0.06f;
            }
            offset.x = 5;
        }
        if(XCI.GetAxis(XboxAxis.LeftStickX) == 0)
        {
            m_fTmier = 0;
            smoothSpeed = 0.02f;
        }
    }

  

}
