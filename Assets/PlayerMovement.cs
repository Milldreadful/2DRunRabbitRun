using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rB;
    public float runningSpeed;

    [Header("Jump")]
    public float jumpForce;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask groundLayer;

    public float fallMultiplier;
    public Animator playerAnim;


    [Header("Shoot")]
    public GameObject ammo;
    public Transform ammoStart;


    public bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }

    // Start is called before the first frame update
    void Start()
    {
        rB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * runningSpeed * Time.deltaTime);
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed && IsGrounded())
        {
            //rB.AddForce(Vector2.up * jumpForce);
            playerAnim.SetTrigger("Jump");
            rB.velocity = new Vector2(rB.velocity.x, jumpForce);
        }

        /*if (context.canceled && rB.velocity.y > 0f)
        {
            rB.velocity = new Vector2(rB.velocity.x, rB.velocity.y * 0.1f);
        }*/

      /*if (context.canceled && rB.velocity.y < 0)
        {
            rB.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
            rB.gravityScale = 0.5f;
        }*/
    }

    public void Fire(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Instantiate(ammo, ammoStart.position, ammoStart.rotation);
        }
    }
}
