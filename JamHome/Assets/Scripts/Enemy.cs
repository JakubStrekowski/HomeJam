using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public Transform vision;
	
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Hero")
        {
            if (collision.gameObject.GetComponent<Hero>().isVisible)
            {
                Debug.Log("Oof");
                //game is lost
                collision.gameObject.GetComponent<Hero>().LoseGame();

            }
        }
    }



}
