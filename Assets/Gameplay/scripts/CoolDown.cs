using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoolDown : MonoBehaviour
{
    [SerializeField] private TMP_Text timerText;
    [SerializeField] private float remainingTime = 90f;
    private GameController gameController;

    // Start is called before the first frame update
    void Start()
    {
        gameController = FindObjectOfType<GameController>();
        if (gameController == null)
        {
            Debug.LogError("GameController not found in the scene.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        remainingTime -= Time.deltaTime;
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        if (remainingTime <= 0)
        {
            gameController.GameOver();
        }
    }
}
