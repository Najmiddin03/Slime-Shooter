using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishMenuScript : MonoBehaviour
{
    public void RestartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene(0);
    }


    public void QuitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
}
