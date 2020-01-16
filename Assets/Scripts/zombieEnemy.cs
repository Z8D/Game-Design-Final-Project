using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombieEnemy : MonoBehaviour
{
    public Transform target;
    public Vector3 followOffset;
    public float followSpeed;
    public bool lookAtTarget;
    public bool isTouching;
    public Rigidbody playerRB;
    public bool godMode;
    public bool sheild;
    private void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
        playerRB = GameObject.FindWithTag("Player").GetComponent<Rigidbody>();
    }

    // done in LateUpdate to allow the target to have the chance to move first in Update
    private void LateUpdate()
    {

        zombieAttack();


    }
    void Update()
    {
        godMode = GameObject.FindWithTag("Player").gameObject.GetComponent<PlayerController>().godMode;
        sheild = GameObject.FindWithTag("Player").gameObject.GetComponent<PlayerController>().isSheilded;
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (godMode == false && sheild == false)
            {
                playerRB.AddForce(-250f, 0f, 5, ForceMode.Impulse);
                Invoke("touchingTimerTrue", 0.5f);
                Invoke("touchingTimerFalse", 3f);
            }

        }
    }

    void zombieAttack()
    {
        if (isTouching == false)
        {

            followOffset = new Vector3(0.9f, 0.9f, 0f);
            // move towards the target position ( plus the offset ), never moving farther than "followSpeed" in one frame.
            transform.position = Vector3.MoveTowards(transform.position, target.position + followOffset, followSpeed);

        }
    }


    void touchingTimerFalse()
    {
        isTouching = false;
    }

    void touchingTimerTrue()
    {
        isTouching = true;
        Destroy(this.gameObject);
    }

}
