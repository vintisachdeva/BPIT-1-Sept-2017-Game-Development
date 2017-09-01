﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

	public int startingHealth = 100;                            
	public int currentHealth;                                   
	public Slider healthSlider;                                
	public Image damageImage;
	public float flashSpeed = 5f;                               
	public Color flashColour = new Color(1f, 0f, 0f, 0.1f);     
	bool damaged;

	Animator anim;                                              
	AudioSource playerAudio;                                    


	void Awake ()
	{
		anim = GetComponent <Animator> ();
		playerAudio = GetComponent <AudioSource> ();

		currentHealth = startingHealth;
	}


	void Update ()
	{
		if(damaged)
		{
			damageImage.color = flashColour;
		}
		else
		{
			damageImage.color = Color.Lerp (damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
		}
		damaged = false;
	}

	void OnCollisionEnter(Collision collision){
		
		damaged = true;
		anim.SetBool ("collided", true);
		currentHealth -= 20;

		healthSlider.value = currentHealth;

	}

}