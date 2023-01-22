using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    [SerializeField]
    private Transform player;
    [SerializeField]
    private GameObject enemy;
    private Vector3 position;
    [SerializeField]
    private int _totalEnemies = 50;
    [SerializeField]
    private int additionalEnemies = 0;
    [SerializeField]
    private int _maxEnemies = 5;
    [SerializeField]
    private int _currentEnemies = 0;
    private bool checkpoint = false;

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyRoutine();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.position.x > 200 && !checkpoint)
        {
            NextCheckpoint();
            checkpoint = true;
        }
    }

    private void SpawnEnemyRoutine()
    {
        while (_totalEnemies > 0 && _currentEnemies <= _maxEnemies)
        {
            if (player.position.x < 0)
            {
                _totalEnemies--;
                _currentEnemies++;
                position = new Vector3(Random.Range(player.position.x + 60f, player.position.x + 100f), Random.Range(3, 7), 0);
                Instantiate(enemy, position, Quaternion.identity);
            }
            else if(player.position.x > 300)
            {
                _totalEnemies--;
                _currentEnemies++;
                position = new Vector3(Random.Range(player.position.x - 30f, player.position.x - 60f), Random.Range(3, 7), 0);
                Instantiate(enemy, position, Quaternion.identity);
            }
            else
            {
                _totalEnemies--;
                _currentEnemies++;
                position = new Vector3(Random.Range(player.position.x + 60f, player.position.x + 100f), Random.Range(3, 7), 0);
                Instantiate(enemy, position, Quaternion.identity);
                _totalEnemies--;
                _currentEnemies++;
                position = new Vector3(Random.Range(player.position.x - 30f, player.position.x - 60f), Random.Range(3, 7), 0);
                Instantiate(enemy, position, Quaternion.identity);
            }
        }
    }

    public void EnemyDestroyed()
    {
        _currentEnemies--;
        if (_currentEnemies == _maxEnemies - 1)
        {
            SpawnEnemyRoutine();
        }
    }

    void NextCheckpoint()
    {
        if (_totalEnemies <= 0)
        {
            _totalEnemies += additionalEnemies;
            SpawnEnemyRoutine();
        }
        else
        {
            _totalEnemies += additionalEnemies;
        }
    }

    public int getTotalEnemies()
    {
        return _totalEnemies;
    }
}
