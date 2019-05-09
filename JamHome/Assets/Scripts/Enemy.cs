using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Hero")
        {
            Debug.Log("Oof");
            //game is lost
            collision.gameObject.GetComponent<Hero>().LoseGame();
        }
    }



}
