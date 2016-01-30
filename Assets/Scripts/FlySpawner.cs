using UnityEngine;
using System.Collections;

public class FlySpawner : MonoBehaviour {

	[SerializeField]
	private GameObject flyPrefab;
	[SerializeField]
	private int totalFlyMinimum = 8;
	private float spawnArea = 25f;

	public static int totalFlyCount;
	public static int totalHealthFlyCount;
	public static int totalBonusFlyCount;

	// Use this for initialization
	void Start () {
		totalFlyCount = 0;
		totalHealthFlyCount = 0;
		totalBonusFlyCount = 0;
	}
	
	// Update is called once per frame
	void Update () {
		while(totalFlyCount < totalFlyMinimum) {
			totalFlyCount++;
			//Create random position for each fly
			float positionX = Random.Range(-spawnArea, spawnArea);
			float positionZ = Random.Range(-spawnArea, spawnArea);
			Vector3 flyPosition = new Vector3(positionX, 2f, positionZ);

			//then create the new fly
			Instantiate(flyPrefab, flyPosition, Quaternion.identity);
		}
	}
}
