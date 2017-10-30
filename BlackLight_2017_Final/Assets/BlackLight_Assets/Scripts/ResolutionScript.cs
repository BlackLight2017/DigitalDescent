using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ResolutionScript : MonoBehaviour
{
	Resolution[] resolutions;
	public Dropdown dropdownMenu;
	void Start()
	{
		resolutions = Screen.resolutions;
		dropdownMenu.onValueChanged.AddListener(delegate { Screen.SetResolution(resolutions[dropdownMenu.value].width, resolutions[dropdownMenu.value].height, false); });
		for (int i = 0; i < resolutions.Length; i++)
		{
			dropdownMenu.options.Add(new Dropdown.OptionData(ResToString(resolutions[i])));

			if(Screen.currentResolution.width == resolutions[i].width && Screen.currentResolution.height == resolutions[i].height)
				dropdownMenu.value = i;
		}
	}

	string ResToString(Resolution res)
	{
		return res.width + " x " + res.height + ", " + res.refreshRate + "hz";
	}
}

