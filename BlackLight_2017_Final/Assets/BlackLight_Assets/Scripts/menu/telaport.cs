using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class telaport : MonoBehaviour {

    public Transform reset;

    // Use this for initialization
    void OnTriggerEnter(Collider other) {
        if (other.tag == "MenuEnemy") {
            other.transform.position = reset.position;
//            other.transform.position = reset.rotation;
        }
    }
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
