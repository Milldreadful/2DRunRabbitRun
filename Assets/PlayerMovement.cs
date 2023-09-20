using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rB;
    public float runningSpeed;
    public float speedingUp;
    public float slowingDown;
    private float horizontal;

    [Header("Jump")]
    public float jumpForce;
    public LayerMask groundLayer;

    public Animator playerAnim;



    
    // Start is called before the first frame update
    void Start()
    {
        rB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Endless running
        rB.velocity = new Vector2(runningSpeed, rB.velocity.y);

        horizontal = Input.GetAxis("Horizontal");


        //Speeding up and Slowing down
        if(Input.GetButton("Horizontal") && horizontal < 0)
        {
            rB.velocity = new Vector2(slowingDown, rB.velocity.y); ;
        }

        else if (Input.GetButton("Horizontal") && horizontal > 0)
        {
            rB.velocity = new Vector2(speedingUp, rB.velocity.y);
        }

        if (!IsGrounded() && rB.velocity.y < -0.1f)
        {
            rB.gravityScale = 3f;
        }

        else
        {
            rB.gravityScale = 2f;
        }
    }
    public bool IsGrounded()
    {
        return Physics2D.Raycast(transform.position, Vector2.down, 3f, groundLayer);
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed && IsGrounded())
        {
            //rB.AddForce(Vector2.up * jumpForce);
            playerAnim.SetTrigger("Jump");
            rB.velocity = new Vector2(rB.velocity.x, jumpForce);
        }
    }
}
