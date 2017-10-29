using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

public class MyCamera : MonoBehaviour
{
    public Transform target;

    public float m_fsmoothSpeed = 0.125f;
    public Vector3 offset;
    public float m_fSpeedChangeTime;
    private float m_fTmier = 0;


    void FixedUpdate()
    {
        Vector3 desiredPosition = target.position + offset;

        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, m_fsmoothSpeed);
        transform.position = smoothedPosition;
        if (XCI.GetAxis(XboxAxis.LeftStickX) < 0)
        {
            m_fTmier += Time.deltaTime;
            if (m_fTmier >= m_fSpeedChangeTime)
            {
                m_fsmoothSpeed = 0.06f;
            }
            offset.x = -7;
        }
        if (XCI.GetAxis(XboxAxis.LeftStickX) > 0)
        {
            m_fTmier += Time.deltaTime;
            if (m_fTmier >= m_fSpeedChangeTime)
            {
                m_fsmoothSpeed = 0.06f;
            }
            offset.x = 7;
        }

    }
       
}

    

