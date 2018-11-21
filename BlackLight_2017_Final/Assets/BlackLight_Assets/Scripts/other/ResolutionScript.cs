//----------------------------------------------------------------------------------------------------
// AUTHOR: Jeremy Zoitas.
//----------------------------------------------------------------------------------------------------
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ResolutionScript : MonoBehaviour
{
	//----------------------------------------------------------------------------------------------------
	// Sets up references to other objects and creates variables.
	//----------------------------------------------------------------------------------------------------
	Resolution[] resolutions;
	public Dropdown dropdownMenu;

	//----------------------------------------------------------------------------------------------------
	// Use this for initialization.
	//----------------------------------------------------------------------------------------------------
	void Start()
	{
		// gets all Resolutions.
		resolutions = Screen.resolutions;
		// changes resolution to the selected option in the dropdown box.
		dropdownMenu.onValueChanged.AddListener(delegate { Screen.SetResolution(resolutions[dropdownMenu.value].width, resolutions[dropdownMenu.value].height, false); });
		// this for loop adds all the Resolutions to the dropdown box and sets the selected option in the 
		// dropdown to the current resolution.
		for (int i = 0; i < resolutions.Length; i++)
		{
			dropdownMenu.options.Add(new Dropdown.OptionData(ResToString(resolutions[i])));

			if(Screen.currentResolution.width == resolutions[i].width && Screen.currentResolution.height == resolutions[i].height)
				dropdownMenu.value = i;
		}
	}

	//----------------------------------------------------------------------------------------------------
	// ResToString is called at the srat of the script it turns the reselutions into readable options for 
	// the dropbox.
	//
	// Param: 
	//      res: Is the Resolution which needs to be changed into a string.
	//----------------------------------------------------------------------------------------------------
	string ResToString(Resolution res)
	{
		return res.width + " x " + res.height + ", " + res.refreshRate + "hz";
	}
}

