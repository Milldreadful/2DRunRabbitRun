using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleScript : MonoBehaviour
{
    private Transform obstaclePos;
    public PlayerMovement playerScript;

    // Start is called before the first frame update
    void Start()
    {
        obstaclePos.position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(playerScript.isCoroutineRunning == true)
        {
            transform.position = obstaclePos.position;
        }
    }
}
