using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeScript : MonoBehaviour {
	//----------------------------------------------------------------------------------------------------
	// Adjusts the volume based of the slider value
	//----------------------------------------------------------------------------------------------------
	public void AdjustVolume(float newVolume)
	{
		AudioListener.volume = newVolume;
	}
}
