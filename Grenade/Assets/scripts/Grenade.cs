using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour {

	public float delay = 3f;
	public float radius = 5f;
	public float force = 700f;
	public GameObject explosionEffect;

	float countdown;

	bool hasExploded = false;
	// Use this for initialization
	void Start () {
		countdown = delay;	
	}
	
	// Update is called once per frame
	void Update () {
		countdown -= Time.deltaTime;
		if(countdown <= 0 && !hasExploded){
			Explode();
			hasExploded = true;
		}
	}

	void Explode(){
		//Show Effect
		Instantiate(explosionEffect,transform.position,transform.rotation);

		//Get nearby objects
		Collider[] colliders = Physics.OverlapSphere(transform.position,radius);

		foreach (Collider nearbyObject in colliders) {
			Rigidbody rb = nearbyObject.GetComponent<Rigidbody> ();
			//Apply force
			if (rb != null) {
				rb.AddExplosionForce (force, transform.position, radius);
			}
		}

		//Remove Grenade
		Destroy(gameObject);
	}
}
