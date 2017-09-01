using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFireScript : MonoBehaviour {

	public GameObject bullet;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown (KeyCode.Space)){
			
			GameObject bulletObject = (Instantiate (bullet) as GameObject);

			bulletObject.transform.position = transform.position + Camera.main.transform.forward * 3;

			Rigidbody rigidBody = bulletObject.GetComponent<Rigidbody> ();
		
			rigidBody.velocity = Camera.main.transform.forward * 40;

			Destroy (bulletObject, 0.5f);
		}
	}
}
