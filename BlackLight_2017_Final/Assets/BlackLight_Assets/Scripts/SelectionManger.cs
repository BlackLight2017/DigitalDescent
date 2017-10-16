using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectionManger : MonoBehaviour {

    public EventSystem ES;
    private GameObject StoreSelected;

	//----------------------------------------------------------------------------------------------------
	// Use this for initialization
	//----------------------------------------------------------------------------------------------------
	void Start ()
    {
        StoreSelected = ES.firstSelectedGameObject;	
	}

	//----------------------------------------------------------------------------------------------------
	// Update is called once per frame, Sets the Selected gameObject to stored selected if you click of
	// the button in the menu, and sets the selected gameobject to the first object if it is null.
	//----------------------------------------------------------------------------------------------------
	void Update ()
    {
	    if(ES.currentSelectedGameObject == null)
        {
            ES.SetSelectedGameObject(StoreSelected);
        }
        else
        {
            StoreSelected = ES.currentSelectedGameObject;
        }
	}
}
