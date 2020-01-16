using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    public Transform firePoint;
    public GameObject bulletPrefab;
    
   // public Transform target;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            //transform.LookAt(target);
            Shoot();
        
        }
    }

    void Shoot() 
    {
        // Shooting logic 
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        
    }

}
