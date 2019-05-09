using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBackForth : Enemy {

    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public float walkingSpeed=300f;
    private int currentDirection=1;
	
	// Update is called once per frame
	void Update () {
        var speed = currentDirection * walkingSpeed * Time.deltaTime;
        

        animator.SetFloat("Speed", Mathf.Abs(speed));
        GetComponent<Rigidbody2D>().velocity = new Vector2(speed, GetComponent<Rigidbody2D>().velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "EnemyBorder")
        {
            
            StartCoroutine("StayIdleCoroutine");
         
            currentDirection = currentDirection*-1;

            
        }
    }

    IEnumerator StayIdleCoroutine()
    {
        walkingSpeed = 0;

     

        yield return new WaitForSeconds(4f);
        walkingSpeed = 300;
        if (spriteRenderer.flipX)
        {
            spriteRenderer.flipX = false;

        }
        else
            spriteRenderer.flipX = true;
        vision.localScale = new Vector3(vision.localScale.x * -1, 1, 1);

    }


}
