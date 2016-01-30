using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	private Animator playerAnimator;
	private float moveHorizontal;
	private float moveVertical;
	private Vector3 movement;
	private float turningSpeed = 20f;
	private Rigidbody playerRigidbody;
	[SerializeField]
	private RandomSoundPlayer playerFootsteps;

	// Use this for initialization
	void Start () {
		playerAnimator = GetComponent<Animator> ();

		playerRigidbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		moveHorizontal = Input.GetAxisRaw ("Horizontal");
		moveVertical = Input.GetAxisRaw ("Vertical");

		movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
	}

	void FixedUpdate() {
		if (movement != Vector3.zero) {
			//Creates desired rotation based on movement vector
			Quaternion targetRotation = Quaternion.LookRotation(movement, Vector3.up);
			//Creates rotation that moves from current to desired rotation
			Quaternion newRotation = Quaternion.Lerp(playerRigidbody.rotation, targetRotation, turningSpeed * Time.deltaTime);
			//Moves player to new rotation
			playerRigidbody.MoveRotation(newRotation);
			playerAnimator.SetFloat ("Speed", 3f);
			playerFootsteps.enabled = true;
		} else {
			playerAnimator.SetFloat ("Speed", 0f);
			playerFootsteps.enabled = false;
		}
	}
}
