using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTrail : MonoBehaviour
{

    public int moveSpeed = 200;

    void Update()
    {
        
        transform.Translate(Vector3.right * Time.deltaTime * moveSpeed);
        Destroy (gameObject, 1);
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (!other.gameObject.CompareTag("Player") && !other.gameObject.CompareTag("EnemyModel"))
        {
            Destroy(gameObject);
        }
    }
}
