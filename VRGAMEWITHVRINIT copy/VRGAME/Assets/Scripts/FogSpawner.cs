using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogSpawner : MonoBehaviour {

	public GameObject prefab;
	public float repeatTime = 3f;
	public float PlaceX;
	public float PlaceZ;
	public int[] FogArray = new int[10];
	private bool FogSpawned = false;
	// Use this for initialization
	void Start () {
		loop ();
	}
	
	void loop() {
		if (!FogSpawned)
		{
			for (int i = 0; i <= FogArray.Length; i++) {
				Spawn ();
				//InvokeRepeating ("Spawn", 2f, repeatTime);
				Debug.Log ("Spawned Fog");
			}
			Debug.Log ("Spawned from Loop FogSpawned");
			FogSpawned = true;
		}
	}

	void Spawn() {
		PlaceX = Random.Range (30, 100);
		PlaceZ = Random.Range (30, 100);
		prefab.transform.position = new Vector3 (PlaceX, 10.5f, PlaceZ);
		Instantiate (prefab, prefab.transform.position, Quaternion.identity);
	}
}
