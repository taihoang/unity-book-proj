using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ThrowTrigger : MonoBehaviour {
    public RawImage crosshair;
    public Text textHints;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider col)
    {

        if(col.gameObject.tag == "Player")
        {
            CoconutThrower.canThrow = true;
            crosshair.enabled = true;
            if(!CoconutWin.haveWon)
            {
                textHints.SendMessage("ShowHint","\n\n\n\n\n\n\nThere's a power cell attached to this game, \nmaybe I'll win it if I can knock down all of the targets...");
            }
        }
    }

    void OnTriggerExit(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {
            CoconutThrower.canThrow = false;
            crosshair.enabled = false;
        }
    }
}
