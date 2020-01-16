using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosionForce : MonoBehaviour
{
    public float distance;
    private Transform playerPos;
    private Transform enemyPos;
    private PlayerController playerController;
    private float slowFactor;
    public bool isSlowing;

    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerPos = FindObjectOfType<PlayerController>().transform;
        enemyPos = FindObjectOfType<teleportEnemy>().transform;

    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(playerPos.position, enemyPos.position);
        //Debug.Log("Distance: " + distance); //Display the distance
        if (isSlowing) 
        {
            slowFactor = (distance/4);
            Debug.Log("slowFactor" + slowFactor);
            gameObject.GetComponent<PlayerController>().getSlowed(slowFactor);
        }
        isSlowing = false;

    }
 
}
