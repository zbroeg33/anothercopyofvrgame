﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

 [RequireComponent(typeof(AudioSource))]
public class FireProjectile : NetworkBehaviour {

    public GameObject projectilePrefab;
    GameObject instantiatedProjectile;
    public Transform projectileLaunchPoint;
    public int BulletsInClip = 0;

 public AudioSource audio;

public AudioClip shoot;

public AudioClip outOfAmmo;
	void Start () {
		 audio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKeyDown(KeyCode.F) || OVRInput.Get(OVRInput.Button.SecondaryIndexTrigger) && (isLocalPlayer)){
           if(BulletsInClip >=1) {
				CmdFire();
                playShoot();
               // audio.clip = shoot;
               //  audio.Play();
			} else {
				Debug.Log("out of ammo :(");
                playOutofAmmo();
               // audio.PlayOneShot(outOfAmmo);
              // audio.clip=outOfAmmo;
               // Debug.Log(audio);
			}
        }
	}

    private void playShoot() {
        audio.PlayOneShot(shoot);
    }

    private void playOutofAmmo() {
        audio.PlayOneShot(outOfAmmo);
    }
    [Command]
    void CmdFire()
    {
        instantiatedProjectile = Instantiate(projectilePrefab, projectileLaunchPoint.position, transform.rotation);
        if (NetworkServer.active)
        {
            NetworkServer.Spawn(instantiatedProjectile);
           

           
        }

        BulletsInClip--;
        if (NetworkServer.active)
        {
          //  NetworkServer.Destroy(instantiatedProjectile);
          // Debug.Log("Destoroyed" + instantiatedProjectile);
        }
        
    }

    void OnTriggerEnter(Collider other) {
		 if(other.gameObject.CompareTag("PickUP")) {
		 	Destroy(other.gameObject); 
		 	Debug.Log("We hit the pickup object");
		 	BulletsInClip++;
			 Debug.Log("bullets in Clip" + BulletsInClip);
		 }	
         else if(other.gameObject.CompareTag("Monster")) {
			 Debug.Log("Shot the Monster");
			var hit = this.gameObject;
			var health = hit.GetComponent<Health>();
			Debug.Log(hit);
			if(health != null) {
				health.TakeDamage(10);
                Destroy(instantiatedProjectile);
				
			}
		 }
    }
}
