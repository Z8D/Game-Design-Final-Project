using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGen3 : MonoBehaviour
{
    public GameObject startFloor;
    public GameObject[] listOfFloors;
    public int floorChoice;

    public GameObject BG;
    public GameObject currBG;
    public GameObject prevBG;

    public GameObject[] listOfPowerUps;
    public int powerUpChoice;
    public int numberOfPowerUps = 5;
    public float powerUpRangeY;
    public float powerUpRangeX;
 
    public GameObject prevPowerUp;
    public GameObject currPowerUp;


    public float CollectibleRangeY;
    public float CollectibleRangeX;
    public GameObject Collectible;
    public GameObject prevCollectible;
    public GameObject currCollectible;

    public GameObject[] listOfEnemies;
    public int enemiesChoice;
    public int numberOfEnemies = 5;
    public float enemiesRangeY;
    public float enemiesRangeX;
    public GameObject prevEnemy;
    public GameObject currEnemy;



    public GameObject currFloor;
    public GameObject beforeFloor;
    public int numOfFloors = 12;
    public int numOfSpawnedFloors;
    public GameObject bossFloor;
    public GameObject endFloor;
    
    public bool bossDefeated;

    void Start()
    {

        floorChoice = Random.Range(0, listOfFloors.Length);
        beforeFloor = startFloor;
        currFloor = Instantiate(listOfFloors[floorChoice], startFloor.transform.position + (transform.right * 15), new Quaternion(0f, 0f, 0f, 0f));
        numOfSpawnedFloors++;
    }

    // Update is called once per frame
    void Update()
    {
        bossDefeated = GameObject.FindWithTag("Player").GetComponent<PlayerController>().bossDefeated;

        powerUpRangeY = Random.Range(6.0f, 8.0f);
        powerUpRangeX = Random.Range(25.0f, 50.0f);


        CollectibleRangeY = Random.Range(6.0f, 8.5f);  
        CollectibleRangeX = Random.Range(25.0f, 50.0f); 

        enemiesRangeY = Random.Range(6.0f, 8.5f);
        enemiesRangeX = Random.Range(24.0f, 40.0f);

        if (Camera.main.transform.position.x - 10 > currFloor.transform.position.x && numOfSpawnedFloors < numOfFloors)
        {
            Destroy(beforeFloor.gameObject);
            beforeFloor = currFloor;
            floorChoice = Random.Range(0, listOfFloors.Length);
            currFloor = Instantiate(listOfFloors[floorChoice], beforeFloor.transform.position + (transform.right * 35), new Quaternion(0f, 0f, 0f, 0f));
            numOfSpawnedFloors++;


            powerUpChoice = Random.Range(0, listOfPowerUps.Length);
            enemiesChoice = Random.Range(0, listOfEnemies.Length);

            Destroy(prevCollectible.gameObject);
            prevCollectible = currCollectible;
            currCollectible = Instantiate(Collectible, beforeFloor.transform.position + new Vector3(CollectibleRangeX, CollectibleRangeY, 0), new Quaternion(0f, 0f, 0f, 0f));

            Destroy(prevPowerUp.gameObject);
            prevPowerUp = currPowerUp;
            currPowerUp = Instantiate(listOfPowerUps[powerUpChoice], beforeFloor.transform.position + new Vector3(powerUpRangeX, powerUpRangeY, 0), new Quaternion(0f, 0f, 0f, 0f));

            


            Destroy(prevEnemy.gameObject);
            prevEnemy = currEnemy;
            currEnemy = Instantiate(listOfEnemies[enemiesChoice], beforeFloor.transform.position + new Vector3(enemiesRangeX, enemiesRangeY, 0), new Quaternion(0f, 0f, 0f, 0f));


            Destroy(prevBG.gameObject);

            prevBG = currBG;
            currBG = Instantiate(BG, beforeFloor.transform.position + new Vector3(20.0f, 9.0f, 5.0f), new Quaternion(0f, 0f, 0f, 0f));
        }


        if (numOfSpawnedFloors == numOfFloors)
        {
            
            Instantiate(bossFloor, currFloor.transform.position + (transform.right * 45), new Quaternion(0f, 0f, 0f, 0f));
            numOfSpawnedFloors++;

     
        }

        
        if (bossDefeated == true)
        {
            Instantiate(endFloor, currFloor.transform.position + (transform.right * 65), new Quaternion(0f, 0f, 0f, 0f));
            bossDefeated = false;
        
        }
        

    }
}
