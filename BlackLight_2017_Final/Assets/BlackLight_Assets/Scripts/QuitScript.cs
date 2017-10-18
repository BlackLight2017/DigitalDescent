﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitScript : MonoBehaviour {
	//----------------------------------------------------------------------------------------------------
	// Quits playmode in unity or if in applacation it quits the applacation
	//----------------------------------------------------------------------------------------------------
	public void Quit()
	{

		if (Time.timeScale == 0)
		{
			Time.timeScale = 1;
		}

#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
#else
		Application.Quit();
#endif

	}

}
