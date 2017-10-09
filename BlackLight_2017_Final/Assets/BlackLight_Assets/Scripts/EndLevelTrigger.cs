using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevelTrigger : MonoBehaviour {

    public Canvas End;
    private bool m_fEnd = false;
    private SelectOnInput Select;

    // Use this for initialization
    void Start () {
        End.enabled = false;
        Select = End.GetComponent<SelectOnInput>();
	}
	
	// Update is called once per frame
	void Update () {
		if(m_fEnd)
        {
            Select.enabled = true;
        }
        else
        {
            Select.enabled = false;
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == ("Player"))
        {
            End.enabled = true;
            m_fEnd = true;
        }
        else
        {
            End.enabled = false;
            m_fEnd = false;
        }
    }
}
