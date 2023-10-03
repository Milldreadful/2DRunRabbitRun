using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RhinoScript : MonoBehaviour
{
    public float speed;
    public Transform checkpointPosition;

    public float time = 0f;
    public float timeDelay = 3f;

    public Rigidbody2D rhinoRB;
    public PlayerMovement playerScript;


    // Start is called before the first frame update
    void Start()
    {
        rhinoRB = GetComponent<Rigidbody2D>();
        playerScript = GameObject.Find("Player").GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        time += 1f * Time.deltaTime;
        if (time >= timeDelay)
        {
            rhinoRB.velocity = new Vector2(speed, rhinoRB.velocity.y);
        }

        if(playerScript.isCoroutineRunning == true)
        {
            transform.position = checkpointPosition.position;
        }
    }
}
