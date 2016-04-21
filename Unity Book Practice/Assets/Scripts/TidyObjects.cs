using UnityEngine;
using System.Collections;

public class TidyObjects : MonoBehaviour {
    public float removeTime = 3.0f;
	// Use this for initialization
	void Start () {
        Destroy(gameObject, removeTime);
    }


    
}
