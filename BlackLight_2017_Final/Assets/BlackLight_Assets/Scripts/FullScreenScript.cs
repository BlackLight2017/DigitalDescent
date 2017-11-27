//-----------------------------------------------------------------
// AUTHOR: Jeremy Zoitas.
//-----------------------------------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullScreenScript : MonoBehaviour {
	// When a toggle box get clicked to switchs from fullscreen.
	public void FullScreen(bool Ticked)
	{
		// if ticked is true then the game becomes fullscreen.
		// else it is not.
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
