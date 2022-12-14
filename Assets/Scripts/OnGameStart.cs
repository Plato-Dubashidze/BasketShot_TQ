using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnGameStart : MonoBehaviour
{
    [Range(10, 100)]
    public int ChanceOfStarSpawning;

    public GameObject onGameStartCanvas;

    private bool isGameStartedOnce;

    private void Awake()
    {
        isGameStartedOnce = PlayerPrefs.GetInt("IsStartedOnce") != 0;
        BasketsCount.basketsCount = 0;
        PlayerPrefs.SetInt("ChanceOfStarSpawning", ChanceOfStarSpawning);
        Application.targetFrameRate = 300;
        if (!isGameStartedOnce)
        {
            PlayerPrefs.SetString("BackGroundMode", "White");
            PlayerPrefs.SetInt("SoundBool", true ? 1 : 0);
            PlayerPrefs.SetInt("IsStartedOnce", true ? 1 : 0);
        }

        GlobalEventManager.gameFirstStart.AddListener(FirstGameStart);

        onGameStartCanvas.SetActive(true);
    }

    private void FirstGameStart()
    {
        onGameStartCanvas.SetActive(false);
    }
}
