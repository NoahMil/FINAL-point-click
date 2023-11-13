using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingDialog : MonoBehaviour
{
    public Dialogue dialogue;

    public static Action<string> OnGameStart;

    private const string launchCountKey = "LaunchCount";

    void Start()
    {
        int launchCount = PlayerPrefs.GetInt(launchCountKey, 0);

        if (launchCount == 0)
        {
            PlayerPrefs.SetInt(launchCountKey, 1);
            dialogue.StartDialogue();
            OnGameStart?.Invoke("Début de l'enquête !");
        }
        else
        {
            OnGameStart?.Invoke("Le Père-Noël est encore en retard cette année ?");
        }
    }
    private void OnApplicationQuit()
    {
        PlayerPrefs.DeleteKey(launchCountKey);
    }
}