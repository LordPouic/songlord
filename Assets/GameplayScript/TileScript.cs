using UnityEngine;
using System.Collections;

public class TileScript : MonoBehaviour {

	// Use this for initialization
	public Vector3 MojoPos;

	public float duration = 3.0f;
	private float startTime;
	public bool check = true;

	public string color;

	void Start () {

		startTime = Time.time;
		Destroy (gameObject, 3f);
		particleSystem.Stop ();
	
	}
	
	// Update is called once per frame
	void Update () {
			if (check){
				transform.position = Vector3.Lerp(transform.position, MojoPos, (Time.time - startTime) / duration);
			}
			
			if (color == "red")
				renderer.material.color = Color.red;
            if (color == "green")
                renderer.material.color = Color.green;
            if (color == "blue")
                renderer.material.color = Color.blue;
            if (color == "yellow")
                renderer.material.color = Color.yellow;
	}

	void OnCollisionEnter(Collision col){



		//Destroy (this, 0);
		if (col.gameObject.name == "Mojo"){
			if (col.gameObject.renderer.material.color == Color.red && color == "red"){

				particleSystem.Play();
				renderer.enabled = false; // detach particle system
				Destroy(particleSystem.gameObject, 0.5f);
                ScoreScript.addPoint();

			} else if (col.gameObject.renderer.material.color == Color.green && color == "green"){

				particleSystem.Play();
				renderer.enabled = false; // detach particle system
				Destroy(particleSystem.gameObject, 0.5f);
                ScoreScript.addPoint();
				//Destroy(gameObject);		

            }else if (col.gameObject.renderer.material.color == Color.blue && color == "blue")
            {

                particleSystem.Play();
                renderer.enabled = false; // detach particle system
                Destroy(particleSystem.gameObject, 0.5f);
                ScoreScript.addPoint();
                //Destroy(gameObject);		

            }
            else
            {
				check = false;
			}
		}



	}
}
