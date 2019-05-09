﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{

    public float movementSpeed;
    public float runningSpeed;
    public float climbingSpeed;
    public Animator animator;
    public SpriteRenderer spriteRenderer;

    private bool isVisible;
    private bool isClimbing = false;
    private bool lockedInput = false;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


        Movement();
        if (Input.GetAxis("Horizontal") == 0)
        {
            StopMoving();
        }

        if (isClimbing)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, climbingSpeed * Time.deltaTime);
        }

    }

    private void Move(float speed)
    {
            animator.SetFloat("Speed", Mathf.Abs(speed * Time.deltaTime));


            GetComponent<Rigidbody2D>().velocity = new Vector2(speed * Time.deltaTime, GetComponent<Rigidbody2D>().velocity.y);

    }

    private void StopMoving()
    {
        animator.SetFloat("Speed", 0);

        GetComponent<Rigidbody2D>().velocity = new Vector2(0, GetComponent<Rigidbody2D>().velocity.y);
    }

    private void Movement()
    {
        if (!lockedInput)
        {
            if (Input.GetAxis("Sprint") > 0)
            {
                if (Input.GetAxis("Horizontal") > 0)
                {
                    spriteRenderer.flipX = false;
                    

                    Move(runningSpeed);
                }
                if (Input.GetAxis("Horizontal") < 0)
                {
                    spriteRenderer.flipX = true;

                    Move(-runningSpeed);
                }
            }
            else
            {
                if (Input.GetAxis("Horizontal") > 0)
                {
                    spriteRenderer.flipX = false;

                    Move(movementSpeed);
                }
                if (Input.GetAxis("Horizontal") < 0)
                {
                    spriteRenderer.flipX = true;

                    Move(-movementSpeed);
                }
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Ladder")
        {
            if (Input.GetAxis("Vertical") > 0)
            {
                if (isClimbing == false) ClimbLadder();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Ladder" && isClimbing)
        {
            isClimbing = false;
            lockedInput = false;
        }
    }

    private void ClimbLadder()
    {
        isClimbing = true;
        lockedInput = false;
        Debug.Log("wspinam sie");

    }


}