using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rB;
    public float speed;
    public float jump;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask groundLayer;

    public GameObject ammo;
    public Transform ammoStart;


    public bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed && IsGrounded())
        {
            rB.AddForce(Vector2.up * jump);
        }
    }

    public void Fire(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Instantiate(ammo, ammoStart.position, ammoStart.rotation);
        }
    }
}
