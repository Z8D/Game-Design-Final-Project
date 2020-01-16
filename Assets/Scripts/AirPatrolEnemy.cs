using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirPatrolEnemy : MonoBehaviour
{

    public Transform firePoint;
    public GameObject mine;


    private Vector3 pos1;
    private Vector3 pos2;
    public float speed = 1.0f;
    void Start()
    {


        //enemyPos.position = new Vector3(enemyPos.position.x, 8, 0);
        

        pos1 = new Vector3(transform.position.x, 8, 0);
        pos2 = new Vector3(transform.position.x + 6, 8, 0);

        InvokeRepeating("dropMine", 1f, 4f);
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        transform.position = Vector3.Lerp(pos1, pos2, (Mathf.Sin(speed * Time.time)+1f)/2f);

    }
    void Update()
    {
        
    }

    void dropMine()
    {
        var mineClone = Instantiate(mine, firePoint.position, firePoint.rotation);
        Destroy(mineClone, 5.0f);
    }
}
