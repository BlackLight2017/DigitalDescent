using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour {

    public float m_fSpeed;
    public GameObject Door; 
    public bool m_bOpenDoor;
    public float m_fOpenTime = 1.0f;
    public float m_fCloseTime = 1.0f;

    // Use this for initialization
    void FixedUpdate () {
        if (m_bOpenDoor == true)
        {
            m_fSpeed = 8.0f;

            m_fOpenTime -= Time.deltaTime; 
            Door.transform.position += transform.up * m_fSpeed * Time.deltaTime;
            if(m_fOpenTime <= 0)
            {
                m_bOpenDoor = false;
            }
        }
        if (m_bOpenDoor == false)
        {
            if (m_fOpenTime <= 0)
            {
                m_fCloseTime -= Time.deltaTime;
                Door.transform.position -= transform.up * m_fSpeed * Time.deltaTime;
                if (m_fCloseTime <= 0)
                {
                    m_fSpeed = 0;
                    m_fOpenTime += 0.65f;
                    m_fCloseTime += 0.65f; 
                }
            }
        }
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            m_bOpenDoor = true; 
        }
             
    }
 
}
