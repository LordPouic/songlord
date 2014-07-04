using UnityEngine;
using System.Collections;

public class ScoreScript : MonoBehaviour {


    public static int point;
    public static int multiplicateur;
    static private int nbRythmeTouch;
    static private float timer;
	// Use this for initialization
	void Start () {
        point = 0;
        multiplicateur = 1;
        nbRythmeTouch = 0;
        timer = 0;
    }
	
	// Update is called once per frame
	void Update () {
        this.GetComponent<TextMesh>().text = "point:" + point + " multiplicateur: X" + multiplicateur;

        timer += Time.deltaTime;
        if (timer >2.5)
        {

            nbRythmeTouch = 0;
            multiplicateur = 1;
            timer = 0;
            
        }
	}

    static public void addPoint()
    {
        point += multiplicateur;
    }

    static public void addMultiplicateur()
    {
        nbRythmeTouch++;
        timer = 0;
        if (nbRythmeTouch > 4)
        {
            multiplicateur++;
            nbRythmeTouch = 0;
        }
    }
}
