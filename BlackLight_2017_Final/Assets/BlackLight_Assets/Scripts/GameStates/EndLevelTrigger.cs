//----------------------------------------------------------------------------------------------------
// AUTHOR: Jeremy Zoitas.
//----------------------------------------------------------------------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevelTrigger : MonoBehaviour {
    //----------------------------------------------------------------------------------------------------
    // Sets up references to other objects and creates variables
    //----------------------------------------------------------------------------------------------------
    public Canvas End;
    public bool m_bEnd = false;

    //----------------------------------------------------------------------------------------------------
    // Use this for initialization
    //----------------------------------------------------------------------------------------------------
    void Start ()
    {
        // Sets the canvas to not appear at the start
        End.enabled = false;
	}

    //----------------------------------------------------------------------------------------------------
    // Update is called once per frame,
    //----------------------------------------------------------------------------------------------------
    void Update ()
    {
	}

    //----------------------------------------------------------------------------------------------------
    // OnTriggerEnter is called every time it is colliding with another object, It brings up the end
    // canvas and sets end to true if the player has reached it. Else they are both set to false
    //
    // Param: 
    //      other: Is the object that is being collided with.
    //----------------------------------------------------------------------------------------------------
    private void OnTriggerEnter(Collider other)
    {
        // If the player triggers this then the end will happen.
        // if not nothing happens and after the player has triggered to it resets.
        if(other.gameObject.tag == ("Player"))
        {
            End.enabled = true;
            m_bEnd = true;
        }
        else
        {
            End.enabled = false;
            m_bEnd = false;
        }
    }
}
