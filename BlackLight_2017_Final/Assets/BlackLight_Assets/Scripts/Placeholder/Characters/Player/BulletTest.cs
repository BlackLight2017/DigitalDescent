using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTest : MonoBehaviour {
    //----------------------------------------------------------------------------------------------------
    // Sets up references to other objects
    //----------------------------------------------------------------------------------------------------  
    private float m_fspawn_time = 5;
    private float m_fspawn_timer;
    public float m_fSpeed = 1.0f; 

    public GameObject StunGun;
    Rigidbody rb;
    Vector3 MoveDirection;

    //----------------------------------------------------------------------------------------------------
    // Use this for initialization
    //----------------------------------------------------------------------------------------------------     
    void Start ()
    {
        // spawns bullet from the gameobject tagged "stungun" 
    m_fspawn_timer = m_fspawn_time;
        rb = GetComponent<Rigidbody>();
        StunGun = GameObject.FindGameObjectWithTag("StunGun");
        MoveDirection = StunGun.transform.right;
    }
    //----------------------------------------------------------------------------------------------------
    // Update is called once per frame,this update adds force to the bullet 
    //----------------------------------------------------------------------------------------------------
    void Update ()
    {
        m_fspawn_timer = m_fspawn_time;

        rb.AddForce(MoveDirection * m_fSpeed);      	
	}
}
