using UnityEngine;
using System.Collections;
using Assets;
using System.Collections.Generic;

public class BoutonMenuScript : MonoBehaviour {

    public GameObject menu;
    private Instrument instrument;

    internal Instrument Instrument1
    {
        get { return instrument; }
        set { instrument = value; }
    }
    public List<GameObject> loopList;

    void Start()
    {
        loopList = new List<GameObject>();
    }

    internal Instrument Instrument
    {
        get { return instrument; }
        set { instrument = value; }
    }
    public GameObject prefabsBoutonLoop;

    void OnMouseDown()
    {
        menu.SetActive(!menu.active);
    }

    public void LoadLoop()
    {

        foreach (GameObject g in loopList)
        {
            Destroy(g, 2);
            g.active = false;
        }
        loopList.Clear();

        

        for (int i=0 ; i < instrument.EmplacementsMusique.Count ; i++)
        {
            GameObject boutonLoop = prefabsBoutonLoop;
            boutonLoop.audio.clip = Resources.Load(instrument.EmplacementsMusique[i]) as AudioClip;
            boutonLoop.GetComponent<DragAndDrop>().x = i * 2 - 4;
            boutonLoop.GetComponent<DragAndDrop>().y = 4;
            boutonLoop.GetComponent<SpriteRenderer>().sprite = Resources.Load(instrument.EmplacementTexture, typeof(Sprite)) as Sprite;
            GameObject g = (GameObject)Instantiate(boutonLoop, new Vector3((float)i * 2 - 4, (float)4.2, 0), Quaternion.identity);
            loopList.Add(g);

        }

        if (instrument.Rythmic)
        {
            for (int i = 0; i < loadScene.nbPiste; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    if (loadScene.musiquePistes[i,j].renderer.material.color != Color.green)
                        loadScene.musiquePistes[i, j].renderer.material.color = Color.gray;
                }
            }
            if (loadScene.caseRythm.renderer.material.color != Color.green)
                loadScene.caseRythm.renderer.material.color = Color.white;
        }
        else
        {
            for (int i = 0; i < loadScene.nbPiste; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    if (loadScene.musiquePistes[i, j].renderer.material.color != Color.green)
                        loadScene.musiquePistes[i, j].renderer.material.color = Color.white;
                }
            }
            if (loadScene.caseRythm.renderer.material.color != Color.green)
                loadScene.caseRythm.renderer.material.color = Color.gray;
        }
    }
}
