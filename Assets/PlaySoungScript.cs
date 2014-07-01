using UnityEngine;
using System.Collections;

public class PlaySoungScript : MonoBehaviour
{

    private bool isLaunched;
    private int sectionPlay;
    private int nbPiste;
    private GameObject[,] g;

    //gestion du tactile pour les pistes
    public bool touchBegin;
    public float deltaChangeX;
    public float deltaChangeY;
    public int xCaseTouched;
    public int yCaseTouched;

    void Start()
    {
        isLaunched = false;
        sectionPlay = 0;

    }

    void OnMouseDown()
    {
        if (isLaunched)
        {
            isLaunched = false;
            for (int i = 0; i < nbPiste; i++)
            {
                //Debug.Log("section :" + sectionPlay + " Piste:" + i);
                if (g[i, sectionPlay].audio.isPlaying)
                {
                    g[i, sectionPlay].audio.Stop();
                }
            }
        }
        //lancement des 1ere musique 
        if (!isLaunched)
        {

            nbPiste = loadScene.nbPiste;
            g = loadScene.musiquePistes;

            //coupure des autres sons
            for (int i = 0; i < nbPiste; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    loadScene.musiquePistes[i, j].audio.Stop();
                }
            }




            for (int i = 0; i < nbPiste; i++)
            {
                //Debug.Log("play " + sectionPlay + " " + i);
                g[i, sectionPlay].audio.Play();


            }
            isLaunched = true;
        }
    }

    void Update()
    {
        if (sectionPlay >= 5)
        {
            Debug.Log("FIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIiiN");
            sectionPlay = 0;
            isLaunched = false;
        }

        if (isLaunched)
        {
            //test sur la fin des sik en cours
            bool sectionFinish = true;
            for (int i = 0; i < nbPiste; i++)
            {
                //Debug.Log("section :" + sectionPlay + " Piste:" + i);
                if (g[i, sectionPlay].audio.isPlaying)
                {
                    sectionFinish = false;
                }
            }

            //si les siks sont finis on lance les suivantes
            if (sectionFinish)
            {
                sectionPlay++;
                for (int i = 0; i < nbPiste; i++)
                {
                    g[i, sectionPlay].audio.Play();


                }
            }
        }

        if (Input.touches.Length > 0)
            audio.Play();
        //test si un touch est detecté 
        foreach (Touch touch in Input.touches)
        {

            if (touch.phase == TouchPhase.Began)
            {
                for (int i = 0; i < loadScene.nbPiste; i++)
                {
                    for (int j = 0; j < 6; j++)
                    {
                        if (touch.position.x >= loadScene.musiquePistes[i, j].transform.position.x - 0.5 &&
                            touch.position.x <= loadScene.musiquePistes[i, j].transform.position.x + 0.5 &&
                            touch.position.y >= loadScene.musiquePistes[i, j].transform.position.y - 0.5 &&
                            touch.position.y <= loadScene.musiquePistes[i, j].transform.position.y + 0.5)
                        {
                            touchBegin = true;
                            xCaseTouched = i;
                            yCaseTouched = j;
                        }
                    }
                }
            }

            if (touchBegin)
            {
                deltaChangeX += touch.deltaPosition.x;
                deltaChangeY += touch.deltaPosition.y;

                Debug.Log(deltaChangeX + "--" + deltaChangeY);
            }

        }

      
    }
}
