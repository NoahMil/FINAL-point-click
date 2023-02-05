using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Image actorImage;
    public Text actorName;
    public Text messageText;
    public RectTransform backgroundBox;

    Dialogue.Message[] currentMessages;
    Dialogue.Actor[] currentActors;
    int activeMessage = 0;
    public static bool isActive = false;

    private void Start()
    {
        backgroundBox.transform.localScale = Vector3.zero;
    }

    void Update()
    {
        NextMessage();
    }

    public void OpenDialogue(Dialogue.Message[] messages, Dialogue.Actor[] actors)
    {
        currentMessages = messages;
        currentActors = actors;
        activeMessage = 0;
        isActive = true;
        DisplayMessage();
        backgroundBox.transform.localScale = Vector3.one;
    }

    void DisplayMessage()
    {
        Dialogue.Message messageToDisplay = currentMessages[activeMessage];
        messageText.text = messageToDisplay.message;

        Dialogue.Actor actorToDisplay = currentActors[messageToDisplay.actorId];
        actorName.text = actorToDisplay.name;
        actorImage.sprite = actorToDisplay.sprite;
    }

    public void NextMessage()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isActive == false)
        {
            {
                activeMessage++;
                if (activeMessage < currentMessages.Length)
                {
                    DisplayMessage();
                }
                else
                {
                    backgroundBox.transform.localScale = Vector3.zero;
                    StartCoroutine(delay());
                }
            }
        }
    }

    private IEnumerator delay()
    {
        yield return new WaitForSeconds(0.1f);
        isActive = false;
    }
}
