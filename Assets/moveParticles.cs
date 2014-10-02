﻿using UnityEngine;
using System.Collections;

public class moveParticles : MonoBehaviour {
	public GameObject hand;
	public trackParticle[] trackerHolder;
	public ParticleSystem stars;
	public float maxSpeed = 0.01f;

	void Start () {
			hand = GameObject.Find ("Sphere");  //get hand position
		}

	void Update () {

		//get all existing particles' position
		stars = (ParticleSystem)GetComponent("ParticleSystem");
		ParticleSystem.Particle [] myParticleList = new ParticleSystem.Particle[stars.particleCount];

		stars.GetParticles(myParticleList); //myParticleList got all data.



		
		//steering
		for(int i = 0; i < myParticleList.Length; i++)
		{
			Vector3 desire = hand.transform.position - myParticleList[i].position;
			desire.Normalize();
			desire  *= maxSpeed;
			myParticleList[i].position += desire;

//			print (desire);
		}       

		stars.SetParticles(myParticleList, stars.particleCount); //update all new particles' positions
	}




}



