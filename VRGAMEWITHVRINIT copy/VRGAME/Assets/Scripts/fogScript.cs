using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fogScript : MonoBehaviour {
	public float timeLeft;

	public GameObject Player;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		timeLeft -= Time.deltaTime;
		if (timeLeft <= 890 && timeLeft > 885) {
			expand1 ();
		} else if (timeLeft <= 750 && timeLeft > 745) {
			expandfog2 ();
		} else if (timeLeft <= 550 && timeLeft > 545) {
			expandfog3 ();
		}
	}
	void expand1() {
		transform.localScale += new Vector3(1F, 1f, 1f);
	}

	void expandfog2() {
			transform.localScale += new Vector3(1F, 1f, 1f);
	}
	void expandfog3() {
		transform.localScale += new Vector3(1F, 1f, 1f);
	}

	void OnTriggerEnter(Collider other) {
if(other.gameObject.CompareTag("Player")) {

			Debug.Log("Hit the fog");
			var hit = Player;
			var health = hit.GetComponent<Health>();
	Debug.Log(hit);
			if(health != null) {
				health.TakeDamage(10);
			}
		}
	}

}