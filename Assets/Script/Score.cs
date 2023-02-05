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
    
    public void Win()
    {
        if (score == 7)
        {
            Debug.Log("You win!");
            SceneManager.LoadScene("Win");
        }
    }
}
