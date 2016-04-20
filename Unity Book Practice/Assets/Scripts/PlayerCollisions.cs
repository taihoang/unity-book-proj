using UnityEngine;
using System.Collections;

public class PlayerCollisions : MonoBehaviour {
    GameObject currentDoor;

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if(Physics.Raycast (transform.position, transform.forward,out hit, 3))
        {
            if (hit.collider.gameObject.tag == "playerDoor")
            {
                currentDoor = hit.collider.gameObject;
                currentDoor.SendMessage("DoorCheck");
            }
        }
    }





    /*void Update () { //open door on collision
	    if(doorIsOpen) {
            doorTimer += Time.deltaTime;
            if(doorTimer > doorOpenTime)
            {
                Door(doorShutSound, false, "doorshut", currentDoor); 
                doorTimer = 0.0f;
            }
        }
	}

    
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.gameObject.tag == "playerDoor" && doorIsOpen == false)
        {
            currentDoor = hit.gameObject;
            Door(doorOpenSound, true, "dooropen", currentDoor);
        
        }

    }
    

    void Door(AudioClip aClip, bool openCheck, string animName, GameObject thisDoor)
    {
        thisDoor.GetComponent<AudioSource>().PlayOneShot(aClip);
        doorIsOpen = openCheck;
        thisDoor.transform.parent.GetComponent<Animation>().Play(animName);
    }*/
}
