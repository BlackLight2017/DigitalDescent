using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeScript : MonoBehaviour {

	public void AdjustVolume(float newVolume)
	{
		AudioListener.volume = newVolume;
	}
}
