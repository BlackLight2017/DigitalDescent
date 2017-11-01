using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndArea : MonoBehaviour {

	public bool m_bEndReached;

	//----------------------------------------------------------------------------------------------------
	// Use this for initialization.
	//----------------------------------------------------------------------------------------------------
	void Start ()
	{
		m_bEndReached = false;
	}
	//----------------------------------------------------------------------------------------------------
	// Update is called once per frame.
	//----------------------------------------------------------------------------------------------------
	void Update () {
		
	}
	//----------------------------------------------------------------------------------------------------
	// When the player reaches the end it sets a bool to true which is used to make the gameover menu appear.
	//----------------------------------------------------------------------------------------------------
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == ("Player"))
		{
			m_bEndReached = true;
		}
	}
}
