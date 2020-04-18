using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public const int MAX_STAT_VALUE = 100;
    public const int MAX_HEALTH = 9999;
    public const int MIN_DAMAGE_VALUE = 1;

    [Header("Experience")]
    public int level;
    public int exp;
    public int[] expToLevelUp;

    [Header("Levels Estats")]
    [Tooltip("Niveles de vida del personaje")]
    public int[] hpLevels;
    [Tooltip("Fuerza que se suma a la del arma")]
    public int[] strengthLevels;
    [Tooltip("Defensa que divide al daño del enemigo")]
    public int[] defenseLevels;
    [Tooltip("Velocidad de ataque")]
    public int[] speedLevels;
    [Tooltip("Probabilidad de que el enemigo falle")]
    public int[] luckLevels;
    [Tooltip("Probabilidad de que falle el personaje")]
    public int[] accuracyLevels;

    private PlayerController playerController;

    private HealthManager healthManager;

    private void Start()
    {
        this.healthManager = GetComponent<HealthManager>();
        this.playerController = GetComponent<PlayerController>();
        healthManager.UpdateMaxHealth(hpLevels[level]);
        if (gameObject.tag.Equals("Enemy"))
        {
            EnemyController controller = GetComponent<EnemyController>();
            controller.speed += (speedLevels[level] / MAX_STAT_VALUE);
        }
    }

    public void AddExperience(int exp)
    {
        this.exp += exp;

        if (level >= expToLevelUp.Length)
        {
            return;
        }

        if (this.exp >= expToLevelUp[level])
        {
            this.level++;
            healthManager.UpdateMaxHealth(hpLevels[level]);
            playerController.attackTime -= speedLevels[level] / MAX_STAT_VALUE;
        }
    }
}
