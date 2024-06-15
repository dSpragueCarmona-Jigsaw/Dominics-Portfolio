using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContolMusic : MonoBehaviour {

    public GameObject MenuMusic;

	
	void Update () {
        if (GameObject.Find("Menu Music(Clone)") == null)
        {
            Instantiate(MenuMusic);
        }
    }
}
