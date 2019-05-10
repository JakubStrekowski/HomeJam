using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wardrobe : MonoBehaviour {

	

    public void PlayOpenAnim()
    {
        StartCoroutine("StartOpeningCoroutine");
    }

    public void PlayCloseAnim()
    {
        StartCoroutine("StartClosingCoroutine");
    }

    IEnumerator StartOpeningCoroutine()
    {
        GetComponent<Animator>().SetInteger("playerState", 1);
        yield return new WaitForSeconds(.3f);
        GetComponent<Animator>().SetInteger("playerState", 2);
    }

    IEnumerator StartClosingCoroutine()
    {
        GetComponent<Animator>().SetInteger("playerState", 1);
        yield return new WaitForSeconds(.3f);
        GetComponent<Animator>().SetInteger("playerState", 0);
    }
}
