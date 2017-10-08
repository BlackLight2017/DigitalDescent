using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectOnInput : MonoBehaviour {

	public EventSystem EventSystem;
	public GameObject SelectedObject;

	private bool ButtonSelected;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(Input.GetAxisRaw("Vertical") != 0 && ButtonSelected == false)
		{
			EventSystem.SetSelectedGameObject(SelectedObject);
			ButtonSelected = true;
		}
	}

	private void OnDisable()
	{
		ButtonSelected = false;
	}

}
