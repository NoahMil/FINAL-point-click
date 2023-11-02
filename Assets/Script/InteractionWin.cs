using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InteractionWin : MonoBehaviour
{
    public Dialogue dialogue;
    private bool InRange;
    public Score score;

    [SerializeField] private AudioSource doorbellSE;
    [SerializeField] private GameObject lightedhouse ;

    public Action<string> OnGameEnd;
    private void Start()
    {
        lightedhouse.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && InRange && DialogueManager.isActive == false)
        {
            if (score.score >= 7)
            {
                Win();
                OnGameEnd.Invoke("Père-Noël retrouvé!");
            }
            else
            {
                doorbellSE.Play();
                lightedhouse.SetActive(true);
                dialogue.StartDialogue();
            }
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
    
    public void Win()
    {
        SceneManager.LoadScene("Win");
    }
}
