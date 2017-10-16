using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneScript : MonoBehaviour {
	//----------------------------------------------------------------------------------------------------
	// Loads a scene by the index given in the build settings
	//----------------------------------------------------------------------------------------------------
	public void LoadByIndex(int SceneIndex)
	{
		SceneManager.LoadScene(SceneIndex);
	}
}
