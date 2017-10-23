using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCamera : MonoBehaviour {

    public Vector3 targetpos; 
    public static float viewX;
    public static float viewY;
    public GameObject player; 


    // Use this for initialization
    void Start () {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update () {
        viewX = gameObject.transform.position.x;
        viewY = gameObject.transform.position.y;

        targetpos = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);


    }
}
