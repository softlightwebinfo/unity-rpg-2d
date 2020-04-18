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

    [Header("Experience")]
    public Text playerLevelText;
    public Slider playerExpBar;

    [Header("Stats")]
    public CharacterStats playerStats;

    [Header("Avatar")]
    public Image playerAvatar;

    private void Update()
    {
        this.BuildHealthBar();
        this.BuildLevelBar();
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

    private void BuildLevelBar()
    {
        playerLevelText.text = $"Nivel {playerStats.level}";
        if (playerStats.level >= playerStats.expToLevelUp.Length)
        {
            playerExpBar.enabled = false;
            return;
        }
        playerExpBar.maxValue = playerStats.expToLevelUp[playerStats.level];
        playerExpBar.minValue = playerStats.expToLevelUp[playerStats.level - 1];
        playerExpBar.value = playerStats.exp;
    }
}
