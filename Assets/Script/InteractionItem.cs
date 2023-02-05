using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionItem : MonoBehaviour
{
    public Dialogue dialogue;
    private bool InRange;
    private bool alreadyPicked;
    [SerializeField] private Item item;
    public Score score;
    [SerializeField] private AudioSource doorbellSE;

    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && InRange && DialogueManager.isActive == false)
        {
            doorbellSE.Play();
            dialogue.StartDialogue();
            
            if (alreadyPicked == !true)
            {
                Pickup();
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
        }
    }
    
    public void Pickup()
    {
        InventoryManager.instance.AddItem(item);
        Destroy(gameObject);
        alreadyPicked = true;
        score.score++;
    }
}
