using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;

    public float jump = 250f;
    private float numJumps = 0;
    public bool isRunning = false;
    private float moveX;
    public float moveSpeed = 5.5f;
    private bool isSlowed;
    //public float slowFactor;
    // private teleportEnemy teleportEnemy;

    public bool isGrounded = false;

    private int goldCount;

    public bool isSheilded = false;
    public bool powerJump = false;
    public bool teleportON = false;
    public bool isInvulnerable = false;
    public bool godMode = false;
    public bool laserOn = false;
    public bool enemyInvul;
    public int teleportCharges = 0;

    public int enemiesKilled;

    public int bossHitCount = 0;
    public bool bossDefeated = false;

    public Text countText;
    public Text teleCharges;
    public Text enemiesKilledTEXT;

    public Material gray;
    public Material black;
    public Material purple;
    public Material blue;
    public Material transGold;
    public Material red;




    void Start()
    {
        goldCount = PlayerPrefs.GetInt("goldCount");
        rb = GetComponent<Rigidbody>();
        PlayerPrefs.SetFloat("maxX", 0);
        PlayerPrefs.SetFloat("maxY", 0);

        countText.text = "Gold Collected: " + goldCount.ToString();
  
        enemiesKilled = 0;

    }


    // Update is called once per frame
    void Update()
    {

        PlayerPrefs.SetInt("goldCount", goldCount);

        enemiesKilledTEXT.text = "Enemies Killed: " + enemiesKilled.ToString();

        if (teleportON)
        {
            teleCharges.enabled = true;
            teleCharges.text = "Teleport Charges : " + teleportCharges;
        }



        PlayerMover();
        if (rb.velocity.y == 0)
        {
            isGrounded = true;
            numJumps = 0;
        }
        else
        {
            isGrounded = false;
        }

        // Teleport Ability
        if (Input.GetMouseButtonDown(0) && teleportCharges > 0 && teleportON)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.point.y > 0)
                {
                    rb.velocity = Vector3.zero;
                    this.transform.position = new Vector3(hit.point.x, hit.point.y, 0);
                    teleportCharges--;
                    isInvulnerable = true;
                    
                    Invoke("InvulnerableTimer", 2.0f);
                    numJumps = 0;
                }
            }
        }

        if (teleportCharges < 1) 
        {
            teleCharges.enabled = false;
            teleportON = false;
            if (isSheilded == false && powerJump == false && teleportON == false && godMode == false && laserOn == false) 
            {
                GetComponent<Renderer>().material = black;
            }
        }

    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collectible"))
        {
            
            Destroy(other.gameObject);
            goldCount += 1;
            countText.text = "Gold Collected: " + goldCount.ToString();
        }
        if (other.gameObject.CompareTag("DeathFloor"))
        {

            SceneManager.LoadScene("Failed");
            enemiesKilled = 0;

        }
        if (other.gameObject.CompareTag("DeathZone"))
        {

            if (isSheilded == false && isInvulnerable == false && godMode == false)
            {
                SceneManager.LoadScene("Failed");
                enemiesKilled = 0;
            }
            isSheilded = false;

            if (godMode == false && isInvulnerable == false && laserOn == false)
            {
                GetComponent<Renderer>().material = black;
            }
        }

        if (other.gameObject.CompareTag("Shield"))
        {
            Destroy(other.gameObject);
            isSheilded = true;
            GetComponent<Renderer>().material = gray;
        }
        if (other.gameObject.CompareTag("powerJump"))
        {
            Destroy(other.gameObject);
            powerJump = true;
            GetComponent<Renderer>().material = purple;
        }
        if (other.gameObject.CompareTag("Teleport"))
        {
            Destroy(other.gameObject);
            teleportON = true;

            teleportCharges += 5;
            GetComponent<Renderer>().material = blue;
        }

        if (other.gameObject.CompareTag("GodMode"))
        {
            Destroy(other.gameObject);
            godMode = true;
            Invoke("godModeTimer", 10.0f);
            GetComponent<Renderer>().material = transGold;
        }

        if (other.gameObject.CompareTag("Laser"))
        {
            Destroy(other.gameObject);
            laserOn = true;
            Invoke("laserTimer", 30.0f);
            GetComponent<Renderer>().material = red;
        }


    }

    // Kill enemy or load fail scene 
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("TeleEnemy"))
        {
            enemyInvul = GameObject.FindWithTag("TeleEnemy").gameObject.GetComponent<teleportEnemy>().enemyInvul;

            // If the cube hits the top of the object
            if (godMode || enemyInvul == false && rb.transform.position.y - 1 > other.gameObject.transform.position.y)
            {
                
                Destroy(other.gameObject);
                enemiesKilled++;
            }

            
        }
        
        if (other.gameObject.CompareTag("ShooterEnemy"))
        {
            // If the cube hits the top of the object
            if (rb.transform.position.y - 1 > other.gameObject.transform.position.y || godMode)
            {

                Destroy(other.gameObject);
                enemiesKilled++;

            }
            else
            {
                if (isSheilded == false && isInvulnerable == false && godMode == false)
                {
                    SceneManager.LoadScene("Failed");
                    enemiesKilled = 0;
                }
                isSheilded = false;
                GetComponent<Renderer>().material = black;
            }
        }

        if (other.gameObject.CompareTag("Bullet"))
        {
            if(isSheilded == false && isInvulnerable == false && godMode == false)
            {
                SceneManager.LoadScene("Failed");
                enemiesKilled = 0;
            }
            isSheilded = false;
            
        }


        if (other.gameObject.CompareTag("ZombieEnemy"))
        {
            if(rb.transform.position.y - 1 > other.gameObject.transform.position.y || godMode || isSheilded)
            {
                Destroy(other.gameObject);
                enemiesKilled++;
                if (isSheilded)
                {
                    isSheilded = false;
                }
            }
        }

        if (other.gameObject.CompareTag("LaserWall"))
        {
            if (godMode)
            {
                Destroy(other.gameObject);
                enemiesKilled++;
            }
            else
            {
                if (isSheilded == false && isInvulnerable == false && godMode == false)
                {
                    SceneManager.LoadScene("Failed");
                    enemiesKilled = 0;
                }
                isSheilded = false;
                GetComponent<Renderer>().material = black;
            }
        }

        if (other.gameObject.CompareTag("Mine"))
        {
            if (godMode)
            {
                Destroy(other.gameObject);

            }
            else
            {
                if (isSheilded == false && isInvulnerable == false && godMode == false)
                {
                    SceneManager.LoadScene("Failed");
                    enemiesKilled = 0;
                }
                isSheilded = false;
                GetComponent<Renderer>().material = black;
            }
        }
        if (other.gameObject.CompareTag("AirPatrolEnemy"))
        {
            if (godMode)
            {
                Destroy(other.gameObject);
                enemiesKilled++;
            }
        }

        if (other.gameObject.CompareTag("Boss"))
        {

            if (rb.transform.position.y - 1 > other.gameObject.transform.position.y)
            {
                bossHitCount++;
                rb.AddForce(new Vector3(0,25,0), ForceMode.Impulse);
            }
            else
            {
                SceneManager.LoadScene("Failed");
                enemiesKilled = 0;
            }

            if(bossHitCount >= 3)
            {
                Destroy(other.gameObject);
                bossDefeated = true;
                enemiesKilled++;

            }
        }
  

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("EndZone1"))
        {

            SceneManager.LoadScene("LevelOneEnd");
            enemiesKilled = 0;

        }

        if (other.gameObject.CompareTag("EndZone2"))
        {

            SceneManager.LoadScene("LevelTwoEnd");
            enemiesKilled = 0;

        }

        if (other.gameObject.CompareTag("EndZone3"))
        {

            SceneManager.LoadScene("LevelThreeEnd");
            enemiesKilled = 0;

        }

    if (isSlowed)
        {
            Invoke("restoreSpeed", 5f);
        }


    }
    void FixedUpdate()
        {
            float maxX = PlayerPrefs.GetFloat("maxX");
            float currX = rb.transform.position.x;
            if (currX > maxX)
            {
                maxX = currX;
            }
            PlayerPrefs.SetFloat("maxX", maxX);

            float maxY = PlayerPrefs.GetFloat("maxY");
            float currY = rb.transform.position.y;
            if (currY > maxY)
            {
                maxY = currY;
            }
            PlayerPrefs.SetFloat("maxY", maxY);
    }



    private void PlayerMover()
    {
        moveX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveX * moveSpeed, rb.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            moveSpeed += 2;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            moveSpeed = 5.5f;
        }
    }
    void Jump()
    {
        if (numJumps < 1) 
        {
            rb.AddForce(Vector2.up * jump);
            numJumps++;
        }
        if (powerJump == true) 
        {
            rb.AddForce(Vector2.up * (jump*1.5f));
            powerJump = false;
            GetComponent<Renderer>().material = black;
        }
    }

    private void InvulnerableTimer() 
    {
        isInvulnerable = false; 
    }
    private void godModeTimer() 
    {
        godMode = false;
        GetComponent<Renderer>().material = black;
    }
    private void laserTimer() 
    {
        laserOn = false;

    }

    public void getSlowed (float slowFactor)
    {
        isSlowed = true;
        if (godMode == false)
        {
            moveSpeed = slowFactor * moveSpeed;
        }
    }

    private void restoreSpeed ()
    {
        isSlowed = false;
    }
   

}