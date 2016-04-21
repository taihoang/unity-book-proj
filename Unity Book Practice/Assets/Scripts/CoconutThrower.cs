﻿using UnityEngine;
using System.Collections;
[RequireComponent(typeof(AudioSource))]

public class CoconutThrower : MonoBehaviour {
    public AudioClip throwSound;
    public Rigidbody coconutPrefab;
    public float throwSpeed = 30.0f;
    public static bool canThrow = false;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if(Input.GetButtonDown("Fire1") && canThrow)
        {
            GetComponent<AudioSource>().PlayOneShot(throwSound);
            Rigidbody newCoconut = Instantiate(coconutPrefab, transform.position, transform.rotation) as Rigidbody;
            newCoconut.name = "coconut";
            newCoconut.velocity = transform.forward * throwSpeed;
            Physics.IgnoreCollision(transform.root.GetComponent<Collider>(), newCoconut.GetComponent<Collider>(), true);
        }
	}
}
