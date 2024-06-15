using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingPlatform : MonoBehaviour
{

    public float speed;
    public int startingPoint;
    //array of transform points
    public Transform[] points;

    //index of arry
    private int i;

    // Start is called before the first frame update
    void Start()
    {
        //setting position of platform to one of the starting points
        transform.position = points[startingPoint].position;
    }

    // Update is called once per frame
    void Update()
    {
        //checks distance of platform and the points
        if (Vector2.Distance(transform.position, points[i].position) < 0.02f)
        {
            i++;
            if (i == points.Length)
            {
                i = 0;
            }
        }

        transform.position = Vector2.MoveTowards(transform.position, points[i].position, speed * Time.deltaTime);
    }

    //makes the player a child of platform to move with it
    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.transform.SetParent(transform);
    }

    //removes it from platform to move indepently
    private void OnCollisionExit2D(Collision2D collision)
    {
        collision.transform.SetParent(null);
    }
}
