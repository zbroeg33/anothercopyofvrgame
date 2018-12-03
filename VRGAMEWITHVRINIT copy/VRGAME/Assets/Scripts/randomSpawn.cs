using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomSpawn : MonoBehaviour {

	public GameObject Player;
	
	public float PlaceX;
	public float PlaceZ;

	// Use this for initialization
	void Start () {
		PlaceX = Random.Range (100, 300);
		PlaceZ = Random.Range (100, 300);
		Player.transform.position = new Vector3 (PlaceX, 5, PlaceZ);
		

	}
	

}
