using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableControl : MonoBehaviour {

    public bool m_fEnd = false;
    private SelectOnInput Select;

    // Use this for initialization
    void Start()
    {
        enabled = false;
        Select = GetComponent<SelectOnInput>();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_fEnd)
        {
            Select.enabled = true;
        }
        else
        {
            Select.enabled = false;
        }
    }
}
