using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    [SerializeField] private Item item;
    private bool InRange;
    public Score score;
    [SerializeField] private AudioSource collectitem;
    
    public static Action OnHintsFound;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && InRange && DialogueManager.isActive == false)
        {
            Pickup();
        }
    }
    
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            InRange = true;
        }
    }

    public void Pickup()
    {
        InventoryManager.instance.AddItem(item);
        Destroy(gameObject);
        Score.score++;
        collectitem.Play();
        OnHintsFound?.Invoke();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            InRange = false;
        }
    }
}