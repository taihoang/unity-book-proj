using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {
    public static int charge = 0;
    public AudioClip collectSound;
    public Texture2D[] hudCharge;
    public RawImage chargeHudGUI;
    public Texture2D[] meterCharge;
    public Renderer meter;
    bool haveMatches = false;
    public RawImage matchGUIprefab;
    RawImage matchGUI;
    public Text textHints;
    bool fireIsLit = false;
    //public Particle[] fireEmitters;
    // Use this for initialization
    void Start()
    {
        charge = 0;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void CellPickup()
    {
        HUDon();
        AudioSource.PlayClipAtPoint(collectSound, transform.position);
        charge++;
        chargeHudGUI.texture = hudCharge[charge];
        //HUDon();

        meter.material.mainTexture = meterCharge[charge];
    }
  
    void HUDon()
    {
        if(!chargeHudGUI.enabled)
        {
            chargeHudGUI.enabled = true;

        }
    }

    void MatchPickup()
    {
        haveMatches = true;
        AudioSource.PlayClipAtPoint(collectSound, transform.position);
       // GameObject matchHUD = Instantiate(matchGUIprefab, new Vector3(0, 0, 0), transform.rotation) as GameObject;
      //  matchGUI = matchHUD;

        if(!matchGUIprefab.enabled)
        {
            matchGUIprefab.enabled = true;
        }
    }

    void OnControllerColliderHit(ControllerColliderHit col)
    {
        if(col.gameObject.name == "campfire")
        {
            if (haveMatches && !fireIsLit)
            {
                LightFire(col.gameObject);
            } else if(!haveMatches && !fireIsLit)
            {
                textHints.SendMessage("ShowHint", "I could use this campfire to signal for help... if only I could light it...");
            }
        }
    }

    void LightFire(GameObject campfire)
    {
        fireIsLit = true;
        ParticleSystem[] fireEmitters;
        fireEmitters = campfire.GetComponentsInChildren<ParticleSystem>();
        foreach(ParticleSystem emitter in fireEmitters)
        {
            print(emitter);
            emitter.Play();
        }
        matchGUIprefab.enabled = false;
        //  Destroy(matchGUI);
        haveMatches = false;
        campfire.GetComponent<AudioSource>().Play(); 
    }
}
