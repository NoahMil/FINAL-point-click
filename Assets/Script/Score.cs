using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI ScoreText;
    public int score = 0;
    
    public Action<string> OnHintsFound;

    private void Start()
    {
        score = 0;
    }

    public void UpdateScore()
    {
        ScoreText.text = "Indices : " + score;
    }
    
    void Update()
    {
        UpdateScore();
    }

    public void AchievementDisplay()
    {
        if (score == 1)
        {
            OnHintsFound.Invoke("Sur la piste du Père-Noël !");
        }
        if (score == 7)
        {
            OnHintsFound.Invoke("Liste de Noël completée !");
        }
    }
}
