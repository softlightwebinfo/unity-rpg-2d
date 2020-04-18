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

    [Header("Weapon")]
    public Image playerWeapon;

    [Header("Inventory")]
    public GameObject inventoryPanel;
    public Button inventoryButton;
    public GameObject inventoryPanelGroup;

    private WeaponManager _weaponManager;

    private void Start()
    {
        this.inventoryPanelGroup.SetActive(false);
        this._weaponManager = FindObjectOfType<WeaponManager>();
    }

    private void Update()
    {
        this.HealthChanged();
        this.LevelChanged();

        if (Input.GetKeyDown(KeyCode.I))
        {
            this.ToggleInventory();
        }
    }

    public void HealthChanged()
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

    private void LevelChanged()
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

    public void ToggleInventory()
    {
        inventoryPanelGroup.SetActive(!inventoryPanelGroup.activeInHierarchy);
        if (inventoryPanel.activeInHierarchy)
        {
            foreach (Transform t in inventoryPanel.transform)
            {
                Destroy(t.gameObject);
            }
            this.FillInventory();
        }
    }

    public void FillInventory()
    {
        List<GameObject> weapons = _weaponManager.GetAllWeapons();

        int i = 0;
        foreach (GameObject w in weapons)
        {
            Button tempB = Instantiate(inventoryButton, inventoryPanel.transform);
            InventoryButton inv = tempB.GetComponent<InventoryButton>();
            inv.type = InventoryButton.ItemType.WEAPON;
            inv.itemIdx = i;

            tempB.onClick.AddListener(() => inv.ActivateButton());
            tempB.transform.Find("Image").GetComponent<Image>().sprite = w.GetComponent<SpriteRenderer>().sprite;
            i++;
        }
    }

    public void ShowOnly(int type)
    {
        foreach (Transform t in inventoryPanel.transform)
        {
            t.gameObject.SetActive((int)t.GetComponent<InventoryButton>().type == type);
        }
    }

    public void ShowAll()
    {
        foreach (Transform t in inventoryPanel.transform)
        {
            t.gameObject.SetActive(true);
        }
    }

    public void ChangeWeaponAvatarImage(Sprite sprite)
    {
        this.playerWeapon.sprite = sprite;
        this.playerWeapon.enabled = true;
    }
}
