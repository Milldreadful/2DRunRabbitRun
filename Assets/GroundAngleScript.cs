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
        hit2D = Physics2D.Raycast(raycastOrigin.position, -Vector2.up, 500f, groundLayer);
        if(hit2D != false ) 
        {
            Vector2 temp = playerFeet.position;
            temp.y = hit2D.point.y;
            playerFeet.position = temp;
        }
    }

    // Update is called once per frame
    void Update()
    {
        GroundCheckMethod();
    }
}
