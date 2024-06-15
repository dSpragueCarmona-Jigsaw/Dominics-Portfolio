using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    private GameObject wayPoint;
    private SpriteRenderer sr;

    private Vector3 wayPointPos;

    private float speed = 2f;
    private float distance;
    private float increaseSpeed = 10f;
    private float oldPos;
    private bool attacking = false;
    Animator animator;

    void Start()
    {
        wayPoint = GameObject.Find("wayPoint");
        sr = GetComponent<SpriteRenderer>();
        oldPos = transform.position.x;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {   
        wayPointPos = new Vector3(wayPoint.transform.position.x, wayPoint.transform.position.y, transform.position.z);
        distance = Vector2.Distance(wayPoint.transform.position, this.transform.position);
        if (distance > increaseSpeed)
        {
            transform.position = Vector3.MoveTowards(transform.position, wayPointPos, increaseSpeed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, wayPointPos, speed * Time.deltaTime);
        }
        if (oldPos < transform.position.x)
        {
            sr.flipX = true;
        }
        else if (oldPos > transform.position.x)
        {
            sr.flipX = false;
        }
        oldPos = transform.position.x;

        animator.SetBool("is_Attacking", attacking);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        string tag = col.gameObject.tag;

        if (tag == "Player")
        {
            attacking = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        attacking = false;
    }
}
