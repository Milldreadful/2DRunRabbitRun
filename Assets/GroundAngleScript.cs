using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundAngleScript : MonoBehaviour
{
    public Transform raycastOrigin;
    public Transform playerFeet;
    public LayerMask groundLayer;
    private RaycastHit2D hit2D;

   private void GroundCheckMethod()
    {
        hit2D = Physics2D.Raycast(raycastOrigin.position, -Vector2.up, 50f, groundLayer);
        if(hit2D != false ) 
        {
            Vector2 temp = playerFeet.position;
            temp.y = hit2D.point.y;
            playerFeet.position = temp;
        }
    }

    private void GetAlignment() 
    {
        RaycastHit2D hit = Physics2D.Raycast(raycastOrigin.position, -transform.up, 100f, groundLayer);

        Vector2 newUp = hit.normal;

        transform.up = newUp;
    }

    // Update is called once per frame
    void Update()
    {
        GroundCheckMethod();
        //GetAlignment();
    }
}
