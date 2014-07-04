using UnityEngine;
using System.Collections;

public class FightScript : MonoBehaviour {

    public void OnMouseDown()
    {

        LoadGame.musiquePistes = new AudioClip[loadScene.nbPiste, 6];
        for (int i = 0; i < loadScene.nbPiste; i++)
        {
            for (int j = 0; j < 6; j++)
            {
                if (loadScene.musiquePistes[i, j].audio.clip != null)
                {

                    LoadGame.musiquePistes[i, j] = loadScene.musiquePistes[i, j].audio.clip;
                }
            }
        }

        LoadGame.rythmePiste = loadScene.caseRythm.audio.clip;
        LoadGame.nbPiste = loadScene.nbPiste;
        Application.LoadLevel("Gameplay");

    }
}
