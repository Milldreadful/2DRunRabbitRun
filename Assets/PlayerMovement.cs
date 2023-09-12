using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rB;
    public float speed;
    public float jump;

    public GameObject ammo;
    public Transform ammoStart;

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
        if (context.performed)
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
