using System.Collections;
using UnityEngine;

public class SpinSide : MonoBehaviour
{

    public float speed = 10f;

    void Update()

    {
        transform.Rotate(Vector3.forward, speed * Time.deltaTime);
        
    }
}