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
            case ItemType.SPETIAL_ITEMS:
                QuestItem item = FindObjectOfType<ItemsManager>().GetItemAt(itemIdx);
                Debug.Log(item.itemName);
                break;

        }
    }
}
