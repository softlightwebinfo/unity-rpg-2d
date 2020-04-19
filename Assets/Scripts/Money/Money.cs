using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class Money : MonoBehaviour
{
    public int value;

    private MoneyManager manager;

    private void Start()
    {
        manager = FindObjectOfType<MoneyManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            manager.AddMoney(value);
            Destroy(gameObject);
        }
    }
}
