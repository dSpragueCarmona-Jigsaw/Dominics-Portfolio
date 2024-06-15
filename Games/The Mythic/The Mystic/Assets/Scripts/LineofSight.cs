﻿ using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineofSight : MonoBehaviour {

    private RaycastHit vision;
    public float rayLength;
    //private bool isGrabbed;
    private Rigidbody grabbedObj;

	// Use this for initialization
	void Start () {

        rayLength = 4.0f;
        //isGrabbed = false;
		
	}
	
	// Update is called once per frame
	void Update () {

        Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward * rayLength, Color.red, 0.5f);

        if(Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out vision, rayLength))
        {

            if(vision.collider.tag =="Lethal")
            {
                Debug.Log(vision.collider.name);

            }

        }
		
	}
}
