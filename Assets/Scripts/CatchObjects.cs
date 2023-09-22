using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchObjects : MonoBehaviour
{
    public Transform catchPoint;
    public Transform rayPoint;
    public float rayDistance;

    public GameObject catchable;
    private int layerIndex;


    // Start is called before the first frame update
    void Start()
    {
        layerIndex = LayerMask.NameToLayer("Grabable");
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hitinfo = Physics2D.Raycast(rayPoint.position, transform.up, rayDistance);

        if(hitinfo.collider != null && hitinfo.collider.gameObject.layer == layerIndex)
        {
            catchable.transform.position = catchPoint.position;
        }
    }
}
