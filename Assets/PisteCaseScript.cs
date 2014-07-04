using UnityEngine;
using System.Collections;

public class PisteCaseScript : MonoBehaviour {


    public int piste;
    public int section;
    private bool moveBegin;
    public bool affected;
    public GameObject prefabsImage;

    public float speed = 0.1F;

	// Use this for initialization
	void Start () {
        moveBegin = false;
        affected = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (moveBegin && affected)
        {
            float[] placementPiste = { (float)-6.6, (float)-3.96, (float)-1.35, (float)1.27, (float)3.88, (float)6.52 };

            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                //touch delete vers le haut
                Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
                if ( ( (Mathf.Abs(touchDeltaPosition.x) < touchDeltaPosition.y) || touchDeltaPosition.y > 5) )
                {
                    audio.clip = null;
                    renderer.materials[0] = null;
                    if (GameObject.Find("BoutonMenu").GetComponent<BoutonMenuScript>().Instrument1.Rythmic)
                        renderer.material.color = Color.gray;
                    else renderer.material.color = Color.white;
                    affected = false;
                    moveBegin = false;
                    Destroy(loadScene.imagePisteAssigned[piste, section]);
                }

                //touch vers la droite
                else if (touchDeltaPosition.x > 6 && section <5)
                {
                    loadScene.musiquePistes[piste, section + 1].audio.clip = audio.clip;
                    loadScene.musiquePistes[piste, section + 1].renderer.materials[0] = null;
                    loadScene.musiquePistes[piste, section + 1].renderer.material.color = Color.green;
                    loadScene.musiquePistes[piste, section + 1].GetComponent<PisteCaseScript>().affected = true;
                    moveBegin = false;

                    if (loadScene.imagePisteAssigned[piste, section + 1] != null)
                        Destroy(loadScene.imagePisteAssigned[piste, section + 1]);

                    GameObject imageLoop = prefabsImage;
                    imageLoop.GetComponent<SpriteRenderer>().sprite = loadScene.imagePisteAssigned[piste, section].GetComponent<SpriteRenderer>().sprite;
                    GameObject g = Instantiate(imageLoop, new Vector3(placementPiste[section+1],(float)(piste * -1 - 1.35), 0), Quaternion.identity) as GameObject;
                    
                    loadScene.imagePisteAssigned[piste, section + 1] = g;
                   
                }

                    //touch vers la gauche
                else if (touchDeltaPosition.x < -6 && section >0)
                {
                    loadScene.musiquePistes[piste, section - 1].audio.clip = audio.clip;
                    loadScene.musiquePistes[piste, section - 1].renderer.materials[0] = null;
                    loadScene.musiquePistes[piste, section - 1].renderer.material.color = Color.green;
                    loadScene.musiquePistes[piste, section - 1].GetComponent<PisteCaseScript>().affected = true;
                    moveBegin = false;

                    if (loadScene.imagePisteAssigned[piste, section - 1] != null)
                        Destroy(loadScene.imagePisteAssigned[piste, section - 1]);

                    GameObject imageLoop = prefabsImage;
                    imageLoop.GetComponent<SpriteRenderer>().sprite = loadScene.imagePisteAssigned[piste, section].GetComponent<SpriteRenderer>().sprite;
                    GameObject g = Instantiate(imageLoop, new Vector3(placementPiste[section - 1], (float)(piste * -1 - 1.35), 0), Quaternion.identity) as GameObject;
                    loadScene.imagePisteAssigned[piste, section - 1] = g;
                }
            }
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            moveBegin = false;
        }
	}

    void OnMouseDown(){
        moveBegin = true;
		
	}

    void OnMouseUp()
    {
        moveBegin = false;
    }
}
