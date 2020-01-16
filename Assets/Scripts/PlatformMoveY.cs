using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMoveY : MonoBehaviour
{
  public GameObject moveObject;
    public Vector3 positivePos;
    public Vector3 negativePos;
    public float speed = 0.2f;

    // Use this for initialization
    void Start()
    {
        positivePos = moveObject.transform.position + new Vector3(0, 2.5f, 0);
        negativePos = moveObject.transform.position + new Vector3(0, -2.5f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        float pingPong = Mathf.PingPong(Time.time * speed, 1);
        transform.position = Vector3.Lerp(negativePos, positivePos, pingPong);
    }
}
