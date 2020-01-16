using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackBlock : MonoBehaviour
{

    public float x;
    public float y;
    public float z;
    public GameObject Wall;
    public GameObject Player;

    void Start()
    {
        x = -12.5f;
        y = 0;
        z = 0;
        
    }

    void Update()
    {

    }
    // Update is called once per frame
    void LateUpdate()
    {

        float maxX = PlayerPrefs.GetFloat("maxX");
        if (Player.transform.position.x < maxX)
        {
            // myCamera.transform.position = myPlayer.transform.position + new Vector3(x, y, z);
        }
        else
        {
            Wall.transform.position = Player.transform.position + new Vector3(x, y, z);
        }
    }
}
