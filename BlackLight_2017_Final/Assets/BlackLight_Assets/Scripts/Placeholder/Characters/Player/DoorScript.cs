//----------------------------------------------------------------------------------------------------
// AUTHOR: Gabriel Pilakis 
//----------------------------------------------------------------------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour {

    //----------------------------------------------------------------------------------------------------
    // Sets up references to other objects and creates variables
    //----------------------------------------------------------------------------------------------------
  
    public GameObject Door; 
    // How fast the door moves
    public float m_fSpeed;
    // Checks if door is open
    public bool m_bOpenDoor;
    // how long the door opens for
    public float m_fOpenTime = 1.0f;
    // how long the door closes for
    public float m_fCloseTime = 1.0f;

    //----------------------------------------------------------------------------------------------------
    // Fixed Update is called once per frame, The door script is activated once the player comes in contact
    // with the doors box collider. Once the player hits the box collider the door will open up and close 
    // automatically
    //----------------------------------------------------------------------------------------------------
    void FixedUpdate () {
        if (m_bOpenDoor == true)
        {
            // speed of the door 
            m_fSpeed = 8.0f;
            // how long the door stays open 
            m_fOpenTime -= Time.deltaTime; 
            Door.transform.position += transform.up * m_fSpeed * Time.deltaTime;
            if(m_fOpenTime <= 0)
            {
                // once the doors open time is zero the door will close
                m_bOpenDoor = false;
            }
        }
        if (m_bOpenDoor == false)
        {
            if (m_fOpenTime <= 0)
            {
                // how long till the door closes 
                m_fCloseTime -= Time.deltaTime;
                Door.transform.position -= transform.up * m_fSpeed * Time.deltaTime;
                if (m_fCloseTime <= 0)
                {
                    // once the door is closed both open and close times are re added and the door
                    // doesent move until the player interacts with it again
                    m_fSpeed = 0;
                    m_fOpenTime += 0.65f;
                    m_fCloseTime += 0.65f; 
                }
            }
        }
    }

    //----------------------------------------------------------------------------------------------------
    // OnTriggerEnter is called everytime the player collided with the Door hitbox the door script will activate 
    //----------------------------------------------------------------------------------------------------
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            m_bOpenDoor = true; 
        }
             
    }
 
}
