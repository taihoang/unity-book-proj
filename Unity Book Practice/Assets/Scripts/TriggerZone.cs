using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class TriggerZone : MonoBehaviour {
    public AudioClip lockedSound;
    public Text textHints;
    public Light doorLight;
    
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            if(Inventory.charge == 4)
            {
                transform.FindChild("door").SendMessage("DoorCheck");
                if(GameObject.Find("PowerGUI"))
                {
                    Destroy(GameObject.Find("PowerGUI"));
                    doorLight.color = Color.green;
                }
            } else if (Inventory.charge > 0 && Inventory.charge < 4) {
                textHints.SendMessage("ShowHint", "This door won't budge... I guess it needs to be fully charged - maybe more power cells will help...");
                transform.FindChild("door").GetComponent<AudioSource>().PlayOneShot(lockedSound);
            } else
            {
                transform.FindChild("door").GetComponent<AudioSource>().PlayOneShot(lockedSound);
                col.gameObject.SendMessage("HUDon");
                textHints.SendMessage("ShowHint", "This door seems locked... maybe that generator needs power...");
            }
        }
    }
}
