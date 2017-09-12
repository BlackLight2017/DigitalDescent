using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtOverTime : MonoBehaviour 
{
	public int damageOverTime;

	void OnTriggerStay (Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			other.gameObject.GetComponent<PlayerCon> ().DamageOTime (damageOverTime);
		}
	}
}
