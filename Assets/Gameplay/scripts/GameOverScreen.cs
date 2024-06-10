using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScreen : MonoBehaviour
{
    public GameObject gameOverUI;

    public void Setup()
    {
        gameOverUI.SetActive(true);
    }
}
