using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    /* public float timeToRevivePlayer;
     private float timeRevivalCounter;

     private bool playerReviving;
     private GameObject thePlayer;
     */
    [Header("Damage")]
    public int damage;
    public GameObject canvasDamage;
    private CharacterStats playerStats;
    private CharacterStats _stats;

    private void Start()
    {
        playerStats = GameObject.Find("Player").GetComponent<CharacterStats>();
        _stats = GetComponent<CharacterStats>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            float attackFactor = 1 + _stats.strengthLevels[_stats.level] / CharacterStats.MAX_STAT_VALUE;
            float playerFactor = 1 - playerStats.defenseLevels[playerStats.level] / CharacterStats.MAX_STAT_VALUE;

            int totalDamage = Mathf.Clamp((int)(damage * playerFactor * attackFactor), CharacterStats.MIN_DAMAGE_VALUE, CharacterStats.MAX_HEALTH);

            if (Random.Range(0, CharacterStats.MAX_STAT_VALUE) < playerStats.luckLevels[playerStats.level])
            {
                if (Random.Range(0, CharacterStats.MAX_STAT_VALUE) > _stats.accuracyLevels[_stats.level])
                {
                    totalDamage = 0;
                }
            }

            var clone = (GameObject)Instantiate(canvasDamage, collision.gameObject.transform.position, Quaternion.Euler(Vector3.zero));
            clone.GetComponent<DamageNumber>().damagePoints = totalDamage;

            collision.gameObject
                .GetComponent<HealthManager>()
                .DamageCharacter(totalDamage);
        }
    }

    private void Update()
    {
        /*if (playerReviving)
        {
            timeRevivalCounter -= Time.deltaTime;
            if (timeRevivalCounter < 0)
            {
                playerReviving = false;
                thePlayer.SetActive(true);
            }
        }
        */
    }
}
