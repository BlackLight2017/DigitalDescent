using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StunGun : MonoBehaviour {
    //----------------------------------------------------------------------------------------------------
    // Sets up references to other objects
    //----------------------------------------------------------------------------------------------------  
    // access to bullet prefab 
    public GameObject Bullet_prefab;
    // access to bullet spawn 
    public GameObject Bullet_Spawn;
    // how much time between shots 
    public float spawn_time = 1;
    private Rigidbody rb;
    // Timer for bullets being shot 
    private float spawn_timer;
    bool CanFire = false;

    //----------------------------------------------------------------------------------------------------
    // Use this for initialization
    //----------------------------------------------------------------------------------------------------  
    void Start ()
    {
    rb = GetComponent<Rigidbody>();
    }
    //----------------------------------------------------------------------------------------------------
    // Update is called once per frame,when the player presses 'F' is launches a stun bullet on the x axis
    //----------------------------------------------------------------------------------------------------
    void Update () {
        // if canfire equals false the timer counts down and player cannot shoot 
        if (CanFire == false)
            spawn_timer -= Time.deltaTime;
        // if the timer is below 0 player can shoot again 
        if (spawn_timer < 0)
        {
            CanFire = true;
        }
        // if canfire equals ture player can press f to shoot 
        if (CanFire == true)
        {
            if (Input.GetKeyDown(KeyCode.F))
                Fire();
        }
    }
    //----------------------------------------------------------------------------------------------------
    // Fire is used to spawn the bullet and give the bullet its movement.
    //----------------------------------------------------------------------------------------------------
    public void Fire()
    {
        if (CanFire == true)
        {        
            spawn_timer = spawn_time;
            CanFire = false;
            // Instanciate a new Bullet Prefab
            float spawn_angle = Random.Range(0, 2 * Mathf.PI);
              
            // Bullet moves 
            Instantiate(Bullet_prefab, Bullet_Spawn.transform.position, Quaternion.identity);
        }
    }
}
