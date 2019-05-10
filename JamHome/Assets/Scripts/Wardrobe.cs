using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wardrobe : MonoBehaviour {

    public AudioClip openSound;

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
        GetComponent<AudioSource>().PlayOneShot(openSound);
        yield return new WaitForSeconds(.2f);
        GetComponent<Animator>().SetInteger("playerState", 2);
    }

    IEnumerator StartClosingCoroutine()
    {
        GetComponent<Animator>().SetInteger("playerState", 1);
        GetComponent<AudioSource>().PlayOneShot(openSound);
        yield return new WaitForSeconds(.2f);
        GetComponent<Animator>().SetInteger("playerState", 0);
    }
}
