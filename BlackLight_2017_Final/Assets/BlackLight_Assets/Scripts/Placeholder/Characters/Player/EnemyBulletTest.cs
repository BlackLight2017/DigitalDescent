using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletTest : MonoBehaviour
{
    private float spawn_time = 5;
    private float spawn_timer = 0;
    public float Speed = 1.0f;

    GameObject Player;
    PlayerHealth PlayerScripts;
    Vector3 MoveDirection;

    // Use this for initialization
    void Start()
    {
        //spawn_timer = spawn_time;
        Player = GameObject.FindGameObjectWithTag("Player");
        if(Player)
            PlayerScripts = Player.GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        //spawn_timer = spawn_time;
        spawn_timer += Time.deltaTime;
        if(Player)
        {
            if (spawn_timer >= 0 && spawn_timer <= 0.1 && !PlayerScripts.m_bIsDead)
            {
                MoveDirection += Player.transform.position - transform.position;
                MoveDirection.Normalize();
            }
            if (spawn_timer >= 2)
            {
                Destroy(gameObject);
            }
            transform.position += MoveDirection * Speed * Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
		if(other.gameObject.tag == "RangedEnemy" || other.gameObject.tag == "Enemy" || other.gameObject.tag == "Sword")
		{

		}
		else
		{
			Destroy(gameObject);
		}
    }
}
