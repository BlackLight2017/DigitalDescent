//----------------------------------------------------------------------------------------------------
// AUTHOR: Jeremy Zoitas.
//----------------------------------------------------------------------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneScript : MonoBehaviour {
	//----------------------------------------------------------------------------------------------------
	// Loads a scene by the index given in the build settings and lets objects move again.
	//
	// Param:
	//		SceneIndex: Is the Index/Number of the scene trying to be load.
	//----------------------------------------------------------------------------------------------------
	public void LoadByIndex(int SceneIndex)
	{
		SceneManager.LoadScene(SceneIndex);
		if (Time.timeScale == 0)
		{
			Time.timeScale = 1;
		}
	}
}
