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
		EndAreaScript = EndArea.GetComponent<EndArea>();
		GameTimerScript = TimerGameObject.GetComponent<GameTimerScript>();
    }

	//----------------------------------------------------------------------------------------------------
	// Update is called once per frame, Makes the end menu pop up and makes sure the player cant use the
	// menu in the game.
	//----------------------------------------------------------------------------------------------------
	void Update ()
	{
		if(EndAreaScript.m_bEndReached == true)
		{
            Win.enabled = true;
            WinButton.SetActive(true);
            ES.SetSelectedGameObject(WinButton);
		}
		if(GameTimerScript.m_bGameOver == true)
		{
			GameOver.enabled = true;
			//ReturnButton.SetActive(true);
            Restart.SetActive(true);
            ES.SetSelectedGameObject(Restart);
		}
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
