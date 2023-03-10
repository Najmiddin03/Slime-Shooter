using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    public float fireRate = 0;
    public float Damage = 10;
    public LayerMask whatToHit;

    public GameObject BulletTrailPrefab;

    public float effectSpawnRate = 10;
    float timeToSpawnEffect = 0;
    float timeToFire = 0;
    Transform firePoint;
    [SerializeField]
    AudioSource shooting;

    // Start is called before the first frame update
    void Awake()
    {
        firePoint = transform.Find("FirePoint");
    }

    // Update is called once per frame
    void Update()
    {
        if(fireRate == 0)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Shoot();
                shooting.Play();
            }
        }
        else
        {
              if(Input.GetButton ("Fire1") && Time.time > timeToFire)
              {
                timeToFire = Time.time + 1/fireRate;
                shooting.Play();
                Shoot();
              }  
        }
    }

    void Shoot() 
    {
        Vector2 mousePosition = new Vector2 (Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        Vector2 firePointPosition = new Vector2 (firePoint.position.x, firePoint.position.y);
        RaycastHit2D hit = Physics2D.Raycast(firePointPosition, mousePosition-firePointPosition, 100, whatToHit);
        if (Time.time >= timeToSpawnEffect)
        {
        Effect();
        timeToSpawnEffect = Time.time + 1/effectSpawnRate;
        }
        Debug.DrawLine (firePointPosition, (mousePosition-firePointPosition)*100, Color.green);
        if(hit.collider != null)
        {
            Debug.DrawLine(firePointPosition, hit.point, Color.red);
        }
    }

    void Effect()
    {
        Instantiate (BulletTrailPrefab, firePoint.position, firePoint.rotation);
    }
}