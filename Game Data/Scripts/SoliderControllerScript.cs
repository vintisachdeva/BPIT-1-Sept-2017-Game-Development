using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SoliderControllerScript : MonoBehaviour {

	Animator animator;
	public float playerSpeed = 5f;

	void Start () {
		animator = GetComponent <Animator> ();
	}

	void FixedUpdate(){

		float moveX = Input.GetAxis ("Horizontal");
		animator.SetFloat ("Speed", Math.Abs (moveX));
		GetComponent<Rigidbody> ().velocity = new Vector3 (moveX * playerSpeed, GetComponent<Rigidbody> ().velocity.y, GetComponent<Rigidbody> ().velocity.z);

		float moveZ = Input.GetAxis ("Vertical");
		animator.SetFloat ("verticalSpeed", Math.Abs (moveZ));
		GetComponent<Rigidbody> ().velocity = new Vector3 (GetComponent<Rigidbody> ().velocity.x, GetComponent<Rigidbody>().velocity.y , moveZ * playerSpeed);

	}

	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			animator.SetTrigger ("Shoot");
			GetComponent<AudioSource> ().Play ();
		}
	}

	void OnCollisionEnter(Collision collision){
		GetComponent<Rigidbody> ().isKinematic = true;

	}

}
