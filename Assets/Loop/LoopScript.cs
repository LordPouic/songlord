using UnityEngine;
using System.Collections;

public class LoopScript : MonoBehaviour {

    void OnMouseDown()
    {
        if (!this.audio.isPlaying)
        {
            foreach (GameObject g in GameObject.Find("BoutonMenu").GetComponent<BoutonMenuScript>().loopList)
            {
                g.audio.Stop();
            }
            audio.Play();
        }
    }
}
