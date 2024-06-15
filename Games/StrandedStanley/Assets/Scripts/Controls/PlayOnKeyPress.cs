using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayOnKeyPress : MonoBehaviour
{
    //array for sound effects
    public AudioSource[] keySound;
     

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // used for specific key press
    void Update()
    {
        if (Input.GetKey(KeyCode.D) && PauseMenu.GameisPaused == false)
        {
            keySound[0].Play();
        }

        if (Input.GetKey(KeyCode.A) && PauseMenu.GameisPaused == false)
        {
            keySound[1].Play();
        }

        if (Input.GetKeyDown(KeyCode.Space) && PauseMenu.GameisPaused == false && Player_Script.canJump == true)
        {
            keySound[2].Play();
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && PauseMenu.GameisPaused == false && Player_Script.canDash == true)
        {
            keySound[3].Play();
        }

    }
}
