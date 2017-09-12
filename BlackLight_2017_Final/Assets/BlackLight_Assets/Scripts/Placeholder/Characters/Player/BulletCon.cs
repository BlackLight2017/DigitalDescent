using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCon : MonoBehaviour
{
	// Use this for initialization
	void Start ()
    {
        Destroy(this.gameObject, 2.0f);
	}

    void OnTriggerEnter (Collider other)
    {
        if (other.tag == "Enemy")
        {
            Destroy(this.gameObject);
        }
    }
}
