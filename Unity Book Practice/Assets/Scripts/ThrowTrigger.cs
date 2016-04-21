using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ThrowTrigger : MonoBehaviour {
    public RawImage crosshair;
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
