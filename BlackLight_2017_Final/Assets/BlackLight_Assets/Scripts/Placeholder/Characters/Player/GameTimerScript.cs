using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimerScript : MonoBehaviour
{
    //----------------------------------------------------------------------------------------------------
    // Sets up references to other objects and creates variables
    //----------------------------------------------------------------------------------------------------
    public Text gameTimerText;
    PlayerController Dashcount; 
    public Canvas gameOver;
    private SelectOnInput Select;

    // timer is set for 30 minutes
    public float gameTimer = 1800;
    public bool m_bGameOver;

    //----------------------------------------------------------------------------------------------------
    // Use this for initialization
    //----------------------------------------------------------------------------------------------------
    void Start()
    {
        gameOver.enabled = false;
        //m_bGameOver = false;
        Select = gameOver.GetComponent<SelectOnInput>();
    }
    //----------------------------------------------------------------------------------------------------
    // Update is called once per frame, while the game is playing the timer will count down from the desired time.
    // When the timer reaches zero the players controls are disable and the gameover screen is displayed
    //----------------------------------------------------------------------------------------------------
    void Update()
    {
        // counts down the timer 
        gameTimer -= Time.deltaTime;
        // caps the numbers at 60 for minutes and seconds so it looks like a timer
        int seconds = (int)(gameTimer % 60);
        int minutes = (int)(gameTimer / 60) % 60;
        // format of timer
        string timerString = string.Format("{0:00:}{1:00}", minutes, seconds);
        // Gametimertext is going to display the timer
        gameTimerText.text = timerString;

        if (gameTimer <= 0)
        {
            //m_bGameOver = true;
            Select.enabled = true;
            gameOver.enabled = true;
        }
        else
        {
            Select.enabled = false;
            //m_bGameOver = false;
        }
    }
}