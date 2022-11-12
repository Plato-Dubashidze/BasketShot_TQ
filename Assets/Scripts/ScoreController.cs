using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    public Text curScoreText, bestScoreText, starsScore;

    private int curScore, bestScore, stars;

    public int CurScore
    {
        get { return curScore; }
    }


    private void Awake()
    {
        GlobalEventManager.netReached.AddListener(PlusScore);
        GlobalEventManager.starCollected.AddListener(StarCollected);
    }

    private void StarCollected()
    {
        stars++;
        PlayerPrefs.SetInt("Stars", stars);
        starsScore.text = PlayerPrefs.GetInt("Stars").ToString();
    }

    private void Start()
    {
        curScore = 0;
        bestScore = PlayerPrefs.GetInt("BestScore");
        stars = PlayerPrefs.GetInt("Stars");
        starsScore.text = stars.ToString();
        bestScoreText.text = bestScore.ToString();
    }

    private void PlusScore()
    {
        curScore++;
        curScoreText.text = curScore.ToString();
        if (curScore > bestScore)
        {
            PlayerPrefs.SetInt("BestScore", curScore);
            bestScoreText.text = PlayerPrefs.GetInt("BestScore").ToString();
        }
    }
}
