using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDamage : MonoBehaviour
{
    public string weaponName;

    [Tooltip("Cantidad de daño")]
    public int damage;
    public GameObject bloodAnim;
    private GameObject hitPoint;
    public GameObject canvasDamage;

    private CharacterStats stats;

    private void Start()
    {
        hitPoint = transform.Find("HitPoint").gameObject;
        stats = GameObject.Find("Player").GetComponent<CharacterStats>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Enemy"))
        {
            CharacterStats enemyStats = collision.gameObject.GetComponent<CharacterStats>();
            float playerFactor = (1 + stats.strengthLevels[stats.level] / CharacterStats.MAX_STAT_VALUE);
            float enemyFactor = (1 - enemyStats.defenseLevels[enemyStats.level] / CharacterStats.MAX_STAT_VALUE);
            int totalDamage = (int)(damage * enemyFactor * playerFactor);

            if (Random.Range(0, CharacterStats.MAX_STAT_VALUE) < stats.accuracyLevels[stats.level])
            {
                if (Random.Range(0, CharacterStats.MAX_STAT_VALUE) < enemyStats.luckLevels[enemyStats.level])
                {
                    totalDamage = 0;
                }
                else
                {
                    totalDamage *= 5;
                }
            }

            if (bloodAnim && hitPoint)
            {
                Destroy(Instantiate(bloodAnim, hitPoint.transform.position, hitPoint.transform.rotation), 0.5f);
            }

            var clone = (GameObject)Instantiate(canvasDamage, hitPoint.transform.position, Quaternion.Euler(Vector3.zero));
            clone.GetComponent<DamageNumber>().damagePoints = totalDamage;

            collision.gameObject
                .GetComponent<HealthManager>()
                .DamageCharacter(totalDamage);
        }
    }
}
