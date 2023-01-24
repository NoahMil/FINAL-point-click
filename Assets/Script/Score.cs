using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static Score instance;
    
    public TextMeshProUGUI scoreText;
    private int score = 0;
    public void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        scoreText.text = "Indices : " + score.ToString();
    }

    public void ScoreUp()
    {
        score += 1;
    }
}
