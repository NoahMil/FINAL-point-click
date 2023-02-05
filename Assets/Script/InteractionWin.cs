using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InteractionWin : MonoBehaviour
{
    public Dialogue dialogue;
    private bool InRange;
    public Score score;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && InRange && DialogueManager.isActive == false)
        {
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
        }
    }
    
    
   // public void Win()
   //  {
   //      if (score.newScore == 7)
   //      {
   //          Debug.Log("You win!");
   //
   //          SceneManager.LoadScene("Win");
   //      }
   //  }
    

}