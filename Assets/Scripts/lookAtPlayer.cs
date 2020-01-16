using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookAtPlayer : MonoBehaviour
{
    
    public Transform target;

    public Vector3 offset;
    private float aimSpeed;

    public Transform firePoint;
    public GameObject bulletPrefab;

    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
        aimSpeed = 2.0f;
        InvokeRepeating("Shoot", 1f, 3f);
    }

    void Update()
    {
     


    }

 

    private void LateUpdate()
    {
            Vector3 targetPosition = target.position + offset;
 
            Quaternion targetRotation = Quaternion.LookRotation(Vector3.forward, targetPosition - transform.position);
 
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, aimSpeed);
    
    }



    void Shoot()
    {

        var bulletClone = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Destroy(bulletClone, 5f);
        

    }
}
