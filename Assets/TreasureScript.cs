using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureScript : MonoBehaviour
{
    public Transform catchPosition;
    public GameObject parentObject;

    public Rigidbody2D rB;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = catchPosition.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            rB.simulated = true;
            //transform.Translate(Vector2.right * 5f * Time.deltaTime);
            rB.velocity = new Vector2(6f, 10f);
            //rB.AddForce(Vector2.up * 200f);

            Transform detachChild = parentObject.transform.Find("Circle");
            detachChild.parent = null;  

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
        }
    }

}
