using UnityEngine;
using System.Collections;

public class DragAndDrop : MonoBehaviour {

    public int x, y;
    private bool hasBeenDragged;
    public GameObject prefabsImage; 
    
	// Use this for initialization
	void Start () {
        hasBeenDragged = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//Script to drag an object in world space using the mouse
	
	
	Vector3 screenSpace;
	Vector3 offset;
	
	void OnMouseDown(){
		//translate the cubes position from the world to Screen Point
		screenSpace = Camera.main.WorldToScreenPoint(transform.position);
		
		//calculate any difference between the cubes world position and the mouses Screen position converted to a world point  
		offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y, screenSpace.z));
		
	}

    void OnMouseUp()
    {

        if (hasBeenDragged)
        {
            
            hasBeenDragged = false;

            for (int i = 0; i < loadScene.nbPiste; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    if ( this.transform.position.x >= loadScene.musiquePistes[i, j].transform.position.x -0.5 &&
                        this.transform.position.x <= loadScene.musiquePistes[i, j].transform.position.x +0.5 &&
                        this.transform.position.y >= loadScene.musiquePistes[i, j].transform.position.y -0.5 &&
                        this.transform.position.y <= loadScene.musiquePistes[i, j].transform.position.y +0.5)
                    {
                        this.audio.Stop();
                        loadScene.musiquePistes[i, j].audio.clip = this.audio.clip;
                        loadScene.musiquePistes[i, j].renderer.materials[0]= null;
                        loadScene.musiquePistes[i, j].renderer.material.color = Color.green;
                        loadScene.musiquePistes[i, j].GetComponent<PisteCaseScript>().affected = true;

                        if (loadScene.imagePisteAssigned[i, j] != null)
                            Destroy(loadScene.imagePisteAssigned[i, j]);
                        float[] placementPiste = { (float)-6.6, (float)-3.96, (float)-1.35, (float)1.27, (float)3.88, (float)6.52 };
                        GameObject imageLoop = prefabsImage;
                        imageLoop.GetComponent<SpriteRenderer>().sprite = this.GetComponent<SpriteRenderer>().sprite;
                        GameObject g = Instantiate(imageLoop, new Vector3(placementPiste[j], (float)(i * -1 - 0.35), 0), Quaternion.identity) as GameObject;
                        loadScene.imagePisteAssigned[i, j] = g;
                        Debug.Log(loadScene.imagePisteAssigned[i,j].ToString());
                        
                    }
                }
            }

            this.transform.position = new Vector3(x, y, 0);
        }
    }
	
	/*
    OnMouseDrag is called when the user has clicked on a GUIElement or Collider and is still holding down the mouse.
    OnMouseDrag is called every frame while the mouse is down.
    */
	
	void OnMouseDrag () {
		
        
		//keep track of the mouse position
		var curScreenSpace =new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenSpace.z);    
		
		//convert the screen mouse position to world point and adjust with offset
		var curPosition = Camera.main.ScreenToWorldPoint(curScreenSpace) + offset;
		
		//update the position of the object in the world
		transform.position = curPosition;
        hasBeenDragged = true;
	}

}
