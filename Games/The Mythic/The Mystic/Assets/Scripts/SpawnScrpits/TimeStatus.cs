using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeStatus : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    // this gets the ending screen text for how long you flew
    void Update() {
        if (gameObject.name == "Timetxt")
        {
            float timetotalint = Mathf.Floor(GM.timeTotal);
            GetComponent<TextMesh>().text = "Time Flew : " + timetotalint;
        }
        
    }
}
