using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class PlayerHealth : MonoBehaviour {

	public bool isAlive;
	[SerializeField]
	private GameObject pickupPrefab;
	public AudioClip impact;
	private AudioSource audioSource;

	// Use this for initialization
	void Start () {
		isAlive = true;
		audioSource = GetComponent<AudioSource> ();
	}

	void OnTriggerEnter (Collider other) {
		if (other.CompareTag ("Enemy") && isAlive) {
			if (HealthMeter.totalHealth >= 20) {
				HealthMeter.totalHealth -= 20;
				audioSource.PlayOneShot(impact, 0.7f);
			}
			if (HealthMeter.totalHealth == 0) {
				isAlive = false;
				
				//Create pickup particles at player position with no rotation
				Instantiate (pickupPrefab, transform.position, Quaternion.identity);
			}
		}
	}
}
