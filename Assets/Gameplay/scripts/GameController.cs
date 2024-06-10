using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameOverScreen gameOverScreen;

    public void GameOver()
    {
        if (gameOverScreen != null)
        {
            gameOverScreen.Setup();
        }
        else
        {
            Debug.LogError("GameOverScreen is not assigned in the GameController.");
        }
    }

    public void RestartButton()
    {
        SceneManager.LoadScene(1);
    }
}
