using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureScript : MonoBehaviour
{
    public Transform playerParent;
    public Transform childObject;

    public Rigidbody2D rB;

    public float objectSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * objectSpeed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            childObject = playerParent.Find("Circle");
            childObject.parent = null;
            rB.simulated = true;
        }

       /* if(childObject.parent == null)
        {
            transform.Translate(Vector2.right * objectSpeed * Time.deltaTime);
        }*/
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Hands"))
        {
            childObject.parent = playerParent;
            print("Enter");
        }
    }

}
