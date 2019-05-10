using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public Transform vision;
    public AudioClip yellSound;
	
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Hero")
        {
            if (collision.gameObject.GetComponent<Hero>().isVisible)
            {
                StartCoroutine("GameLostAnim");
                collision.gameObject.GetComponent<Hero>().LoseGame();

            }
        }
    }

    public void StartYelling()
    {
        StartCoroutine("GameLostAnim");
    }

    IEnumerator GameLostAnim()
    {
        GetComponent<Animator>().SetInteger("FoundUs", 1);
        GetComponent<AudioSource>().PlayOneShot(yellSound);
        yield return new WaitForSeconds(0.5f);
        GetComponent<Animator>().SetInteger("FoundUs", 2);
    }



}
