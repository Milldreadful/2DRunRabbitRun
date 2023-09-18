using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletTimeScript : MonoBehaviour
{
    public GameObject weaponsChoice;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Time.timeScale = 0.3f;
            weaponsChoice.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Time.timeScale = 1f;
            weaponsChoice.gameObject.SetActive(false);
        }
    }

    IEnumerator TimeScaleReturn()
    {
        Time.timeScale = 0.3f;
        yield return new WaitForSeconds(1.5f);
        Time.timeScale = 1f;
    }

}
