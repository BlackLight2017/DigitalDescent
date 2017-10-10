using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableControl : MonoBehaviour {

    public Canvas End;
    public GameObject Endtrigger;
    private bool m_fEnd = false;
    private SelectOnInput Select;
    private EndLevelTrigger endlevel;

    // Use this for initialization
    void Start()
    {
        End.enabled = false;
        Endtrigger = GameObject.Find("End");
        endlevel = Endtrigger.GetComponent<EndLevelTrigger>();
        Select = End.GetComponent<SelectOnInput>();
    }

    // Update is called once per frame
    void Update()
    {
        if (endlevel.m_fEnd)
        {
            Select.enabled = true;
        }
        else
        {
            Select.enabled = false;
        }
    }
}
