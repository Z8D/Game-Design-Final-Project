using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleportEnemy : MonoBehaviour
{

    public float distance;
    private Transform playerPos;
    private PlayerController playerController;
    private float slowFactor;


    public GameObject targetPlayer;
    public Rigidbody teleEnemy;

    public bool enemyInvul = false;
    public bool expTrigger = false;
    public ParticleSystem explosion;
    public Collider[] colliders;

    public Material iceBlue;
    public Material transIceBlue;

    // Start is called before the first frame update
    void Start()
    {

        teleEnemy = GetComponent<Rigidbody>();
        targetPlayer = GameObject.FindGameObjectWithTag("Player");
        InvokeRepeating("teleport", 1f, 5f);

        

    }

    // Update is called once per frame
    void Update()
    {
        playerPos = FindObjectOfType<PlayerController>().transform;
        distance = Vector2.Distance(playerPos.position, teleEnemy.position);
        //Debug.Log("Distance: " + distance); //Display the distance

        if (enemyInvul)
        {
            GetComponent<Renderer>().material = transIceBlue;
        }
        if (enemyInvul == false)
        {
            GetComponent<Renderer>().material = iceBlue;
        }
         
    }


    public void teleport()
    {
        if (enemyInvul == false)
        {
            enemyInvul = true;
            Vector3 telePos = new Vector3(targetPlayer.transform.position.x + 1.3f, targetPlayer.transform.position.y, 0);
            teleEnemy.transform.position = telePos;
            Invoke("explode", 1f);
            
        }

        
    }

    void explode()
    {
        enemyInvul = false;
        // Effects
        var explosionClone = Instantiate(explosion, transform.position, Quaternion.identity);
       
        Destroy(explosionClone, 1.0f);
        
        colliders = Physics.OverlapSphere(this.transform.position, 3);
        
        foreach (Collider col in colliders)
        {
            if (col.gameObject.tag == "Player")
            {

                col.GetComponent<Rigidbody>().AddExplosionForce(75, this.transform.position, 3, 0, ForceMode.Impulse);
               
                slowFactor = (distance / 4);
                GameObject.FindWithTag("Player").gameObject.GetComponent<PlayerController>().getSlowed(slowFactor);
            }
        }

 


    }


}