using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class TreasureScript : MonoBehaviour
{
    public Transform catchPosition;
    public GameObject parentObject;

    public float treasureX;
    public float treasureY;
    public float lowJumpMultiplier = 3f;

    public bool isInHand = true;
    public float bounceCount;
    public float onAirTimer;
    public TextMeshProUGUI onAirText;

    public Rigidbody2D treasureRB;
    public PlayerMovement playerScript;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = catchPosition.position;
        bounceCount = 0;
        onAirTimer = 0;

        treasureRB = GetComponent<Rigidbody2D>();
        playerScript = GameObject.Find("Player").GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") && isInHand)
        {
            treasureRB.simulated = true;
            treasureRB.velocity = new Vector2(treasureX, treasureY);


            Transform treasure = parentObject.transform.Find("Treasure");
            //treasure.parent = null;
            isInHand = false;
        }

        else if (!Input.GetButton("Jump") && treasureRB.velocity.y > 0)
        {
            treasureRB.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }

        if (!isInHand)
        {
            onAirTimer += Time.deltaTime;
            onAirText.text = onAirText.ToString();
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Hands") && treasureRB.velocity.y < -0.1f)
        {
            treasureRB.simulated = false;
            transform.position = catchPosition.position;
            gameObject.transform.parent = parentObject.transform;
            isInHand = true;
            bounceCount = 0;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            bounceCount += 1;
            treasureRB.velocity = new Vector2(treasureX, treasureY);

            if (bounceCount == 2)
            {
                playerScript.StartCoroutine("ReSpawn");
                bounceCount = 0;
            }
        }
    }
}
