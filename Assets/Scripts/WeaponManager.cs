using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [Header("Weapon")]
    private List<GameObject> weapons;
    public int activeWeapon;

    [Header("Armour")]
    private List<GameObject> armors;
    public int activeArmor;

    [Header("Rings")]
    private List<GameObject> rings;
    public int activeRing1, activeRing2;


    public List<GameObject> GetAllWeapons()
    {
        return weapons;
    }

    public List<GameObject> GetAllArmors()
    {
        return armors;
    }

    public List<GameObject> GetAllRings()
    {
        return rings;
    }


    public WeaponDamage GetWeaponAt(int pos)
    {
        return weapons[pos].GetComponent<WeaponDamage>();
    }


    public GameObject GetArmorAt(int pos)
    {
        return armors[pos];
    }

    public GameObject GetRingAt(int pos)
    {
        return rings[pos];
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

        // TODO: Armours and rings
        this.armors = new List<GameObject>();
        this.rings = new List<GameObject>();
    }
}
