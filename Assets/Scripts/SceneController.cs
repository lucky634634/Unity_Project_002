using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadSceneAsync("GamePlay");
    }

    public void ToStartMenu()
    {
        SceneManager.LoadSceneAsync("StartMenu");
    }

    public void ToOptionMenu()
    {
        SceneManager.LoadSceneAsync("OptionMenu");
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }
}
