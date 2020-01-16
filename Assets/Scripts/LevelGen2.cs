using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGen2 : MonoBehaviour
{
    public GameObject startFloor;
    public GameObject[] listOfFloors;
    public int floorChoice;

    public GameObject BG;
    public GameObject currBG;
    public GameObject prevBG;


    public GameObject[] listOfPowerUps;
    public int powerUpChoice;
    public int numberOfPowerUps = 3;
    public float powerUpRangeY;
    public float powerUpRangeX;
    public int powerUpChance;
    public GameObject prevPowerUp;
    public GameObject currPowerUp;


    public float CollectibleRangeY;
    public float CollectibleRangeX;
    public GameObject Collectible;
    public GameObject prevCollectible;
    public GameObject currCollectible;

    public GameObject[] listOfEnemies;
    public int enemiesChoice;
    public int numberOfEnemies = 3;
    public float enemiesRangeY;
    public float enemiesRangeX;
    public int enemiesChance;
    public GameObject prevEnemy;
    public GameObject currEnemy;



    public GameObject currFloor;
    public GameObject beforeFloor;
    public int numOfFloors = 12;
    public int numOfSpawnedFloors;
    public GameObject endFloor;
    

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

        powerUpRangeY = Random.Range(6.0f, 8.0f);
        powerUpRangeX = Random.Range(25.0f, 50.0f);
        powerUpChance = Random.Range(0, 2);


        CollectibleRangeY = Random.Range(6.0f, 8.5f); 
        CollectibleRangeX = Random.Range(25.0f, 50.0f); 

        enemiesRangeY = Random.Range(6.0f, 8.5f);
        enemiesRangeX = Random.Range(24.0f, 40.0f);
        enemiesChance = Random.Range(0, 3);

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
            if (powerUpChance != 0)
            {
                currPowerUp = Instantiate(listOfPowerUps[powerUpChoice], beforeFloor.transform.position + new Vector3(powerUpRangeX, powerUpRangeY, 0), new Quaternion(0f, 0f, 0f, 0f));

            }


            Destroy(prevEnemy.gameObject);
            prevEnemy = currEnemy;

            if (enemiesChance != 0)
            {

                currEnemy = Instantiate(listOfEnemies[enemiesChoice], beforeFloor.transform.position + new Vector3(enemiesRangeX, enemiesRangeY, 0), new Quaternion(0f, 0f, 0f, 0f));

            }

            Destroy(prevBG.gameObject);

            prevBG = currBG;
            currBG = Instantiate(BG, beforeFloor.transform.position + new Vector3(20.0f, 9.0f, 5.0f), new Quaternion(0f, 0f, 0f, 0f));


        }
       
    
        


        if (numOfSpawnedFloors == numOfFloors)
        {
            Instantiate(endFloor, currFloor.transform.position + (transform.right * 35), new Quaternion(0f, 0f, 0f, 0f));
            numOfSpawnedFloors++;
        
        }

    }
}
