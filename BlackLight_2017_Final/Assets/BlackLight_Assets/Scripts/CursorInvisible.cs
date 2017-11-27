//----------------------------------------------------------------------------------------------------
// AUTHOR: Jeremy Zoitas.
//----------------------------------------------------------------------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorInvisible : MonoBehaviour {

	CursorLockMode Locked;
	//----------------------------------------------------------------------------------------------------
	// Use this for initialization
	//----------------------------------------------------------------------------------------------------
	void Start () {
		// locks the cursor and makes it invisable.
		Locked = CursorLockMode.Locked;
		Cursor.visible = false;
		Cursor.lockState = Locked;
	}

	//----------------------------------------------------------------------------------------------------
	// Update is called once per frame,
	//----------------------------------------------------------------------------------------------------
	void Update () {
		
	}
}
