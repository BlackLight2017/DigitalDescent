using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverManager : MonoBehaviour {

	public Canvas GameOver;
	public GameObject EndArea;
	public GameObject TimerGameObject;
	private SelectOnInput Select;
	private EndArea EndAreaScript;
	private GameTimerScript GameTimerScript;

	// Use this for initialization
	void Start ()
	{
		EndAreaScript = EndArea.GetComponent<EndArea>();
		GameTimerScript = TimerGameObject.GetComponent<GameTimerScript>();
		Select = GameOver.GetComponent<SelectOnInput>();
		Select.enabled = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(EndAreaScript.m_bEndReached == true)
		{
			GameOver.enabled = true;
			Select.enabled = true;
		}
		if(GameTimerScript.m_bGameOver == true)
		{
			GameOver.enabled = true;
			Select.enabled = true;
		}
		else
		{
			GameOver.enabled = false;
			Select.enabled = false;
		}
	}
}
