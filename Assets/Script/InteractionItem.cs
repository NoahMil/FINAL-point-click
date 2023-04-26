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
    [SerializeField] private AudioSource doorbellSE;
    [SerializeField] private GameObject lightedhouse;
    [SerializeField] private AudioSource collectitem;
    [SerializeField] private Item item;
    


    private void Start()
    {
        lightedhouse.SetActive(false);
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && InRange && DialogueManager.isActive == false && onDialog == false)
        {
            if (alreadypicked == false)
            {
                PickupInteraction();
            }
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

    public void PickupInteraction()
    {
        InventoryManager.instance.AddItem(item); 
        Destroy(transform.GetChild(0).gameObject);
        score.score++;
        collectitem.Play();
        alreadypicked = true;
    }
}
