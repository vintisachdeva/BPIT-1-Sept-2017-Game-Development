using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour {

	Transform player;              
	PlayerHealth playerHealth;     
	Animator animator;

	void OnCollisionEnter(Collision collision){
	
		GetComponent<AudioSource> ().Play ();

		if(collision.gameObject.tag == "Bullet" ){
			animator.SetTrigger ("Dead");
			Destroy (collision.gameObject);
			Destroy (gameObject, 1.5f);
		}
	}

	void Awake ()
	{
		animator = GetComponent<Animator> ();
	}


	void Update ()
	{

	}
}
