using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableOre : MonoBehaviour 
{
	public float health = 100f;

	private float currentHealth = 0;

	void Start()
	{
		currentHealth = health;
	}

	public void DamageDelt(float amount)
	{
		currentHealth -= amount;

		if (currentHealth <= 0)
			gameObject.SetActive(false);
	}
}
