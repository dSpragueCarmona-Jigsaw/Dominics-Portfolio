using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    public bool Rotationisz;
    public float speed = 10f;
    void Update()
    {

        if (!Rotationisz)
        {
            transform.Rotate(Vector3.up, speed * Time.deltaTime);
        }
        if (Rotationisz)
        {
            transform.Rotate(new Vector3(0,0,1), speed * Time.deltaTime);
        }
        // this just has the change over time for a spin on items
    }
    void OnTriggerEnter(Collider other)
    {
        if (gameObject.name == "Destroyer")
            Destroy(other.gameObject);

    }
}

