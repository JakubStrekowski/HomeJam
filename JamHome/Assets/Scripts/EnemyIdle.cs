using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdle : Enemy {

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
        //tu idle patrzy na prost
        yield return new WaitForSeconds(3f);
        if (previousLook)
        {
            //flip??
            StartCoroutine("LookLeftCoroutine");
        }
        else
        {

            StartCoroutine("LookRightCoroutine");
        }
        

    }
    IEnumerator LookLeftCoroutine()
    {
        //tu idle patrzy w lewo
        yield return new WaitForSeconds(7f);
        previousLook = !previousLook;
        StartCoroutine("StayIdleCoroutine");
    }
    IEnumerator LookRightCoroutine()
    {
        //tu idle patrzy w prawo
        yield return new WaitForSeconds(7f);
        previousLook = !previousLook;
        StartCoroutine("StayIdleCoroutine");

    }
}
