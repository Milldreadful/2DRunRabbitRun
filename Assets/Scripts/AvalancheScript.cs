using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvalancheScript : MonoBehaviour
{
    public float delay;
    public Transform target;
    public Transform checkpointPosition;


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
        time += 1f * Time.deltaTime;
        if (time >= timeDelay)
        {
            transform.position = Vector3.Lerp(transform.position, target.position, delay * Time.deltaTime);
        }

        if(playerScript.isCoroutineRunning == true)
        {
            transform.position = checkpointPosition.position;
        }
    }
}
