using UnityEngine;
using System.Collections;

public class TargetHit : MonoBehaviour
{
    bool beenHit = false;
    Animation targetRoot;
    public AudioClip hitSound;
    public AudioClip resetSound;
    public float resetTime = 3.0f;

    // Use this for initialization
    void Start()
    {
        targetRoot = transform.parent.transform.parent.GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision theObject)
    {
        if (beenHit == false)
        {
            StartCoroutine("targetHit");
        }
    }

    IEnumerator targetHit()
    {
        GetComponent<AudioSource>().PlayOneShot(hitSound);
        targetRoot.Play("down");
        beenHit = true;
        CoconutWin.targets++;
        yield return new WaitForSeconds(resetTime);
        GetComponent<AudioSource>().PlayOneShot(resetSound);
        targetRoot.Play("up");
        beenHit = false;
        CoconutWin.targets--;
    }
}
