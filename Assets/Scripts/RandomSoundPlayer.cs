using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RandomSoundPlayer : MonoBehaviour {

	private AudioSource audioSource;
	[SerializeField]
	private List<AudioClip> soundClips = new List<AudioClip>();
	[SerializeField]
	private float soundTimerDelay = 3f;
	private float soundTimer;

	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		//increments timer to count up to restarting
		soundTimer = soundTimer + Time.deltaTime;

		if (soundTimer >= soundTimerDelay) {
			soundTimer = 0f;
			AudioClip randomSound = soundClips[Random.Range(0, soundClips.Count)];
			audioSource.PlayOneShot (randomSound);
		}
	}
}
