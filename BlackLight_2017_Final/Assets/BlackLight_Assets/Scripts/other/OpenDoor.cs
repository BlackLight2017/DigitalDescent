using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public GameObject door;

    void OnTriggerEnter (Collider other)
    {
        if (other.tag == "Player")
        {
            Destroy(this.gameObject);
            Destroy(door);
        }
    }
}
