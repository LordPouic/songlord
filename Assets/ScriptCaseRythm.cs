using UnityEngine;
using System.Collections;

public class ScriptCaseRythm : MonoBehaviour {

    public int piste;
    public int section;
    private bool moveBegin;
    public bool affected;
    public GameObject prefabsImage;

    public float speed = 0.1F;

    // Use this for initialization
    void Start()
    {
        moveBegin = false;
        affected = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (moveBegin && affected)
        {
            
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
                if (((Mathf.Abs(touchDeltaPosition.x) < touchDeltaPosition.y) || touchDeltaPosition.y > 5))
                {
                    audio.clip = null;
                    renderer.materials[0] = null;
                    if (GameObject.Find("BoutonMenu").GetComponent<BoutonMenuScript>().Instrument1.Rythmic)
                        renderer.material.color = Color.white;
                    else renderer.material.color = Color.gray;
                    affected = false;
                    moveBegin = false;
                    Destroy(loadScene.imagePisteAssignedRythm);
                }
            }
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            moveBegin = false;
        }
    }

    void OnMouseDown()
    {
        moveBegin = true;

    }

    void OnMouseUp()
    {
        moveBegin = false;
    }
}
