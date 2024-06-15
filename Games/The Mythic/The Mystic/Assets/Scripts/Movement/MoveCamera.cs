using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour {



    // Use this for initialization
    void Start()
    {

    }
	
	// Update is called once per frame
	void Update () {

     GetComponent<Rigidbody> ().velocity = new Vector3 (0, 0, 4 * GM.zVelAdj);
        try
        {
            Vector3 Start = this.gameObject.transform.position;
            Vector3 End = new Vector3(GameObject.Find("Space Ship").transform.position.x, GameObject.Find("Space Ship").transform.position.y + 1, this.gameObject.transform.position.z);
            transform.position = Vector3.Lerp( Start ,End,.2f);

        }
        catch{

        }

    }
}
