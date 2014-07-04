using UnityEngine;
using System.Collections;

public class ScoreScriptGameOver : MonoBehaviour {

    static public int score;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        this.GetComponent<TextMesh>().text = "Score:" + score;
	}
}
