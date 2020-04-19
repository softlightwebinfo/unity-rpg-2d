using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public List<Quest> quests;
    public QuestItem itemCollected;
    public QuestEnemy enemyKilled;

    private DialogueManager dialogueManager;

    private void Start()
    {
        dialogueManager = FindObjectOfType<DialogueManager>();
        foreach (Transform t in gameObject.transform)
        {
            quests.Add(t.gameObject.GetComponent<Quest>());
        }
    }

    public void ShowQuestText(string questText)
    {
        dialogueManager.ShowDialogue(new string[] { questText });
    }

    public Quest QuestWithID(int questID)
    {
        Quest q = null;
        foreach (Quest temp in quests)
        {
            if (temp.questID == questID)
            {
                q = temp;
                break;
            }
        }

        return q;
    }

}
