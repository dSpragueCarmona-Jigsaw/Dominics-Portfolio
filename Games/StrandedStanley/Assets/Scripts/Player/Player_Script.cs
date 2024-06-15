using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;
using System;

public class Player_Script : MonoBehaviour
{
    //audios for sound collision
    public AudioSource resourceSound;
    public AudioSource slurpingSound;
    public AudioSource gruntSound;

    public int deathMenu;

    //health and hunger
    public Image healthImage;
    public Image hungerImage;

    //Stats
    public float minHP = 0f;
    public float maxHP = 100f;
    public float hp = 100f;
    public float minHunger = 0f;
    public float maxHunger = 100f;
    public float hunger = 100f;
    public float hungerDepletion = -1f;
    public float healthFraction;
    public float hungerFraction;

    //Animation Variables
    private SpriteRenderer sr;
    private Animator animator;

    //Movement variables
    private float horizontalInput;
    public float speed = 5f;
    public bool right = true;
    private Rigidbody2D rb;
    public float jump;
    public static bool canJump = true;

    //Dash variables
    public static bool canDash = true;
    private bool isDashing;
    public float dash;
    private float dashingtime = 0.2f;
    private float dashingCooldown = 1f;

    //Waypoint
    private GameObject wayPoint;
    private float timer = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        wayPoint = GameObject.Find("wayPoint");
        canDash = true;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Update Waypoint
        if(timer > 0)
        {
            timer -= Time.deltaTime;
        }
        if(timer <= 0)
        {
            UpdateWaypointPosition();
            timer = 0.5f;
        }

        //Animation Controls
        sr.flipX = !right;
        animator.SetBool("isJumping", !canJump);
        animator.SetBool("isDashing", isDashing);
        animator.SetFloat("xVelocity", Math.Abs(rb.velocity.x));
        animator.SetFloat("yVelocity", rb.velocity.y);

        //Health / Hunger to UI
        healthFraction = Mathf.Clamp01(hp / maxHP);
        healthImage.fillAmount = healthFraction;

        hungerFraction = Mathf.Clamp01(hunger / maxHunger);
        hungerImage.fillAmount = hungerFraction;

        //Hunger Depletion
        hunger = Mathf.Clamp(hunger + hungerDepletion * Time.deltaTime, minHunger, maxHunger);
        if (hunger == 0)
        {
            hp = Mathf.Clamp(hp + hungerDepletion * Time.deltaTime, minHP, maxHP);
        }

        if (hp == 0)
        {
            SceneManager.LoadScene(deathMenu);
        }

        //Movement controls
        if (isDashing) { return; }
        horizontalInput = Input.GetAxis("Horizontal");

        if (horizontalInput > 0)
        {
            right = true;
        }
        if (horizontalInput < 0)
        {
            right = false;
        }

        rb.velocity = new Vector2(horizontalInput * speed, rb.velocity.y);

        /*
        if (Input.GetKey(KeyCode.D) && PauseMenu.GameisPaused == false)
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
            //transform.position += new Vector3(speed * Time.deltaTime, 0f, 0f);
            right = true;  
        }

        if (Input.GetKey(KeyCode.A) && PauseMenu.GameisPaused == false)
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
            //transform.position -= new Vector3(speed * Time.deltaTime, 0f, 0f);
            right = false;
        }
        */

        if (Input.GetKeyDown(KeyCode.Space) && PauseMenu.GameisPaused == false && canJump == true) 
        {
            rb.velocity = new Vector2(rb.velocity.x, jump);
            canJump = false;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash && PauseMenu.GameisPaused == false)
        {
            if (right)
            {
                
                StartCoroutine(Dash_Right());
            }
            else
            {
                StartCoroutine(Dash_Left());
            }
        }

    }

    void UpdateWaypointPosition()
    {
        wayPoint.transform.position = transform.position;
    }
    
    //Check Collision object and perform corisponding code
    private void OnTriggerEnter2D(Collider2D col)
    {
        string tag = col.gameObject.tag;
        
        switch (tag)
        {
            case "Resource":
                ScoreManager.instance.AddResource();
                resourceSound.Play();
                break;
            case "Food":
                hunger += 15;
                slurpingSound.Play();
                break;
            case "Ghost":
                hp -= 20;
                gruntSound.Play();
                break;
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        string tag = col.gameObject.tag;

        switch (tag)
        {
            case "Ground":
                canJump = true;
                break;
        }
    }
    /*
    private IEnumerator Dash_Right()
    {
        canDash = false;
        isDashing = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.velocity = new Vector2(dash, rb.velocity.y);
        yield return new WaitForSeconds(dashingtime);
        rb.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }

    private IEnumerator Dash_Left()
    {
        canDash = false;
        isDashing = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.velocity = new Vector2(-dash, rb.velocity.y);
        yield return new WaitForSeconds(dashingtime);
        rb.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }
    */
    private IEnumerator Dash_Right()
    {
        canDash = false;
        isDashing = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.velocity = new Vector2(transform.localScale.x * dash, 0f);
        yield return new WaitForSeconds(dashingtime);
        rb.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }

    private IEnumerator Dash_Left()
    {
        canDash = false;
        isDashing = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.velocity = new Vector2(transform.localScale.x * -dash, 0f);
        yield return new WaitForSeconds(dashingtime);
        rb.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }
    
}
