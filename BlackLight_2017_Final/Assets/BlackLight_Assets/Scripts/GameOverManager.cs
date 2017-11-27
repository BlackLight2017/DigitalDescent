//----------------------------------------------------------------------------------------------------
// AUTHOR: Jermey Zoitas.
// EDITED BY: Gabriel Pilakis.
//----------------------------------------------------------------------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameOverManager : MonoBehaviour {
    //----------------------------------------------------------------------------------------------------
    // Sets up references to other objects.
    //----------------------------------------------------------------------------------------------------
   	public Canvas GameOver;
    public Canvas Win;
	public GameObject EndArea;
	public GameObject TimerGameObject;
    private EndArea EndAreaScript;
	private GameTimerScript GameTimerScript;
	//public GameObject ReturnButton;
    public GameObject Restart;
    public GameObject WinButton;
	public EventSystem ES;

	//----------------------------------------------------------------------------------------------------
	// Use this for initialization.
	//----------------------------------------------------------------------------------------------------
	void Start ()
	{
		// gets end area script.
		EndAreaScript = EndArea.GetComponent<EndArea>();
		// gets game timer script.
		GameTimerScript = TimerGameObject.GetComponent<GameTimerScript>();
    }

	//----------------------------------------------------------------------------------------------------
	// Update is called once per frame, Makes the end menu pop up and makes sure the player cant use the
	// menu in the game.
	//----------------------------------------------------------------------------------------------------
	void Update ()
	{
		// checks if the end has been reached and pauses the time when the win menu pops up.
		if(EndAreaScript.m_bEndReached == true)
		{
            Win.enabled = true;
            WinButton.SetActive(true);
            ES.SetSelectedGameObject(WinButton);
			Time.timeScale = 0;
		}
		// checks if the game timer has ended and pauses the time when the gameover menu pops up.
		if (GameTimerScript.m_bGameOver == true)
		{
			GameOver.enabled = true;
			//ReturnButton.SetActive(true);
            Restart.SetActive(true);
            ES.SetSelectedGameObject(Restart);
			Time.timeScale = 0;
		}
		// if the player is still playing and the time has not ended or reached the end then the game continues.
		if (GameTimerScript.m_bGameOver == false && EndAreaScript.m_bEndReached == false)
		{
			GameOver.enabled = false;
            Win.enabled = false;
            //ReturnButton.SetActive(false);
            Restart.SetActive(false);
            WinButton.SetActive(false);
		}
	}
}
