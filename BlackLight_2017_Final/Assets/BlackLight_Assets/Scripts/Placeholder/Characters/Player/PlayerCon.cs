using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerCon : MonoBehaviour
{
    [Header("Player Movement")]
    public GameObject character;
    public float movementSpeed;
    public bool canMove;
    public float jumpHeight;

    [Header("Health Variables")]
    public float health;
    public float startHealth;
    public Image healthBar;
	public int dealthHealth;

    [Header("Shooting")]
    public float bulletSpeed;
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    public GameObject charact;

	// Use this for initialization
	void Start ()
    {
        health = startHealth;
        canMove = true;
	}
	
	// Update is called once per frame
	void Update ()
    {
        //Move the player Left and Right
		if (canMove == true)
        {
            float h = Input.GetAxis("Horizontal") * movementSpeed;
            character.transform.Translate(h * Time.deltaTime, 0, 0);
        }

        if (Input.GetButtonDown("Jump"))
        {
            this.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * jumpHeight);
        }

        if (Input.GetButtonDown("Fire1"))
        {
            GameObject GO = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity) as GameObject;
            GO.GetComponent<Rigidbody>().AddForce(charact.transform.right * bulletSpeed, ForceMode.Impulse);
        }
	}

    public void HurtPlayer (int damageAmount)
    {
        health -= damageAmount;

        healthBar.fillAmount = health / startHealth;

        if (health <= 0)
        {
			
            Die();
        }
    }

	public void DamageOTime (int damageOverTime)
	{
		health -= damageOverTime * 0.5f /Time.time;

		healthBar.fillAmount = health / startHealth;

		if (health <= 0)
		{
			Die();
		}
	}
		

    public void Die()
    {
        Debug.Log("YOU DIED!");
    }
}
