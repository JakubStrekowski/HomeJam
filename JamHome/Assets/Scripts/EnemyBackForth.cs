using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBackForth : MonoBehaviour {

    public Animator animator;
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
            currentDirection = currentDirection*-1;
        }
    }



}
