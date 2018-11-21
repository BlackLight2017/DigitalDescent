//----------------------------------------------------------------------------------------------------
// AUTHOR: Jeremy Zoitas
//----------------------------------------------------------------------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeScript : MonoBehaviour {
	//----------------------------------------------------------------------------------------------------
	// Adjusts the volume based of the slider value
	// 
	// Param:
	//		NewVolume: is a float which is changed based on the slider's value
	//----------------------------------------------------------------------------------------------------
	public void AdjustVolume(float newVolume)
	{
		AudioListener.volume = newVolume;
	}
}
