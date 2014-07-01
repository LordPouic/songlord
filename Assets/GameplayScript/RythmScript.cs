using UnityEngine;
using System.Collections;


public class RythmScript : MonoBehaviour {

	// Use this for initialization
	public GameObject[] balls;

	int j = 0;

	public float[] samples;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {


		int r = Random.Range (0, 3);

		audio.GetOutputData (samples, 1);
		
		if (samples[0] > 0 && j > 30) {

			balls[r].animation.Play();

			j = 0;
		}
		
		j++;
	
	}
}
