using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class NPCDialogue : MonoBehaviour
{
    public string npcName;
    public string[] npcDialogueLines;
    public Sprite npcSprite;


    private DialogueManager dialogueManager;
    private bool playerInTheZone;

    private void Start()
    {
        dialogueManager = FindObjectOfType<DialogueManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            playerInTheZone = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            playerInTheZone = false;
        }
    }

    private void Update()
    {
        if (playerInTheZone && Input.GetMouseButtonDown(1))
        {
            string[] finalDialogue = new string[npcDialogueLines.Length];
            int i = 0;
            foreach (string line in npcDialogueLines)
            {
                finalDialogue[i++] = npcName != null ? $"{npcName}\n{line}" : line;
            }

            if (npcSprite)
            {
                dialogueManager.ShowDialogue(finalDialogue, npcSprite);
            }
            else
            {
                dialogueManager.ShowDialogue(finalDialogue);
            }

            if (gameObject.GetComponentInParent<NPCMovement>())
            {
                gameObject.GetComponentInParent<NPCMovement>().isTalking = true;
            }
        }
    }
}
