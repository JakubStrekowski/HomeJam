using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVision : MonoBehaviour {
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Hero")
        {
            if (collision.gameObject.GetComponent<Hero>().isVisible)
            {
                CheckForHero(collision.gameObject.GetComponent<Hero>());

            }
        }
    }

    private void CheckForHero(Hero hero)
    {
        LayerMask lm = LayerMask.GetMask("Hero", "Default");
        RaycastHit2D raycastHit = Physics2D.Raycast(transform.position,hero.head.position-transform.position,20,lm);
        if (raycastHit.collider!=null)
        {
            if (raycastHit.transform.tag=="Hero")
            {
                //game is lost
                hero.gameObject.GetComponent<Hero>().LoseGame();
            }
        }

        RaycastHit2D raycastHitLegs = Physics2D.Raycast(transform.position, hero.legs.position- transform.position, 30,lm);
        if (raycastHitLegs.collider!=null)
        {
            if (raycastHitLegs.collider.tag == "Hero")
            {
                //game is lost
                hero.gameObject.GetComponent<Hero>().LoseGame();
            }
        }
    }



}
