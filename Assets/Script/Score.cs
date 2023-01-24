using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI ScoreText;
    public int score = 0;
    private int maxscore = 7;


    private void Start()
    {
        score = 0;
    }

    public void AddScore(int newScore)
    {
        score += newScore;
    }

    public void UpdateScore()
    {
        ScoreText.text = "Indices : " + score;

        if (score == maxscore)
        {

        }
    }

    void Update()
    {
        UpdateScore();
    }
}
