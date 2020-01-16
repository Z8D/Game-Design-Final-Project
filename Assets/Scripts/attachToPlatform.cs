using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attachToPlatform : MonoBehaviour
{
  

    // Start is called before the first frame update
    void Start()
    {
    }
    

     public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player")) 
        {
            other.gameObject.transform.parent = transform;
            
        }
    }

    public void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.transform.parent = null;
        }
    }

}

/*
private void OnTriggerEnter2D(Collider2D other)
{
    if (other.gameObject == Player)
    {
        other.gameObject.transform.parent = transform;
        Debug.Log("Enter");

    }
}

private void OnTriggerExit2D(Collider2D other)
{
    if (other.gameObject == Player)
    {
        other.gameObject.transform.parent = null;
        Debug.Log("Exit");
    }
}
*/