using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (GM.lvlCompStatus == "Fail Fuel")
        {
            GetComponent<TextMesh>().text = "Out of Fuel";
            GM.lvlCompStatus = "Restart";
        }

        if (GM.lvlCompStatus == "Fail Asteroid")
        {
            GetComponent<TextMesh>().text = "The Darkness Consumes";
            GM.lvlCompStatus = "Restart";

        }
        if (GM.lvlCompStatus == "Fail Laser")
        {
            GetComponent<TextMesh>().text = "The Static Courses";
            GM.lvlCompStatus = "Restart";
        }
    }
}
