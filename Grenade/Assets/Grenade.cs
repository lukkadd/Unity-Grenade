using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour {

	public float delay = 3f;
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
			//Apply force
			//Damage

		//Remove Grenade
		Destroy(gameObject);
	}
}
