using UnityEngine;
using System.Collections;

public class loadScene : MonoBehaviour {

    static public int nbPiste;
    static public GameObject[,] musiquePistes;
    static public GameObject[,] imagePisteAssigned;
    static public GameObject imagePisteAssignedRythm;
    public GameObject casePiste;
    public GameObject caseRythmPrefabs;
    static public GameObject caseRythm;


	// Use this for initialization
	void Start () {
        nbPiste = 3;
        float[] placementPiste = { (float)-6.6, (float)-3.96, (float)-1.35, (float)1.27, (float)3.88, (float)6.52 };
        musiquePistes = new GameObject[nbPiste,6];
        imagePisteAssigned = new GameObject[nbPiste, 6];
        for (int i = 0; i < nbPiste; i++)
        {
            for (int j = 0; j < 6; j++)
            {
                GameObject g = (GameObject)Instantiate(casePiste, new Vector3((placementPiste[j]), (float)(i * -1 - 1.35), 0), Quaternion.identity);
                g.GetComponent<PisteCaseScript>().piste = i;
                g.GetComponent<PisteCaseScript>().section = j;
                musiquePistes[i, j] = g;
            }
        }

        GameObject grandeCase= (GameObject)Instantiate(caseRythmPrefabs, new Vector3((float)-0.10, (float)(- 0.35), 0), Quaternion.identity);
        caseRythm = grandeCase;
	}    
}
