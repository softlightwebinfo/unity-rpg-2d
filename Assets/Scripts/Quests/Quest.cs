using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Quest : MonoBehaviour
{

    public int questID;
    public string title;
    public string startText;
    public string completeText;
    public bool questCompleted;

    public Quest nextQuest;

    [Header("Quest items")]
    public bool needsItem;
    public List<QuestItem> itemsNeeded;

    [Header("Quest kills")]
    public bool killsEnemy;
    public List<QuestEnemy> enemies;
    public List<int> numberOfEnemies;

    private QuestManager questManager;


    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (needsItem)
        {
            ActivateItems();
        }

        if (killsEnemy)
        {
            ActivateEnemies();
        }
    }

    public void StartQuest()
    {
        questManager = FindObjectOfType<QuestManager>();
        questManager.ShowQuestText(title + "\n" + startText);
        if (needsItem)
        {
            ActivateItems();
        }

        if (killsEnemy)
        {
            ActivateEnemies();
        }
    }

    void ActivateItems()
    {
        Object[] items = Resources.FindObjectsOfTypeAll<QuestItem>();
        foreach (QuestItem item in items)
        {
            if (item.questID == questID)
            {
                item.gameObject.SetActive(true);
            }
        }
    }

    void ActivateEnemies()
    {
        Object[] qenemies = Resources.FindObjectsOfTypeAll<QuestEnemy>();
        foreach (QuestEnemy enemy in qenemies)
        {
            if (enemy.questID == questID)
            {
                enemy.gameObject.SetActive(true);
            }
        }
    }

    public void CompleteQuest()
    {
        questManager = FindObjectOfType<QuestManager>();
        questManager.ShowQuestText(title + "\n" + completeText);
        questCompleted = true;

        if (nextQuest)
        {
            Invoke("ActivateNextQuest", 5.0f);
        }

        gameObject.SetActive(false);
    }

    private void ActivateNextQuest()
    {
        nextQuest.gameObject.SetActive(true);
        nextQuest.StartQuest();
    }

    private void Update()
    {
        // Quest type 2
        if (needsItem && questManager.itemCollected)
        {
            for (int i = 0; i < itemsNeeded.Count; i++)
            {
                if (itemsNeeded[i].itemName == questManager.itemCollected.itemName)
                {
                    itemsNeeded.RemoveAt(i);
                    questManager.itemCollected = null;
                    break;
                }
            }

            if (itemsNeeded.Count == 0)
            {
                CompleteQuest();
            }
        }

        // Quest type 3
        if (killsEnemy && questManager.enemyKilled)
        {
            for (int i = 0; i < enemies.Count; i++)
            {
                if (enemies[i].enemyName == questManager.enemyKilled.enemyName)
                {
                    numberOfEnemies[i]--;
                    questManager.enemyKilled = null;
                    if (numberOfEnemies[i] <= 0)
                    {
                        enemies.RemoveAt(i);
                        numberOfEnemies.RemoveAt(i);
                    }
                    break;
                }
            }

            if (enemies.Count == 0)
            {
                CompleteQuest();
            }
        }
    }
}
