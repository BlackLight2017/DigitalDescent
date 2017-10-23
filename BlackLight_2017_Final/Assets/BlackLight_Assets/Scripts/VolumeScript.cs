using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeScript : MonoBehaviour {

	public void AdjustVolume(float newVolume)
	{
		AudioListener.volume = newVolume;
	}
}
