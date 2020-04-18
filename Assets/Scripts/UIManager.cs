using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("Player health")]
    public Slider playerHealthBar;
    public Text playerHealthText;
    public HealthManager playerHealthManager;

    [Header("Player Mana")]
    public Slider playerManaBar;
    public Text playerManaText;

    private void Update()
    {
        this.BuildHealthBar();
    }

    private void BuildHealthBar()
    {
        playerHealthBar.maxValue = playerHealthManager.maxHealth;
        playerHealthBar.value = playerHealthManager.Health;

        StringBuilder stringBuilder = new StringBuilder()
            .Append("HP: ")
            .Append(playerHealthManager.Health)
            .Append(" / ")
            .Append(playerHealthManager.maxHealth);

        playerHealthText.text = stringBuilder.ToString();
    }
}
