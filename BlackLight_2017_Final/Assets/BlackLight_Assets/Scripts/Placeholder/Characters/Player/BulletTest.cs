using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTest : MonoBehaviour {
    private float spawn_time = 5;
    private float spawn_timer;
    public float Speed = 1.0f; 

    public GameObject StunGun;
    Rigidbody rb;
    Vector3 MoveDirection;

    // Use this for initialization
    void Start () {
        spawn_timer = spawn_time;
        rb = GetComponent<Rigidbody>();
        StunGun = GameObject.FindGameObjectWithTag("StunGun");
        MoveDirection = StunGun.transform.right;
    }
	
	// Update is called once per frame
	void Update () {
        spawn_timer = spawn_time;

        rb.AddForce(MoveDirection * Speed);
        	
	}
}
