using UnityEngine;

public class Laser : MonoBehaviour
{
    public Transform firePoint;
    public LineRenderer laserRenderer;
    public bool laserOn;
    private Ray ray;

    private void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        laserOn = gameObject.GetComponent<PlayerController>().laserOn;

        if (laserOn)
        {
            if (Input.GetMouseButton(1))
        {

        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit[] hits;
        hits = Physics.RaycastAll(ray);

            for (int i = 0; i < hits.Length; i++)
            {
                RaycastHit hit = hits[i];
                //Debug.Log(hit.collider.gameObject.name);
                if (hit.collider.gameObject.CompareTag("TeleEnemy") || hit.collider.gameObject.CompareTag("ZombieEnemy") || hit.collider.gameObject.CompareTag("ShooterEnemy") || hit.collider.gameObject.CompareTag("LaserWall") || hit.collider.gameObject.CompareTag("AirPatrolEnemy"))
                    {
                        Destroy(hit.transform.gameObject);
                    }
            }

            RaycastHit shotHit;
                if (Physics.Raycast(ray, out shotHit))
                {
                    Vector3 myPos = firePoint.position;
                    Vector3 shotDirection = new Vector3(shotHit.point.x - firePoint.position.x, shotHit.point.y - firePoint.position.y, 0);
                        
                    laserRenderer.SetPosition(0, firePoint.position);
                    laserRenderer.SetPosition(1, shotDirection * 100);
                    }
                    laserRenderer.enabled = true;
        }
            else
            {
                laserRenderer.enabled = false;
            }
        }
        else
        {
            laserRenderer.enabled = false;
        }
    }

}

