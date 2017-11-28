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

		Death.gameObject.SetActive(false);
		Win.gameObject.SetActive(false);
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
			Win.gameObject.SetActive(true);
            ES.SetSelectedGameObject(WinButton);
			this.enabled = false;
		}
		// checks if the game timer has ended and pauses the time when the gameover menu pops up.
		if (GameTimerScript.m_bGameOver == true)
		{
            Time.timeScale = 0;
            GameOver.gameObject.SetActive(true);
			ES.SetSelectedGameObject(Restart);
			this.enabled = false;
		}
		if (HeroScript.m_bIsDead == true)
		{
			Time.timeScale = 0;
			Death.gameObject.SetActive(true);
			ES.SetSelectedGameObject(DeathRestart);
			this.enabled = false;
		}
	}
}
