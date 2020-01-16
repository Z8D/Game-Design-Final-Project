using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public GameObject[] listOfEnemies;
    public int enemiesChoice;
    public int numberOfEnemies = 2;
    public float enemiesRangeY;
    public float enemiesRangeX;

    private Vector3 pos1;
    private Vector3 pos2;
    public float speed = 1.5f;

    // Start is called before the first frame update
    void Start()
    {

        pos1 = new Vector3(transform.position.x - 5, transform.position.y, 0);
        pos2 = new Vector3(transform.position.x + 5, transform.position.y, 0);

        InvokeRepeating("spawnEnemy", 3.0f, 10.0f);
    }

    // Update is called once per frame
    void Update()
    {
        enemiesChoice = Random.Range(0, listOfEnemies.Length);
        enemiesRangeY = Random.Range(2.0f, 4.0f);
        enemiesRangeX = Random.Range(-5.0f, 5.0f);
    }

    void FixedUpdate()
    {

        transform.position = Vector3.Lerp(pos1, pos2, (Mathf.Sin(speed * Time.time) + 1f) / 2f);

    }

    void spawnEnemy()
    {
        var enemyClone = Instantiate(listOfEnemies[enemiesChoice], transform.position + new Vector3(enemiesRangeX, enemiesRangeY, 0), new Quaternion(0f, 0f, 0f, 0f));
        
    }
}
