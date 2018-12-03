using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogScript : MonoBehaviour {

public GameObject Player;
	void OnCollisionEnter(Collision collision)
    {
		var hit = Player;
		var health = hit.GetComponent<Health>();
		if (health != null)
		{
			health.TakeDamage(10);
		}
        
    }
}
