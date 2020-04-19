using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public GameObject dialogBox;
    public Text dialogueText;
    public Image avatarImage;
    public bool dialogueActive;

    public string[] dialogueLines;
    public int currentDialogLine;

    private PlayerController playerController;

    private void Start()
    {
        dialogBox.SetActive(false);
        dialogueActive = false;
        playerController = FindObjectOfType<PlayerController>();
    }

    private void Update()
    {
        if (dialogueActive && Input.GetKeyDown(KeyCode.Space))
        {
            currentDialogLine++;

            if (currentDialogLine >= dialogueLines.Length)
            {
                currentDialogLine = 0;
                dialogueActive = false;
                avatarImage.enabled = false;
                playerController.isTalking = false;

                dialogBox.SetActive(false);
            }
            else
            {
                dialogueText.text = dialogueLines[currentDialogLine];
            }
        }
    }

    public void ShowDialogue(string[] lines)
    {
        currentDialogLine = 0;
        dialogueLines = lines;
        dialogueActive = true;
        dialogueText.text = dialogueLines[currentDialogLine];
        playerController.isTalking = true;
        dialogBox.SetActive(true);
    }

    public void ShowDialogue(string[] lines, Sprite sprite)
    {
        avatarImage.sprite = sprite;
        avatarImage.enabled = true;
        ShowDialogue(lines);
    }
}
