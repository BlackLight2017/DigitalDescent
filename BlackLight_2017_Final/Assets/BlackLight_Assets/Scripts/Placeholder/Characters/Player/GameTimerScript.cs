using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using XboxCtrlrInput;

public class GameTimerScript : MonoBehaviour
{
    //----------------------------------------------------------------------------------------------------
    // Sets up references to other objects and creates variables
    //----------------------------------------------------------------------------------------------------
    public Text gameTimerText;
    public GameObject player; 
    public Text HighScore;
    public Text HighscoreSeconds;
    public bool ResetHighScore = false;
    // timer is set for 30 minutes
    public float m_fgameTimer = 1800;
    public bool m_bGameOver;
    float seconds;
    float minutes;
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
        HighScore.text = PlayerPrefs.GetFloat("HighScores").ToString();
        HighscoreSeconds.text = PlayerPrefs.GetFloat("Seconds" ).ToString();

        //Select = gameOver.GetComponent<SelectOnInput>();
    }
    //----------------------------------------------------------------------------------------------------
    // Update is called once per frame, while the game is playing the timer will count down from the desired time.
    // When the timer reaches zero the players controls are disable and the gameover screen is displayed.When the
    // player has reached the end the timer is saved and put into Highscore. The highscore can be reset using a combination 
    // of buttons on the controller. 
    //----------------------------------------------------------------------------------------------------
    void Update()
    {
        // counts down the timer 
        m_fgameTimer -= Time.deltaTime;

        // caps the numbers at 60 for minutes and seconds so it looks like a timer
        seconds = (int)(m_fgameTimer % 60);
        minutes = (int)(m_fgameTimer / 60) % 60;
        // format of timer
        timerString = string.Format("{0:00:}{1:00}", minutes, seconds);
        // m_fgameTimertext is going to display the timer
        gameTimerText.text = timerString;
      
        // Hold LeftBumper,Rightbumper,A and back to Clear Highscore 
        if (XCI.GetButton(XboxButton.A) && XCI.GetButton(XboxButton.RightBumper) && XCI.GetButton(XboxButton.LeftBumper)
            && XCI.GetButton(XboxButton.Back))
        {
            ResetHighScore = true;
            m_bGameOver = true;

        }

        if (ResetHighScore == true)
        {
            PlayerPrefs.DeleteAll();
            ResetHighScore = false; 
        }
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
    //----------------------------------------------------------------------------------------------------
    // OnTriggerENeter is called everytime the player collided with the EndArea hitbox which will save the 
    // time as the highscore. 
    //----------------------------------------------------------------------------------------------------
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "EndArea")
        {
           
            //displays the new time
            if (minutes > PlayerPrefs.GetFloat("HighScores"))
            {
                PlayerPrefs.SetFloat("HighScores", minutes);
            }

            if (seconds > PlayerPrefs.GetFloat("Seconds"))
            {
                PlayerPrefs.SetFloat("Seconds", seconds);
            }
        }
    }
}