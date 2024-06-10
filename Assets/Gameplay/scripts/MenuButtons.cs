using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MenuButtons : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(1);
        Debug.Log("Start new game!");
    }

    public void ExitGame()
    {
        Debug.Log("Exit game!");
        Application.Quit();
    }

    public void ExitLevel()
    {
        Debug.Log("Back to menu");
        SceneManager.LoadScene(0);
    }
}
