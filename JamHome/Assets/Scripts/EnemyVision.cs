using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVision : MonoBehaviour {

    public Enemy parentEnemy;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Hero")
        {
            Debug.Log("vision Oof");
            //game is lost
            collision.gameObject.GetComponent<Hero>().LoseGame();
        }
    }



}
