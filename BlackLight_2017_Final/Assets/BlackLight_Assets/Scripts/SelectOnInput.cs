//----------------------------------------------------------------------------------------------------
// AUTHOR: Jeremy Zoitas.
//----------------------------------------------------------------------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectOnInput : MonoBehaviour {
	//----------------------------------------------------------------------------------------------------
	// Sets up references to other objects and variables.
	//----------------------------------------------------------------------------------------------------
	public EventSystem EventSystem;
	public GameObject SelectedObject;
	private bool ButtonSelected;

	//----------------------------------------------------------------------------------------------------
	// Use this for initialization.
	//----------------------------------------------------------------------------------------------------
	void Start () {	
	}
	//----------------------------------------------------------------------------------------------------
	// Update is called once per frame. Sets the selected button if nothing is selected.
	//----------------------------------------------------------------------------------------------------
	void Update ()
	{
		if(Input.GetAxisRaw("Vertical") != 0 && ButtonSelected == false)
		{
			EventSystem.SetSelectedGameObject(SelectedObject);
			ButtonSelected = true;
		}
	}
	//----------------------------------------------------------------------------------------------------
	// Deselects the selected button.
	//----------------------------------------------------------------------------------------------------
	private void OnDisable()
	{
		ButtonSelected = false;
	}

}
