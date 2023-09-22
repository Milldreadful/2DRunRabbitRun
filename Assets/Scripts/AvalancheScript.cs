using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvalancheScript : MonoBehaviour
{
    public float delay;
    public Transform target;

    public Animator rhinoAnim;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(Vector2.right * speed * Time.deltaTime);
        StartCoroutine(IdleWait());
    }

    public IEnumerator IdleWait()
    {
        yield return new WaitForSeconds(2f);
        transform.position = Vector3.Lerp(transform.position, target.position, delay * Time.deltaTime);
    }
}
