using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingDialog : MonoBehaviour
{
    public Dialogue dialogue;

    void Start()
    {
        dialogue.StartDialogue();
    }

}
