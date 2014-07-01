using UnityEngine;
using System.Collections;

public class MojoScript : MonoBehaviour {

	// Use this for initialization
	public Light light;

	void Start () {
		renderer.material.color = Color.red;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown(){

		if (renderer.material.color == Color.red) {
						renderer.material.color = Color.green;
						light.color = Color.green;
				} else {
						renderer.material.color = Color.red;
						light.color = Color.red;
				}

	}
}
