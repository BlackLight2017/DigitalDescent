using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullScreenScript : MonoBehaviour {

	public void FullScreen(bool Ticked)
	{
		if (Ticked)
		{
			Screen.fullScreen = true;
		}
		else
		{
			Screen.fullScreen = !Screen.fullScreen;
		}
	}
}
