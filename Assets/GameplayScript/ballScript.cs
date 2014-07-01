using UnityEngine;
using System.Collections;

public class ballScript : MonoBehaviour {

	// Use this for initialization
	int j = 0;

	void Start () {
	
	}
	
	// Update is called once per frame clzqnrnow4t4o7
	void Update () {

		if (animation.isPlaying) {
				
			renderer.material.color = new Color((1 - this.transform.localScale.x / 3.910961f), this.transform.localScale.x / 3.910961f, 0, 1f);
		
		} else {
					
			j++;

		}
		


		if (j > 30) {
				
			j = 0;
			this.transform.localScale = new Vector3(0,0,0);
		
		}


		GetTouches ();
	}

	void GetTouches(){




		foreach (Touch touch in Input.touches) {



			if (touch.phase != TouchPhase.Ended && touch.phase != TouchPhase.Canceled) {
						
						Ray ray = Camera.main.ScreenPointToRay (Input.GetTouch (0).position);
						RaycastHit hit;
		
						if (Physics.Raycast (ray, out hit)) {
								
								if (hit.collider.gameObject == this.gameObject) {
										
										j = 50;
										animation.Stop ();
								} 
						}
				}

		}
	}

	void OnGUI(){

		GUI.Box (new Rect (200,10,100,90), Input.touchCount.ToString());

	}


}
