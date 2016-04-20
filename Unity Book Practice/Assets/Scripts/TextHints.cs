using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class TextHints : MonoBehaviour {
    float timer = 0.0f;
    // Use this for initialization
    void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	    if(GetComponent<Text>().enabled)
        {
            timer += Time.deltaTime;
            if(timer >=4)
            {
                GetComponent<Text>().enabled = false;
                timer = 0.0f;
            }
        }
	}
    void ShowHint(string message)
    {
        GetComponent<Text>().text = message;
       // GetComponent<Text>().text = message;
        if(!GetComponent<Text>().enabled)
        {
            GetComponent<Text>().enabled = true;
        }
    }
}
