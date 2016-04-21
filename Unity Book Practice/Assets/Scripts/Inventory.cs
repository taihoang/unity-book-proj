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
        RawImage matchHUD = Instantiate(matchGUIprefab, new Vector3(1.15f, 0.1f, 0), transform.rotation) as RawImage;
        matchGUI = matchHUD;
    }

    void OnControllerColliderHit(ControllerColliderHit col)
    {
        if(col.gameObject.name == "campfire")
        {
            LightFire(col.gameObject);
        }
    }

    void LightFire(GameObject campfire)
    {
        ParticleEmitter[] fireEmitters;
        fireEmitters = campfire.GetComponentsInChildren<ParticleEmitter>();
        foreach(ParticleEmitter emitter in fireEmitters)
        {
            emitter.emit = true;
        }
        Destroy(matchGUI);
        haveMatches = false;
        campfire.GetComponent<AudioSource>().Play(); 
    }
}
