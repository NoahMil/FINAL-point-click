using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingDialog : MonoBehaviour
{
    public Dialogue dialogue;
    
    public Action<string> OnGameStart;
    
    void Start()
    {
        dialogue.StartDialogue();
        OnGameStart.Invoke("Début de l'enquête !");
    }

}
