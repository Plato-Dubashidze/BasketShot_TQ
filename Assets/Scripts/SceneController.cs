using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public GameObject endLevelCanvas, scoreCanvas;
    private void Awake()
    {
        GlobalEventManager.gameFirstStart.AddListener(FirstGameStart);
        GlobalEventManager.levelEnd.AddListener(LevelEnd);
    }


    private void Start()
    {
        endLevelCanvas.SetActive(false);
    }

    private void LevelEnd()
    {
        endLevelCanvas.SetActive(true);
    }
    private void FirstGameStart()
    {
        scoreCanvas.SetActive(true);
    }
}
