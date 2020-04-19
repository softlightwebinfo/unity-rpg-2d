using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    private List<GameObject> weapons;
    public int activeWeapon;

    public List<GameObject> GetAllWeapons()
    {
        return weapons;
    }

    void Start()
    {
        this.weapons = new List<GameObject>();

        foreach (Transform weapon in transform)
        {
            weapons.Add(weapon.gameObject);
        }

        for (int i = 0; i < weapons.Count; i++)
        {
            weapons[i].SetActive(i == activeWeapon);
        }
    }

    public void ChangeWeapon(int newWeapon)
    {
        if (activeWeapon > -1)
        {
            weapons[activeWeapon].SetActive(false);
        }
        weapons[newWeapon].SetActive(true);
        activeWeapon = newWeapon;

        if (activeWeapon > -1)
        {
            FindObjectOfType<UIManager>()
                .ChangeWeaponAvatarImage(weapons[activeWeapon].GetComponent<SpriteRenderer>().sprite);
        }
    }

    public WeaponDamage GetWeaponAt(int pos)
    {
        return weapons[pos].GetComponent<WeaponDamage>();
    }
}
