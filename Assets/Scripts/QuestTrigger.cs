using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestTrigger : MonoBehaviour
{
    private QuestManager questManager;
    private bool playerInZone;

    public int questID;
    public bool startPoint, endPoint;
    public bool automaticCatch;


    private void Start()
    {
        questManager = FindObjectOfType<QuestManager>();
    }

    private void Update()
    {
        if (playerInZone)
        {
            if (automaticCatch || (!automaticCatch && Input.GetMouseButtonDown(1)))
            {
                Quest q = questManager.QuestWithID(questID);
                if (!q)
                {
                    Debug.LogErrorFormat("La mision con ID {0} no existe", questID);
                    return;
                }

                if (!q.questCompleted)// Si quitamos esta linea, la mision es repetible
                {
                    if (startPoint)
                    {
                        if (!q.gameObject.activeInHierarchy)
                        {
                            q.gameObject.SetActive(true);
                            q.StartQuest();
                        }
                    }
                    if (endPoint)
                    {
                        if (q.gameObject.activeInHierarchy)
                        {
                            q.CompleteQuest();
                        }
                    }
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            playerInZone = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            playerInZone = false;
        }
    }
}
