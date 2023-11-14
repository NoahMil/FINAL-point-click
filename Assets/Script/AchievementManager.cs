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
    private bool _afkAchievementDisplayed = false;
    private bool _afkAchievementDisplayed2 = false;


    
    private void OnEnable()
    {
        StartingDialog.OnGameStart += DisplayAchievement;
        InteractionWin.OnGameEnd += DisplayAchievement;
        InteractionItem.OnHintsFound += ScoreCounting;
        ItemPickup.OnHintsFound += ScoreCounting;
        GameManager.OnVillagersAwake += AwakeVillage;
        Player.OnAFKTime += AfkTime;
    }
    
    private void OnDisable()
    {
        StartingDialog.OnGameStart -= DisplayAchievement;
        InteractionWin.OnGameEnd -= DisplayAchievement;
        InteractionItem.OnHintsFound -= ScoreCounting;
        ItemPickup.OnHintsFound -= ScoreCounting;
        GameManager.OnVillagersAwake -= AwakeVillage;
        Player.OnAFKTime -= AfkTime;
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
    
    private void ScoreCounting()
    {
        if (Score.score == 1)
        {
            DisplayAchievement("Voici le premier object");
        }
        
        if (Score.score == 7)
        {
            DisplayAchievement("J'ai trouvé tous les objets de la liste");
        }
    }

    private void AwakeVillage()
    {
        if (GameManager.awakeVillagers == GameManager.totalVillagers)
        {
            DisplayAchievement("J'ai reveillé tout le village");
        }

        if (GameManager.awakeVillagers == 4)
        {
            DisplayAchievement("J'ai déjà interrogé la moitié du village");
        }
    }


    private void AfkTime()
    {
        Player.currentAFKTime += Time.deltaTime;
        if (Player.currentAFKTime >= Player.maxAFKTime && !_afkAchievementDisplayed)
        {
            DisplayAchievement("J'ai terminé de lire mon journal, retournons à l'enquête !");
            _afkAchievementDisplayed = true; 
        }

        if (Player.currentAFKTime >= 10f && !_afkAchievementDisplayed2)
        {
            DisplayAchievement("D'après la météo, il ne neigera pas demain, bizarre");
            _afkAchievementDisplayed2 = true;  
        }
    }

}

