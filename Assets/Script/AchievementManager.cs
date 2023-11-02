using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AchievementManager : MonoBehaviour
{
    public GameObject achievementPanel;
    public Text achievementText;
    private bool _achievementDisplayed;
    private void Start()
    {
        GameManager.Instance.OnVillagersAwake += DisplayAchievement;
        
        InteractionWin InteractionWin = FindObjectOfType<InteractionWin>();
        InteractionWin.OnGameEnd += DisplayAchievement;
        
        Score Score = FindObjectOfType<Score>();
        Score.OnHintsFound += DisplayAchievement;

        StartingDialog StartingDialog = FindObjectOfType<StartingDialog>();
        StartingDialog.OnGameStart += DisplayAchievement;

    }

    private void DisplayAchievement(string achievementName)
    {
        achievementText.text = achievementName;
        StartCoroutine(DisableAchievementPanel());
        if (!_achievementDisplayed)
        {
            achievementPanel.SetActive(true);
        }
    }

    private IEnumerator DisableAchievementPanel()
    {
        yield return new WaitForSeconds(5f);
        achievementPanel.SetActive(false);
    }


}

