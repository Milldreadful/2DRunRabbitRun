using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RhinoScript : MonoBehaviour
{
    public float speed;
    public Transform target;

    public AudioSource rhinoSound;

    public float time = 0f;
    public float timeDelay = 3f;

    public Rigidbody2D rhinoRB;


    // Start is called before the first frame update
    void Start()
    {
        rhinoRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        time += 1f * Time.deltaTime;
        if (time >= timeDelay)
        {
            rhinoRB.velocity = new Vector2(speed, rhinoRB.velocity.y);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            //Destroy(collision.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Hole"))
        {
            collision.gameObject.GetComponent<Collider2D>().isTrigger = false;
        }
    }
}
