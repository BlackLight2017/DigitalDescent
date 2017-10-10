﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameTimerScript : MonoBehaviour {
    public Text gameTimerText;
    public Canvas gameOver;
    // timer is set for 30 minutes
    float gameTimer = 1800; 
	
    void Start()
    {
        gameOver.enabled = false;
    }

	// Update is called once per frame
	void Update () {
        // counts down the timer 
        gameTimer -= Time.deltaTime;
        // caps the numbers at 60 for minutes and seconds so it looks like a timer
        int seconds  = (int)(gameTimer% 60 ) ;
        int minutes = (int)(gameTimer / 60) % 60 ;
        // format of timer
        string timerString = string.Format("{0:00:}{1:00}", minutes, seconds);
        // Gametimertext is going to display the timer
        gameTimerText.text = timerString; 

        if (gameTimer <= 0 )
        {
            gameOver.enabled = true; 
        }

	}
}
