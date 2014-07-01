using UnityEngine;
using System.Collections;

public class ParticleScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		ParticleAnimator particleAnimator = GetComponent<ParticleAnimator>();
		Color[] modifiedColors = particleAnimator.colorAnimation;
		modifiedColors[2] = Color.yellow;
		particleAnimator.colorAnimation = modifiedColors;

	}

	void OnParticleCollision(GameObject other){

		Particle[] particles = particleEmitter.particles;
		int i = 0;
		while (i < particles.Length) {

			particles[i].color = Color.red;

			i++;
		}

	}
}
