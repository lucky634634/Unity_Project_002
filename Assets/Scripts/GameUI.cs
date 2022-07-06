using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameUI : MonoBehaviour
{
    public static bool isPaused;
    public TextMeshProUGUI scoreDisplay;
    public TextMeshProUGUI highScoreDisplay;
    public GameObject gameOver;
    public GameController gameController;
    public PlayerController playerController;
    public TextMeshProUGUI gameOverScoreDisplay;
    public GameObject pausedMenu;

    private GameObject pause;

    private void Start()
    {
        gameOver.SetActive(false);
        pausedMenu.SetActive(false);
        isPaused = false;
    }

    private void Update()
    {
        scoreDisplay.text = gameController.score.ToString();
        if (playerController.isDead)
        {
            gameOver.SetActive(true);
            gameOverScoreDisplay.text = gameController.score.ToString();
            highScoreDisplay.text = GameManager.highsScore.ToString();
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (isPaused)
                {
                    Resume();
                }
                else
                {
                    Pause();
                }
            }
        }
    }

    public void Resume()
    {
        pausedMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void Pause()
    {
        pausedMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    private void OnApplicationPause(bool pause)
    {
        if (pause)
            Pause();
    }
}
