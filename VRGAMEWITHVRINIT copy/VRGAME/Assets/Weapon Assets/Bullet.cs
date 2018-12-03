using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Bullet : NetworkBehaviour {

	void OnTriggerEnter(Collider collision)
    {
		var hit = collision.gameObject;
		//Debug.Log("Collision detected with bullet and : " + gameObject.name);
		var health = hit.GetComponent<Health>();
		if (health != null)
		{
			health.TakeDamage(25);
		}
		//Debug.Log("Destroying BULLET" + gameObject.name);
		//if(NetworkServer.active){
        NetworkServer.Destroy(gameObject);
		//}

    }
}
