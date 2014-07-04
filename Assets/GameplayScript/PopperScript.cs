using UnityEngine;
using System.Collections;

public class PopperScript : MonoBehaviour {

	// Use this for initialization
	private Transform Mojo;

	public GameObject tile;
	int j = 0;
    public bool canPoop;

	public float[] samples;

	public string color;

	void Start () {
        canPoop = false;
	}
	
	// Update is called once per frame
	void Update() {

        Mojo = GameObject.Find("Mojo").GetComponent<Transform>();

		transform.RotateAround(Mojo.position, new Vector3(0,0,1), 100 * Time.deltaTime);

        /*
		float[] spectrum = audio.GetSpectrumData(64, 0, FFTWindow.BlackmanHarris);
		int i = 1;
        float somme1= 0;
        float somme2 = 0;
        float somme3 = 0;
		while (i < 63) {
            if (i < 20)
            {
                somme1 += spectrum[i];
            }

            if (i < 40 && i > 20)
            {
                somme2 += spectrum[i];
            }

            if (i > 40)
            {
                somme3 += spectrum[i];
            }
			/*Debug.DrawLine(new Vector3(i - 1, spectrum[i] + 10, 0), new Vector3(i, spectrum[i + 1] + 10, 0), Color.red);
			Debug.DrawLine(new Vector3(i - 1, Mathf.Log(spectrum[i - 1]) + 10, 2), new Vector3(i, Mathf.Log(spectrum[i]) + 10, 2), Color.cyan);
			Debug.DrawLine(new Vector3(Mathf.Log(i - 1), spectrum[i - 1] - 10, 1), new Vector3(Mathf.Log(i), spectrum[i] - 10, 1), Color.green);
			Debug.DrawLine(new Vector3(Mathf.Log(i - 1), Mathf.Log(spectrum[i - 1]), 3), new Vector3(Mathf.Log(i), Mathf.Log(spectrum[i]), 3), Color.yellow);
			i++;
		}

        Debug.Log(somme1 + "=s1  " + somme2 + "=s2  " + somme3 + "=s3");

        if (somme1 > 0.95 && j>10)
        {
            GameObject but = (GameObject)Instantiate(tile, this.transform.position, Quaternion.identity);
            but.transform.rotation = transform.rotation;
            but.GetComponent<TileScript>().MojoPos = Mojo.position;
            but.GetComponent<TileScript>().color = color;
            j = 0;
        }
        if (somme2 > 0.0035 && j > 10)
        {
            GameObject but = (GameObject)Instantiate(tile, this.transform.position, Quaternion.identity);
            but.transform.rotation = transform.rotation;
            but.GetComponent<TileScript>().MojoPos = Mojo.position;
            but.GetComponent<TileScript>().color = color;
            j = 0;
        }

	    j++;
        */
        if (canPoop && j > 10)
        {
            GameObject but = (GameObject)Instantiate(tile, this.transform.position, Quaternion.identity);
            but.transform.rotation = transform.rotation;
            but.GetComponent<TileScript>().MojoPos = Mojo.position;
            but.GetComponent<TileScript>().color = color;
            j = 0;
        }
        j++;
	}
}
