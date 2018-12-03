using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderControl : MonoBehaviour {

	public GameObject fog;
	// Use this for initialization

	public float timeLeft;
	void Start () {



	}
	
	// Update is called once per frame
	void Update () {
		timeLeft -= Time.deltaTime;
		if (timeLeft <= 890) {
			expand1 ();
		}

		/*if (timeLeft <= 300) {
			expand2 ();
		}

		if (timeLeft <= 180) {
			expand3 ();
		}*/


	}
	public void expand1() {
		fog.transform.localScale *= 1f;
	}

//	public void expand2() {
//		fog.transform.localScale += new Vector3 (100, 100, 100);
//	}
//
//	public void expand3() {
//		fog.transform.localScale += new Vector3 (150, 150, 150);
//	}
		
}


