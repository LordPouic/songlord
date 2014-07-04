using UnityEngine;
using System.Collections;


public class RythmScript : MonoBehaviour {

	// Use this for initialization
	public GameObject[] balls;

	int j = 0;
    float time;
    bool popped;

	public float[] samples;
	void Start () {
       samples = new float[4];
       popped = false;
	}
	
	// Update is called once per frame
	void Update () {
        
		//samples = audio.GetOutputData(4, 0);
        //Debug.Log(samples[0] + " " + samples[1] + " " + samples[2] +" "+ samples[3]);


        float[] spectrum = audio.GetSpectrumData(64, 0, FFTWindow.BlackmanHarris);
        int i = 1;
       
        float sommeCaisseClaire=0;

        while (i < 63)
        {
            sommeCaisseClaire += spectrum[i];
            i++;
        }
        
        if (sommeCaisseClaire > 1.5 && !popped)
        {
           // Debug.Log("gros son" + sommeCaisseClaire);
            balls[j].animation.Play();
            popped = true;
            j++;

        }
        if (j>=3)
            j=0;

        if (popped)
        {
            time += Time.deltaTime;
        }
        if (time > 0.5)
        {
            time = 0;
            popped = false;
        }
	}
}
