using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCube : MonoBehaviour {

	
	void Update ()
    {

        transform.Translate(Input.GetAxis("Horizontal") * Time.deltaTime * 10, 0f, Input.GetAxis("Vertical") * Time.deltaTime * 10);

       float speedx = Input.GetAxis("Mouse X");

        float speedy = Input.GetAxis("Mouse Y");
        
        this.gameObject.transform.eulerAngles += new Vector3(speedy, speedx, 0);

    }
}
