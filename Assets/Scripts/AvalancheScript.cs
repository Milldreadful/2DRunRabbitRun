using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvalancheScript : MonoBehaviour
{
    public float delay;
    public float avalancheSpeed;
    public Transform target;
    public Transform checkpointPosition;
    public Vector2 avalancheTarget = new Vector2(1521.5f, -325.5f);


    public float time = 0f;
    public float timeDelay = 3f;

    public PlayerMovement playerScript;

    // Start is called before the first frame update
    void Start()
    {
        playerScript = GameObject.Find("Player").GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, avalancheTarget, Time.deltaTime * avalancheSpeed);
       

        if(playerScript.isCoroutineRunning == true)
        {
            transform.position = checkpointPosition.position;
        }
    }
}
