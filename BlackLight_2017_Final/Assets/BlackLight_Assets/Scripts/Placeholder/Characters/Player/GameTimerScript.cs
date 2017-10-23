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
    public Text HighScore;
    PlayerController Dashcount; 
    // timer is set for 30 minutes
    public float m_fgameTimer = 1800;
    public bool m_bGameOver;
    public string timerString; 
    //----------------------------------------------------------------------------------------------------
    // Use this for initialization
    //----------------------------------------------------------------------------------------------------
    void Start()
    {
        //gameOver.enabled = false;
        m_bGameOver = false;
        // HighScore.text = "Highscore : " + PlayerPrefs.GetString(timerString).ToString();
        // Gets the highscore 
        HighScore.text = PlayerPrefs.GetString("HighScores");
        
        //Select = gameOver.GetComponent<SelectOnInput>();
    }
    //----------------------------------------------------------------------------------------------------
    // Update is called once per frame, while the game is playing the timer will count down from the desired time.
    // When the timer reaches zero the players controls are disable and the gameover screen is displayed
    //----------------------------------------------------------------------------------------------------
    void Update()
    {
        // counts down the timer 
        m_fgameTimer -= Time.deltaTime;
        // caps the numbers at 60 for minutes and seconds so it looks like a timer
        int seconds = (int)(m_fgameTimer % 60);
        int minutes = (int)(m_fgameTimer / 60) % 60;
        // format of timer
        timerString = string.Format("{0:00:}{1:00}", minutes, seconds);
        // m_fgameTimertext is going to display the timer
        gameTimerText.text = timerString;

        //displays the new time

        PlayerPrefs.SetString("HighScores", timerString);


        //if (PlayerPrefs.SetString("HighScores", timerString) >= PlayerPrefs.GetString("HighScores"))
        //{
        //    PlayerPrefs.SetString("HighScores", timerString);
        //
        //}

        if (m_fgameTimer <= 0)
        {
            m_bGameOver = true;
            //Select.enabled = true;
            //gameOver.enabled = true;
        }
        else
        {
            //Select.enabled = false;
            m_bGameOver = false;
        }
    }
}