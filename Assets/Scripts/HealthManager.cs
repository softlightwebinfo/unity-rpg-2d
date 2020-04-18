using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    [Header("Flash")]
    public int maxHealth;
    [SerializeField]
    private int currentHealth;

    [Header("Flash")]
    public bool flashActive;
    public float flashLength;
    private float flashCounter;
    private SpriteRenderer _characterRenderer;


    public int Health
    {
        get { return currentHealth; }
    }

    void Start()
    {
        _characterRenderer = GetComponent<SpriteRenderer>();
        UpdateMaxHealth(maxHealth);
    }

    private void Update()
    {
        if (flashActive)
        {
            flashCounter -= Time.deltaTime;
            if (flashCounter > flashLength * 0.66f)
            {
                ToggleColor(false);
            }
            else if (flashCounter > flashLength * 0.33f)
            {
                ToggleColor(true);
            }
            else if (flashCounter > 0)
            {
                ToggleColor(false);
            }
            else
            {
                ToggleColor(true);
                flashActive = false;
                GetComponent<BoxCollider2D>().enabled = true;
                GetComponent<PlayerController>().canMove = true;
            }
        }
    }

    public void DamageCharacter(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }

        if (flashLength > 0)
        {
            GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<PlayerController>().canMove = false;
            flashActive = true;
            flashCounter = flashLength;
        }
    }

    private void ToggleColor(bool visible)
    {
        _characterRenderer.color = new Color(
            _characterRenderer.color.r,
            _characterRenderer.color.g,
            _characterRenderer.color.b, visible ? 1.0f : 0.0f);
    }

    public void UpdateMaxHealth(int newMaxHealth)
    {
        this.maxHealth = newMaxHealth;
        this.currentHealth = maxHealth;
    }
}
