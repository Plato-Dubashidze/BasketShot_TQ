using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public GameObject endLevelCanvas, scoreCanvas, pauseButtonCanvas, pauseCanvas;
    private void Awake()
    {
        GlobalEventManager.gameFirstStart.AddListener(FirstGameStart);
        GlobalEventManager.levelEnd.AddListener(LevelEnd);
        GlobalEventManager.shoot.AddListener(isShoot);
    }

    private void isShoot(Vector3 force)
    {
        pauseButtonCanvas.SetActive(true);
    }

    private void Start()
    {
        endLevelCanvas.SetActive(false);
    }

    private void LevelEnd()
    {
        Time.timeScale = 1;
        endLevelCanvas.SetActive(true);
        pauseButtonCanvas.SetActive(false);
    }
    private void FirstGameStart()
    {
        scoreCanvas.SetActive(true);
    }

    public void PauseButton()
    {
        Time.timeScale = 0;
        pauseCanvas.SetActive(true);
        pauseButtonCanvas.SetActive(false);
    }

    public void ResumeButton()
    {
        Time.timeScale = 1;
        pauseButtonCanvas.SetActive(true);
        pauseCanvas.SetActive(false);
    }
}
