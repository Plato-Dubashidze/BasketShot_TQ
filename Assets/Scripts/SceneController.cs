using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    private void Awake()
    {
        GlobalEventManager.levelEnd.AddListener(LevelEnd);
    }

    private void LevelEnd()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
