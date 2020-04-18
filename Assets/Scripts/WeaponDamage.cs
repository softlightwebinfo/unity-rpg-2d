using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDamage : MonoBehaviour
{
    [Tooltip("Cantidad de daño")]
    public int damage;
    public GameObject bloodAnim;
    private GameObject hitPoint;
    public GameObject canvasDamage;

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

            var clone = (GameObject)Instantiate(canvasDamage, hitPoint.transform.position, Quaternion.Euler(Vector3.zero));
            clone.GetComponent<DamageNumber>().damagePoints = damage;

            collision.gameObject
                .GetComponent<HealthManager>()
                .DamageCharacter(this.damage);
        }
    }
}
