using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureScript : MonoBehaviour
{
    public Transform catchPosition;
    public GameObject parentObject;

    public float treasureX;
    public float treasureY;

    public bool isInHand = true;

    public Rigidbody2D rB;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = catchPosition.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && isInHand)
        {
            rB.simulated = true;
            rB.velocity = new Vector2(treasureX , treasureY);

            Transform detachChild = parentObject.transform.Find("Treasure");
            detachChild.parent = null;  
            isInHand = false;
        }

        

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Hands") && rB.velocity.y < -0.1f)
        {
            rB.simulated = false;
            transform.position = catchPosition.position;
            print("Enter");
            gameObject.transform.parent = parentObject.transform;
            isInHand = true;
        }
    }

}
