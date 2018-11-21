//----------------------------------------------------------------------------------------------------
// AUTHOR: Jeremy Zoitas.
//----------------------------------------------------------------------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableControl : MonoBehaviour {
    //----------------------------------------------------------------------------------------------------
    // Sets up references to other objects
    //----------------------------------------------------------------------------------------------------
    public Canvas End;
    public GameObject Endtrigger;
    private SelectOnInput Select;
    private EndLevelTrigger endlevel;

    //----------------------------------------------------------------------------------------------------
    // Use this for initialization
    //----------------------------------------------------------------------------------------------------
    void Start()
    {
        // Sets the canvas to false
        End.enabled = false;
        // Sets endlevel to the EndLevelTrigger script
        endlevel = Endtrigger.GetComponent<EndLevelTrigger>();
        // Sets Select to the SelectOnInput script
        Select = End.GetComponent<SelectOnInput>();
    }

    //----------------------------------------------------------------------------------------------------
    // Update is called once per frame, When the endlevel screen pops up it lets the player control it and
    // disables the control of it when the end is not open.
    //----------------------------------------------------------------------------------------------------
    void Update()
    {
        // If then endlevel canvas is showing then Select is enable to let the player control the menu.
        // Other wise the controls for the menu are disabled.
        if (endlevel.m_bEnd)
        {
            Select.enabled = true;
        }
        else
        {
            Select.enabled = false;
        }
    }
}
