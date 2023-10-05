using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Running")]
    public Rigidbody2D rB;
    public float runningSpeed;
    public float speedingUp;
    public float slowingDown;
    private float horizontal;

    public bool inSlowdown = false;

    [Header("Jump")]
    public float jumpForce;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float groundCheckRadius;

    public float coyoteTime = 0.2f;
    public float coyoteTimeCounter;

    [Header("Respawn")]
    public Vector2 checkpointPosition;
    public GameObject treasure;
    public Transform catchPosition;
    public bool isCoroutineRunning = false;

    public AudioSource jumpSFX;
    public Animator playerAnim;

    public float time = 0f;
    public float timeDelay = 2f;

    public GameManager GMScript;



    // Start is called before the first frame update
    void Start()
    {
        rB = GetComponent<Rigidbody2D>();
        GMScript = GameObject.Find("GM").GetComponent<GameManager>();
        checkpointPosition = transform.position;
    }


    // Update is called once per frame
    void Update()
    {
        if (IsGrounded())
        {
            coyoteTimeCounter = coyoteTime;
        }

        else
        {
            coyoteTimeCounter -= Time.deltaTime;
        }

        time += 1f * Time.deltaTime;

        if (time >= timeDelay)
        {

            //rB.velocity = new Vector2(runningSpeed, rB.velocity.y);


            horizontal = Input.GetAxis("Horizontal");


            //Speeding up and Slowing down
            if (Input.GetButton("Horizontal") && horizontal < 0 && IsGrounded() && !inSlowdown)
            {
                rB.velocity = new Vector2(slowingDown, rB.velocity.y);
            }

            else if (Input.GetButton("Horizontal") && horizontal > 0 && IsGrounded() && !inSlowdown)
            {
                rB.velocity = new Vector2(speedingUp, rB.velocity.y);
            }

            //Jumping
            if (Input.GetButtonDown("Jump") && coyoteTimeCounter > 0f && !inSlowdown)
            {
                playerAnim.SetTrigger("Jump");
                rB.velocity = Vector2.up * jumpForce;
                jumpSFX = GetComponent<AudioSource>();
                jumpSFX.pitch = Random.Range(0.8f, 1.7f);
                jumpSFX.Play();
            }

            else if (!Input.GetButton("Jump") && rB.velocity.y > 0)
            {
                rB.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
                coyoteTimeCounter = 0f;
            }

            else if (rB.velocity.y < 0)
            {
                rB.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
            }
        }
    }
    public bool IsGrounded()
    {
        //return Physics2D.Raycast(transform.position, Vector2.down, 3f, groundLayer);
        return Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }

    public IEnumerator ReSpawn()
    {
        yield return new WaitForSeconds(1f);
        isCoroutineRunning = true;
        transform.position = checkpointPosition;
        treasure.transform.position = catchPosition.position;
        yield return new WaitForSeconds(1f);
        isCoroutineRunning = false;
    }

    public IEnumerator Slowdown()
    {
        runningSpeed = 7f;
        yield return new WaitForSeconds(2f);
        runningSpeed = 12f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Hole"))
        {
            StartCoroutine(ReSpawn());
            print("Apua");
        }

        else if (collision.gameObject.CompareTag("Checkpoint"))
        {
            checkpointPosition = transform.position;
        }

        else if (collision.gameObject.CompareTag("Slowdown"))
        {
            runningSpeed = 7f;
            inSlowdown = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Slowdown"))
        {
            runningSpeed = 12f;
            inSlowdown = false;
        }
    }
}
