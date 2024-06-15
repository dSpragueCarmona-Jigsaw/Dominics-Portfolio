using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class ShipAnimations : MonoBehaviour
{


    Animator animator;

    public KeyCode moveL;
    public KeyCode moveR;
    public KeyCode moveUP;
    public KeyCode moveDOWN;

    public KeyCode moveL2;
    public KeyCode moveR2;
    public KeyCode moveUP2;
    public KeyCode moveDOWN2;

    public int laneNum = 2;


    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if ((Input.GetKeyDown(moveL)) && (laneNum > 1) && PauseMenu.GameisPaused == false && this.gameObject.transform.position.x > -.01f)
        {
            animator.SetTrigger("Fly Right");
            animator.SetTrigger("Fly Idle");
        }

        if ((Input.GetKeyDown(moveR)) && (laneNum < 3) && PauseMenu.GameisPaused == false && this.gameObject.transform.position.x < 2.9)
        {
            animator.SetTrigger("Fly Left");
            animator.SetTrigger("Fly Idle");
        }

        if ((Input.GetKeyDown(moveUP)) && (laneNum < 3) && PauseMenu.GameisPaused == false && this.gameObject.transform.position.y < 4.9)
        {
            animator.SetTrigger("Fly Down");
            animator.SetTrigger("Fly Idle");
        }

        if ((Input.GetKeyDown(moveDOWN)) && (laneNum < 3) && PauseMenu.GameisPaused == false && this.gameObject.transform.position.y > 1.2)
        {
            animator.SetTrigger("Fly Up");
            animator.SetTrigger("Fly Idle");
        }



    }
}
