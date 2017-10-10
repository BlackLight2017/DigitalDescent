using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableControl : MonoBehaviour {

    //public Canvas End;
    public Canvas Endtrigger;
    //private bool m_fEnd = false;
    private SelectOnInput Select;
    private GameTimerScript GameOver;

    // Use this for initialization
    void Start()
    {
        //End.enabled = false;
        //Endtrigger = GameObject.Find("End");
        GameOver = Endtrigger.GetComponent<GameTimerScript>();
        Select = GetComponent<SelectOnInput>();
    }

    // Update is called once per frame
    void Update()
	{
        if (GameOver.m_bGameOver)
        {
            Select.enabled = true;
        }
        else
        {
            Select.enabled = false;
        }
    }
}
