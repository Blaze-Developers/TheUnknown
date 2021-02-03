using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
	public Transform Character;
	public float speed = 0.1F;
	private Vector3 directionOfCharacter;
	private bool challenged = false; // Check if touched

	void Update()
	{
		if (challenged)
		{
			// Get direction to move towards
			directionOfCharacter = Character.transform.position - transform.position;
			directionOfCharacter = directionOfCharacter.normalized;

			transform.Translate(directionOfCharacter * speed, Space.World);
		}
	}

	// trigged on player hit
	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			challenged = true;
		}
	}
}
