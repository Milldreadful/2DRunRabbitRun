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

    [Header("Jump")]
    public float jumpForce;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float groundCheckRadius;

    public Animator playerAnim;

    public float time = 0f;
    public float timeDelay = 2f;



    
    // Start is called before the first frame update
    void Start()
    {
        rB = GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    void Update()
    {
        time += 1f * Time.deltaTime;

        if (time >= timeDelay) 
        {

            rB.velocity = new Vector2(runningSpeed, rB.velocity.y);

            horizontal = Input.GetAxis("Horizontal");


            //Speeding up and Slowing down
            if (Input.GetButton("Horizontal") && horizontal < 0)
            {
                rB.velocity = new Vector2(slowingDown, rB.velocity.y);
            }

            else if (Input.GetButton("Horizontal") && horizontal > 0)
            {
                rB.velocity = new Vector2(speedingUp, rB.velocity.y);
            }


            if (Input.GetButtonDown("Jump") && IsGrounded())
            {
                playerAnim.SetTrigger("Jump");
                rB.velocity = Vector2.up * jumpForce;
            }

            else if (!Input.GetButton("Jump") && rB.velocity.y < 0)
            {
                rB.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
            }

            else if(!Input.GetButton("Jump") && rB.velocity.y > 0)
            {
                rB.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
            }
        }

    }
    public bool IsGrounded()
    {
        //return Physics2D.Raycast(transform.position, Vector2.down, 3f, groundLayer);
        return Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }
}
