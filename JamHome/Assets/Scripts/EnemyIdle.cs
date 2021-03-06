﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdle : Enemy {

    public Animator animator;
    int currentState0;
    bool previousLook = false; //czy poprzednio patrzyl w prawo
	// Use this for initialization
	void Start () {
        int chance=Random.Range(0, 2);
        if (chance == 0)
        {
            StartCoroutine("LookLeftCoroutine");
        }
        else
        {
            StartCoroutine("LookRightCoroutine");
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator StayIdleCoroutine()
    {
        animator.SetInteger("State", 0);

        //tu idle patrzy na prost
        vision.gameObject.SetActive(false);
        yield return new WaitForSeconds(3f);
        vision.gameObject.SetActive(true);
        if (previousLook)
        {
            animator.SetInteger("State", 1);
            vision.localScale = new Vector3(vision.localScale.x * -1, 1, 1);
            StartCoroutine("LookLeftCoroutine");
        }
        else
        {
            animator.SetInteger("State", 2);
            vision.localScale = new Vector3(vision.localScale.x * -1, 1, 1);
            StartCoroutine("LookRightCoroutine");
        }
        

    }
    IEnumerator LookLeftCoroutine()
    {
        //tu idle patrzy w lewo
        yield return new WaitForSeconds(5f);
        previousLook = !previousLook;
        StartCoroutine("StayIdleCoroutine");
    }
    IEnumerator LookRightCoroutine()
    {
        //tu idle patrzy w prawo
        yield return new WaitForSeconds(5f);
        previousLook = !previousLook;
        StartCoroutine("StayIdleCoroutine");

    }
}
