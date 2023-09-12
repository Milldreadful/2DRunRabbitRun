using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTimeScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Hazard"))
        {
            StartCoroutine(TimeScaleReturn());
        }
    }

    IEnumerator TimeScaleReturn()
    {
        Time.timeScale = 0.3f;
        yield return new WaitForSeconds(1f);
        Time.timeScale = 1f;
    }

}
