using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameOverManager : MonoBehaviour {
	//----------------------------------------------------------------------------------------------------
	// Sets up references to other objects.
	//----------------------------------------------------------------------------------------------------
	public Canvas GameOver;
	public GameObject EndArea;
	public GameObject TimerGameObject;
	//private SelectOnInput Select;
	private EndArea EndAreaScript;
	private GameTimerScript GameTimerScript;
	public GameObject ReturnButton;
	public EventSystem ES;

	//----------------------------------------------------------------------------------------------------
	// Use this for initialization.
	//----------------------------------------------------------------------------------------------------
	void Start ()
	{
		EndAreaScript = EndArea.GetComponent<EndArea>();
		GameTimerScript = TimerGameObject.GetComponent<GameTimerScript>();
		//Select = GameOver.GetComponent<SelectOnInput>();
		//Select.enabled = false;
        
	}

	//----------------------------------------------------------------------------------------------------
	// Update is called once per frame, Makes the end menu pop up and makes sure the player cant use the
	// menu in the game.
	//----------------------------------------------------------------------------------------------------
	void Update ()
	{
		if(EndAreaScript.m_bEndReached == true)
		{
            GameOver.enabled = true;
            ReturnButton.SetActive(true);
			//Select.enabled = true;
			ES.firstSelectedGameObject = ReturnButton;
		}
		if(GameTimerScript.m_bGameOver == true)
		{
          
			GameOver.enabled = true;
			ReturnButton.SetActive(true);
			//Select.enabled = true;
			ES.firstSelectedGameObject = ReturnButton;
		}
		if (GameTimerScript.m_bGameOver == false && EndAreaScript.m_bEndReached == false)
		{
			GameOver.enabled = false;
			ReturnButton.SetActive(false);
			//Select.enabled = false;
		}
	}
}
