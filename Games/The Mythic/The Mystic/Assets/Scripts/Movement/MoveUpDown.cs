using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUpDown : MonoBehaviour
{
    public Vector3 pointA;
    public Vector3 pointB;
   

    IEnumerator Start()
    {
        var pointA = transform.position;
        var pointB = new Vector3(pointA.x,pointA.y + 5, pointA.z);
        if(this.gameObject.name == "Book")
        {
           pointB = new Vector3(pointA.x, pointA.y + .1f, pointA.z);
        }
        while (true)
        {
            yield return StartCoroutine(MoveObject(transform, pointA, pointB, 3f));
            yield return StartCoroutine(MoveObject(transform, pointB, pointA, 3f));
        }

    }

    IEnumerator MoveObject(Transform thisTransform, Vector3 startPos, Vector3 endPos, float time)
    {
        var i = 0.0f;
        var rate = 5.0f / time;
        while (i < 1.0f)
        {
            i += Time.deltaTime * rate;
            thisTransform.position = Vector3.Lerp(startPos, endPos, i);
            yield return null;
        }
    }
}