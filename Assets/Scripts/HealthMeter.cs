using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class HealthMeter : MonoBehaviour {

	public static int totalHealth;
	private Text healthMeterText;
	
	// Use this for initialization
	void Start () {
		totalHealth = 100;
		healthMeterText = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		healthMeterText.text = "HP: " + totalHealth;
	}
}
