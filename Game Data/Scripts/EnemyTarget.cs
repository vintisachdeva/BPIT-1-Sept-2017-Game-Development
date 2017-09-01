using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyTarget : MonoBehaviour {

	Transform playerTarget;
	NavMeshAgent navMeshAgent;
	Animator animator;
	PlayerHealth playerHealth;

	void Start () {

		playerTarget = GameObject.FindGameObjectWithTag ("Player").transform;
		playerHealth = playerTarget.GetComponent <PlayerHealth> ();

		navMeshAgent = GetComponent <NavMeshAgent> ();
		animator = GetComponent <Animator> ();
	}

	void Update () {
		navMeshAgent.SetDestination (playerTarget.position);

		if (playerHealth.currentHealth > 0) {
			
		} else {
			navMeshAgent.enabled = false;
		}
	}

	void OnCollisionEnter(Collision collision){
		GetComponent<AudioSource> ().Play ();

		if(collision.gameObject.tag == "Bullet" ){
			animator.SetTrigger ("Dead");
			Destroy (collision.gameObject);
			Destroy (gameObject, 1.0f);
		} 
			
	}
}

