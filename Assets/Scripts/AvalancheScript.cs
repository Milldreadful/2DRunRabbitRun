using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvalancheScript : MonoBehaviour
{
    public float delay;
    public Transform target;


    public float time = 0f;
    public float timeDelay = 3f;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += 1f * Time.deltaTime;
        if (time >= timeDelay)
        {
            transform.position = Vector3.Lerp(transform.position, target.position, delay * Time.deltaTime);
        }
    }
}
