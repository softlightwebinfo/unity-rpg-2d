using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDamage : MonoBehaviour
{
    [Tooltip("Cantidad de daño")]
    public int damage;
    public GameObject bloodAnim;
    private GameObject hitPoint;

    private void Start()
    {
        hitPoint = transform.Find("HitPoint").gameObject;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Enemy"))
        {
            if (bloodAnim && hitPoint)
            {
                Destroy(Instantiate(bloodAnim, hitPoint.transform.position, hitPoint.transform.rotation), 0.5f);
            }

            collision.gameObject
                .GetComponent<HealthManager>()
                .DamageCharacter(this.damage);
        }
    }
}
