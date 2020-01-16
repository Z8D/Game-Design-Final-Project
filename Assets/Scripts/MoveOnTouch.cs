using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOnTouch : MonoBehaviour
{
    public GameObject moveObject;
    public Vector3 positivePos;
    public Vector3 negativePos;
    public float speed = 0.2f;

    public bool isTouching = false;

    // Use this for initialization
    void Start()
    {
        

        positivePos = moveObject.transform.position + new Vector3(0, 2.5f, 0);
        negativePos = moveObject.transform.position + new Vector3(0, -2.5f, 0);
    }

    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isTouching = true;

        }
    }

    public void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isTouching = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isTouching)
        {
            float pingPong = Mathf.PingPong(Time.time * speed, 1);
            transform.position = Vector3.Lerp(negativePos, positivePos, pingPong);
        }
    }
}
