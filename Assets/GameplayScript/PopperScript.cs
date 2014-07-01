using UnityEngine;
using System.Collections;

public class PopperScript : MonoBehaviour {

	// Use this for initialization
	public Transform Mojo;

	public GameObject tile;
	int j = 0;

	public float[] samples;

	public string color;

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update() {
		transform.RotateAround(Mojo.position, new Vector3(0,0,1), 100 * Time.deltaTime);


		float[] spectrum = audio.GetSpectrumData(64, 0, FFTWindow.BlackmanHarris);
		int i = 1;
		while (i < 63) {
			Debug.DrawLine(new Vector3(i - 1, spectrum[i] + 10, 0), new Vector3(i, spectrum[i + 1] + 10, 0), Color.red);
			Debug.DrawLine(new Vector3(i - 1, Mathf.Log(spectrum[i - 1]) + 10, 2), new Vector3(i, Mathf.Log(spectrum[i]) + 10, 2), Color.cyan);
			Debug.DrawLine(new Vector3(Mathf.Log(i - 1), spectrum[i - 1] - 10, 1), new Vector3(Mathf.Log(i), spectrum[i] - 10, 1), Color.green);
			Debug.DrawLine(new Vector3(Mathf.Log(i - 1), Mathf.Log(spectrum[i - 1]), 3), new Vector3(Mathf.Log(i), Mathf.Log(spectrum[i]), 3), Color.yellow);
			i++;
		}

		audio.GetOutputData (samples, 1);

		if (samples[0] > 0 && j > 5) {
						
			GameObject but = (GameObject)Instantiate (tile, this.transform.position, Quaternion.identity);
			but.transform.rotation = transform.rotation;
			but.GetComponent<TileScript>().MojoPos = Mojo.position;
			but.GetComponent<TileScript>().color = color;
			j = 0;
		}

		j++;


	}
}
