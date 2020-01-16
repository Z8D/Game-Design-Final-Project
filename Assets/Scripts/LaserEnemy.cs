using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserEnemy : MonoBehaviour
{
    public float timer;


    void Start()
    {
        
    }

    void FixedUpdate()
    {
        timer += Time.deltaTime;
        if (timer > 3f)
        {
            this.gameObject.SetActive(false);
            timer -= 3f;
            Invoke("laserWallTimer", 3f);
        }
        
    }

    void laserWallTimer()
    {
        this.gameObject.SetActive(true); ;
    }
}
