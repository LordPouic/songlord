using UnityEngine;
using System.Collections;

public class LoadGame : MonoBehaviour {

    static public AudioClip[,] musiquePistes;
    static public AudioClip rythmePiste;
    static public int nbPiste;

    public GameObject[] tiles;
    private GameObject[] poppers;
    public GameObject popperPrefabs;

    private int sectionPlay;

    int compteurChangelentPooper;

	// Use this for initialization
    void Start()
    {
        compteurChangelentPooper = 0;
        poppers = new GameObject[nbPiste];
        for (int i = 0; i < nbPiste; i++)
        {

            GameObject g = new GameObject();
            if (i == 0)
            {
                g = Instantiate(popperPrefabs, new Vector3((float)15.539831, (float)10.07444808, 0), Quaternion.identity) as GameObject;
                g.GetComponent<PopperScript>().color = "red";
                g.GetComponent<PopperScript>().tile = tiles[i];
            }
            if (i == 1)
            {
                g = Instantiate(popperPrefabs, new Vector3((float)-10.389474, (float)10.07444808, 0), Quaternion.identity) as GameObject;
                g.GetComponent<PopperScript>().color = "green";
                g.GetComponent<PopperScript>().tile = tiles[i];
            }
            if (i == 2)
            {
                g = Instantiate(popperPrefabs, new Vector3((float)15.539831, (float)-15.07444808, 0), Quaternion.identity) as GameObject;
                g.GetComponent<PopperScript>().color = "blue";
                g.GetComponent<PopperScript>().tile = tiles[i];
            }
            if (i == 3)
            {
                g = Instantiate(popperPrefabs, new Vector3((float)-10.539831, (float)-15.07444808, 0), Quaternion.identity) as GameObject;
                g.GetComponent<PopperScript>().color = "yellow";
                g.GetComponent<PopperScript>().tile = tiles[i];
            }
            g.transform.parent = GameObject.Find("Mojo").GetComponent<Transform>();
            poppers[i] = g;
        }
        sectionPlay = 0;

        for (int i = 0; i < nbPiste; i++)
        {
            poppers[i].audio.clip = musiquePistes[i, sectionPlay];
            poppers[i].audio.Play();
        }

        GameObject.Find("PlaneRythme").GetComponent<RythmScript>().audio.clip = rythmePiste;
        GameObject.Find("PlaneRythme").audio.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (sectionPlay < 5)
        {
            bool musicFinish = true;
            for (int i = 0; i < nbPiste; i++)
            {
                if (poppers[i].audio.isPlaying)
                    musicFinish = false;
            }

            if (musicFinish)
            {
                sectionPlay++;
                for (int i = 0; i < nbPiste; i++)
                {
                    poppers[i].audio.clip = musiquePistes[i, sectionPlay];
                    poppers[i].audio.Play();
                }
            }
        }

        if (sectionPlay == 5)
        {
            bool musicFinish = true;
            for (int i = 0; i < nbPiste; i++)
            {
                if (poppers[i].audio.isPlaying)
                    musicFinish = false;
            }

            if (GameObject.Find("PlaneRythme").audio.isPlaying)
                musicFinish = false;

            if (musicFinish)
            {
               ScoreScriptGameOver.score = ScoreScript.point;
                Application.LoadLevel("ScoreScene");
            }
        }

        float somme1 = 0;
        float somme2 = 0;
        float somme3 = 0;
        float somme4 = 0;

        for (int i = 0; i < nbPiste; i++)
        {
            float[] spectrum = poppers[i].audio.GetSpectrumData(64, 0, FFTWindow.BlackmanHarris);

            int j = 0;
            while (j < 63)
            {
                if (i == 0)
                    somme1 += spectrum[i];
                if (i == 1)
                    somme2 += spectrum[i];
                if (i == 2)
                    somme3 += spectrum[i];
                if (i == 3)
                    somme4 += spectrum[i];
                /*Debug.DrawLine(new Vector3(i - 1, spectrum[i] + 10, 0), new Vector3(i, spectrum[i + 1] + 10, 0), Color.red);
                Debug.DrawLine(new Vector3(i - 1, Mathf.Log(spectrum[i - 1]) + 10, 2), new Vector3(i, Mathf.Log(spectrum[i]) + 10, 2), Color.cyan);
                Debug.DrawLine(new Vector3(Mathf.Log(i - 1), spectrum[i - 1] - 10, 1), new Vector3(Mathf.Log(i), spectrum[i] - 10, 1), Color.green);
                Debug.DrawLine(new Vector3(Mathf.Log(i - 1), Mathf.Log(spectrum[i - 1]), 3), new Vector3(Mathf.Log(i), Mathf.Log(spectrum[i]), 3), Color.yellow);*/
                j++;
            }
        }
        if (compteurChangelentPooper > 30)
        {
            if (somme1 > somme2 && somme1 > somme3 && somme1 > somme4)
            {
                foreach (GameObject g in poppers)
                {
                    g.GetComponent<PopperScript>().canPoop = false;
                }
                poppers[0].GetComponent<PopperScript>().canPoop = true;
            }
            if (somme2 > somme1 && somme2 > somme3 && somme2 > somme4)
            {
                foreach (GameObject g in poppers)
                {
                    g.GetComponent<PopperScript>().canPoop = false;
                }
                poppers[1].GetComponent<PopperScript>().canPoop = true;
         
            }
            if (somme3 > somme2 && somme3 > somme1 && somme3 > somme4)
            {
                foreach (GameObject g in poppers)
                {
                    g.GetComponent<PopperScript>().canPoop = false;
                }
                poppers[2].GetComponent<PopperScript>().canPoop = true;
            }
            if (somme4 > somme2 && somme4 > somme3 && somme4 > somme1)
            {
                foreach (GameObject g in poppers)
                {
                    g.GetComponent<PopperScript>().canPoop = false;
                }
                poppers[3].GetComponent<PopperScript>().canPoop = true;
            }
            compteurChangelentPooper = 0;
        }
        compteurChangelentPooper++;
	}
}
