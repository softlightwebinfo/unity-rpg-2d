using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public GameObject dialogBox;
    public Text dialogueText;
    public Image avatarImage;
    public bool dialogueActive;

    private void Start()
    {
        dialogBox.SetActive(false);
        dialogueActive = false;
    }

    private void Update()
    {
        if (dialogueActive && Input.GetKeyDown(KeyCode.Space))
        {
            dialogueActive = false;
            avatarImage.enabled = false;
            dialogBox.SetActive(false);
        }
    }

    public void ShowDialogue(string text)
    {
        dialogueActive = true;
        dialogBox.SetActive(true);
        dialogueText.text = text;
    }

    public void ShowDialogue(string text, Sprite sprite)
    {
        avatarImage.sprite = sprite;
        avatarImage.enabled = true;
        ShowDialogue(text);
    }
}
