using UnityEngine;
using System.Collections;

public class FlyPickup : MonoBehaviour {

	[SerializeField]
	private GameObject pickupPrefab;

	void OnTriggerEnter(Collider other) {
		//If the other collider is tagged as "Player"...
		if (other.CompareTag("Player")) {
			//Add the pickup particles and place at object's position with no rotation
			Instantiate(pickupPrefab, transform.position, Quaternion.identity);
			//decrement total number of flies and increment score
			FlySpawner.totalFlyCount--;
			ScoreCounter.score++;
			//Destroy the game object tied to this script
			Destroy (gameObject);
		}
	}
}
