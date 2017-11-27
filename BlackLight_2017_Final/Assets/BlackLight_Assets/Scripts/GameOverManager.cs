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
	public Canvas Death;
	public GameObject EndArea;
	public GameObject TimerGameObject;
	public GameObject Hero;
    private EndArea EndAreaScript;
	private GameTimerScript GameTimerScript;
	private PlayerHealth HeroScript;
	//public GameObject ReturnButton;
    public GameObject Restart;
    public GameObject Quit;
    public GameObject WinButton;
	public GameObject DeathRestart;
	public GameObject DeathQuit;
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
		// gets playercontoller script
		HeroScript = Hero.GetComponent<PlayerHealth>();
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
            Time.timeScale = 0;
            Win.enabled = true;
            WinButton.SetActive(true);
            ES.SetSelectedGameObject(WinButton);
			
		}
		// checks if the game timer has ended and pauses the time when the gameover menu pops up.
		if (GameTimerScript.m_bGameOver == true)
		{
            Time.timeScale = 0;
            GameOver.enabled = true;
			Quit.SetActive(true);
            Restart.SetActive(true);
			if (ES.currentSelectedGameObject == null)
				ES.SetSelectedGameObject(Restart);
		}
		if (HeroScript.m_bIsDead == true)
		{
			Time.timeScale = 0;
			Death.enabled = true;
			DeathQuit.SetActive(true);
			DeathRestart.SetActive(true);
			if(ES.currentSelectedGameObject == null)
				ES.SetSelectedGameObject(DeathRestart);
		}
		// if the player is still playing and the time has not ended or reached the end then the game continues.
		if (GameTimerScript.m_bGameOver == false && EndAreaScript.m_bEndReached == false && HeroScript.m_bIsDead == false)
		{
			Death.enabled = false;
			GameOver.enabled = false;
            Win.enabled = false;
            Quit.SetActive(false);
            Restart.SetActive(false);
            WinButton.SetActive(false);
			DeathQuit.SetActive(false);
			DeathRestart.SetActive(false);
		}
	}
}
