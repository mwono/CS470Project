using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public GameObject gameOverCanvas;

    float maxJumpHeight = 4f;
    float groundHeight;
    Vector3 groundPos;
    float jumpSpeed = 8.0f;
    float fallSpeed = 11.0f;
    public bool inputJump = false;
    public bool grounded = true;
    public Animator playerAnim;
    public BackgroundScroll bgScript;

    float leftSpeed = 4.5f;
    float rightSpeed = 8.5f;
    float defaultSpeed = -1f;

    void Start()
    {
        groundPos = transform.position;
        groundHeight = transform.position.y;
        maxJumpHeight = transform.position.y + maxJumpHeight;
        defaultSpeed = bgScript.GetSpeed();
    }

    void Update()
    {

        // jumping
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (grounded)
            {
                groundPos = transform.position;
                inputJump = true;
                playerAnim.SetBool("Jump", true);
                StartCoroutine("Jump");
            }
        }
        if (transform.position == groundPos)
            grounded = true;
        else
            grounded = false;

        // move left
        if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            bgScript.SetSpeed(leftSpeed);
        }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            bgScript.SetSpeed(rightSpeed);
        }
        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow))
        {
            bgScript.SetSpeed(defaultSpeed);
        }
        else if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            bgScript.SetSpeed(defaultSpeed);
        }


        // move right


    }

    IEnumerator Jump()
    {
        while (true)
        {
            if (transform.position.y >= maxJumpHeight)
                inputJump = false;
            if (inputJump)
                transform.Translate(Vector3.up * jumpSpeed * Time.smoothDeltaTime);
            else if (!inputJump)
            {
                transform.Translate(Vector3.down * fallSpeed * Time.smoothDeltaTime);
                if (transform.position.y < groundPos.y)
                {
                    transform.position = groundPos;
                    playerAnim.SetBool("Jump", false);
                    StopAllCoroutines();
                }
            }

            yield return new WaitForEndOfFrame();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // check if we die
        if(collision.gameObject.tag == "Obstacle")
        {
            GameEvents.TriggerPlayerDie();
            gameOverCanvas.SetActive(true);
            Destroy(this.gameObject);
        }
    }
}
