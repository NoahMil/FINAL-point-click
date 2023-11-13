using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{ 
    public static GameManager Instance { get; private set; }

    public static int awakeVillagers = 0;
    public static int totalVillagers;
    
    public static Action OnVillagersAwake;
    
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
        OnVillagersAwake?.Invoke();
    }
}

