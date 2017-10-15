using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevelTrigger : MonoBehaviour {

    public Canvas End;
    public bool m_bEnd = false;

    // Use this for initialization
    void Start () {
        End.enabled = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == ("Player"))
        {
            End.enabled = true;
            m_bEnd = true;
        }
        else
        {
            End.enabled = false;
            m_bEnd = false;
        }
    }
}
