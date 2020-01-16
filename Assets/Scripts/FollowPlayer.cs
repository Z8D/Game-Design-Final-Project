using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{


    public float x;
    public float y;
    public float z;
    public GameObject cam;
    public GameObject player;




    // Start is called before the first frame update
    void Start()
    {
        x = 0;
        y = 2;
        z = -10;
        cam.transform.Rotate(15, 0, 0);
    }

    void Update()
    {
        
    }

    void LateUpdate()
    {
        float maxX = PlayerPrefs.GetFloat("maxX");
       

        if (player.transform.position.x < maxX)
        {

        }
        else
        {
            cam.transform.position = player.transform.position + new Vector3(x, y, z);
        }


        
    }
}
