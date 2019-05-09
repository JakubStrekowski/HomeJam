using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hero : MonoBehaviour
{

    public float movementSpeed;
    public float runningSpeed;
    public float climbingSpeed;
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public Camera mainCamera;

    public bool isVisible = true;
    private bool isClimbing = false;
    private bool lockedInput = false;



	
	// Update is called once per frame
	void Update () {
        Movement();
        if (Input.GetAxis("Horizontal") == 0)
        {
            StopMoving();
        }
        if (isClimbing)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, climbingSpeed * Time.deltaTime);
        }
    }

    private void Move(float speed)
    {
            animator.SetFloat("Speed", Mathf.Abs(speed * Time.deltaTime));
            GetComponent<Rigidbody2D>().velocity = new Vector2(speed * Time.deltaTime, GetComponent<Rigidbody2D>().velocity.y);

    }

    private void StopMoving()
    {
        animator.SetFloat("Speed", 0);

        GetComponent<Rigidbody2D>().velocity = new Vector2(0, GetComponent<Rigidbody2D>().velocity.y);
    }

    private void Movement()
    {
        if (!lockedInput)
        {
            if (Input.GetAxis("Sprint") > 0)
            {
                if (Input.GetAxis("Horizontal") > 0)
                {
                    spriteRenderer.flipX = false;
                    

                    Move(runningSpeed);
                }
                if (Input.GetAxis("Horizontal") < 0)
                {
                    spriteRenderer.flipX = true;

                    Move(-runningSpeed);
                }
            }
            else
            {
                if (Input.GetAxis("Horizontal") > 0)
                {
                    spriteRenderer.flipX = false;

                    Move(movementSpeed);
                }
                if (Input.GetAxis("Horizontal") < 0)
                {
                    spriteRenderer.flipX = true;

                    Move(-movementSpeed);
                }
            }
        }
        else
        {
            if (!isVisible)
            {
                if (Input.GetAxis("Horizontal") != 0)
                {
                    HideStop();
                }
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Ladder")
        {
            if (Input.GetAxis("Vertical") > 0)
            {
                if (isClimbing == false) ClimbLadder();

            }
        }
        if (collision.tag == "Wardrobe" && !lockedInput)
        {
            collision.gameObject.GetComponent<ShowUIElement>().EnableUI();
            if (Input.GetAxis("Vertical") > 0)
            {
                Hide();
            }
        }

        if (collision.tag == "LadderEnd")
        {
            collision.gameObject.GetComponent<ShowUIElement>().EnableUI();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Ladder" && isClimbing)
        {
            isClimbing = false;
            lockedInput = false;
        }
        if (collision.tag == "Wardrobe")
        {
            collision.gameObject.GetComponent<ShowUIElement>().DisableUI();
        }
        if (collision.tag == "LadderEnd")
        {
            collision.gameObject.GetComponent<ShowUIElement>().DisableUI();
        }
    }

    private void ClimbLadder()
    {
        isClimbing = true;
        lockedInput = false;
    }

    private void Hide()
    {
        
        lockedInput = true;
        StartCoroutine("StartHidingCoroutine");
       // StartCoroutine("ZoomOutCam");
    }

    private void HideStop()
    {
        isVisible = true;
        lockedInput = false;
        GetComponent<SpriteRenderer>().enabled = true;
       // StartCoroutine("ZoomInCam");

    }

    IEnumerator StartHidingCoroutine()
    {
        yield return new WaitForSeconds(.6f);
       isVisible = false; 
        GetComponent<SpriteRenderer>().enabled = false;
    }
    /*
    IEnumerator ZoomOutCam()
    {
        for(int i=0;i<20;i++)
        {
            mainCamera.orthographicSize += 0.05f;
            yield return new WaitForSeconds(0.05f);
        }
    }

    IEnumerator ZoomInCam()
    {
        for (int i = 0; i < 20; i++)
        {
            mainCamera.orthographicSize -= 0.05f;
            yield return new WaitForSeconds(0.05f);
        }
    }
*/

    public void LoseGame()
    {
        StartCoroutine("GameLost");
    }

    IEnumerator GameLost()
    {
        lockedInput = true;
        Move(0);
        // play lost animation
        yield return new WaitForSeconds(0.4f); //czas animacji
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
