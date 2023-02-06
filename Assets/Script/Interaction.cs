using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.XR;

public class Interaction : MonoBehaviour
{
    public Dialogue dialogue;
    private bool InRange;
    private bool onDialog;
    [SerializeField] private AudioSource doorbellSE;
    [SerializeField] private GameObject lightedhouse ;

    private void Start()
    {
        lightedhouse.SetActive(false);
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && InRange && DialogueManager.isActive == false && onDialog == false)
        {
            doorbellSE.Play();
            lightedhouse.SetActive(true);
            dialogue.StartDialogue();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            InRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            InRange = false;
            lightedhouse.SetActive(false);
        }
    }
}

    
    
    
    