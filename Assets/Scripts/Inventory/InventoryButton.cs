using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryButton : MonoBehaviour
{
    public enum ItemType { WEAPON = 0, ITEM = 1, ARMOR = 2, RING = 3, SPETIAL_ITEMS = 4 };
    public int itemIdx;
    public ItemType type;

    public void ActivateButton()
    {
        switch (type)
        {
            case ItemType.WEAPON:
                FindObjectOfType<WeaponManager>().ChangeWeapon(itemIdx);
                break;
            case ItemType.ARMOR:
                Debug.Log("En futuros DLCS...");
                break;
            case ItemType.RING:
                Debug.Log("En futuros DLCS...");
                break;
            case ItemType.ITEM:
                Debug.Log("En futuros DLCS...");
                break;
        }
        ShowDescription();
    }

    public void ClearDescription()
    {
        FindObjectOfType<UIManager>().inventoryText.text = "";
        FindObjectOfType<UIManager>().inventoryText.transform.parent.transform.gameObject.SetActive(false);
    }

    public void ShowDescription()
    {
        string desc = "";
        switch (type)
        {
            case ItemType.WEAPON:
                desc = FindObjectOfType<WeaponManager>().GetWeaponAt(itemIdx).weaponName;
                break;
            case ItemType.ARMOR:
                desc = FindObjectOfType<WeaponManager>().GetArmorAt(itemIdx).name;
                break;
            case ItemType.RING:
                desc = FindObjectOfType<WeaponManager>().GetRingAt(itemIdx).name;
                break;
            case ItemType.ITEM:
                desc = "Item consumible";
                break;
            case ItemType.SPETIAL_ITEMS:
                QuestItem item = FindObjectOfType<ItemsManager>().GetItemAt(itemIdx);
                desc = item.itemName;
                break;

        }
        FindObjectOfType<UIManager>().inventoryText.text = desc;
        FindObjectOfType<UIManager>().inventoryText.transform.parent.transform.gameObject.SetActive(true);
    }
}
