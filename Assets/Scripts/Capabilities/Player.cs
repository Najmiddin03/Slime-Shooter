using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    public GameObject GameOverMenu;
    [SerializeField]
    private int maxLives = 5;
    [SerializeField]
    public int lives;
    [SerializeField]
    public HealthBar bar;
    // Start is called before the first frame update
    void Start()
    {
        lives = maxLives;
        bar.SetMaxHealth(maxLives);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Damage()
    {
        if (lives > 1)
        {
            lives--;
            bar.SetHealth(lives);
        }
        
        else
        {
            EnemyDeath();
            Time.timeScale = 0f;
            GameOverMenu.SetActive(true);
        }
    }

    void EnemyDeath()
    {
        Destroy(gameObject);
    }
}
