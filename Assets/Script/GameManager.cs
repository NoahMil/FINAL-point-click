using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{ 
    public static GameManager Instance { get; private set; }

    private int awakeVillagers = 0;
    private int totalVillagers;
    
    public Action<string> OnVillagersAwake;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        totalVillagers = FindObjectsOfType<Interaction>().Length 
                         + FindObjectsOfType<InteractionItem>().Length;
    }

    public void IncrementAwakeVillagers()
    {
        awakeVillagers++;

        if (awakeVillagers == totalVillagers)
        {
            OnVillagersAwake.Invoke("Tu as réveillé tout le village !");
        }
    }
}

