using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    public GameObject player;
    [SerializeField]
    public SpawnManager spawnManager;
    [SerializeField]
    public Player pl;
    [SerializeField]
    GameObject explosion;

    void Update()
    {

    }


    void OnCollisionEnter2D(Collision2D other)
    {
        
        if (other.gameObject == player)
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            pl.Damage();
            spawnManager.EnemyDestroyed();
            Destroy(gameObject);
        }

        if (other.gameObject.CompareTag("Bullet"))
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            spawnManager.EnemyDestroyed();
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
