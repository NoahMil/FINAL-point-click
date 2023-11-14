using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionItem : MonoBehaviour
{
    public Dialogue dialogue;
    public Score score;
    private bool InRange;
    private bool onDialog;
    private bool alreadypicked;
    private bool awakeState;
    [SerializeField] private AudioSource doorbellSE;
    [SerializeField] private GameObject lightedhouse;
    [SerializeField] private AudioSource collectitem;
    [SerializeField] private Item item;
    
    public static Action OnHintsFound;
    
    private void Start()
    {
        lightedhouse.SetActive(false);
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && InRange && DialogueManager.isActive == false && onDialog == false && awakeState == false) 
        {
            if (alreadypicked == false)
            {
                PickupInteraction();
                OnHintsFound?.Invoke();
            }
            doorbellSE.Play();
            lightedhouse.SetActive(true);
            dialogue.StartDialogue();
            awakeState = true;
            GameManager.Instance.IncrementAwakeVillagers();
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

    private void PickupInteraction()
    {
        InventoryManager.instance.AddItem(item); 
        Destroy(transform.GetChild(0).gameObject);
        Score.score++;
        collectitem.Play();
        alreadypicked = true;
        OnHintsFound?.Invoke();
    }
}
