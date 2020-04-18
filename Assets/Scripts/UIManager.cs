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

    [Header("Inventory")]
    public GameObject inventoryPanel;
    public Button inventoryButton;

    private void Update()
    {
        this.BuildHealthBar();
        this.BuildLevelBar();

        if (Input.GetKeyDown(KeyCode.I))
        {
            this.ToggleInventory();
        }
    }

    private void BuildHealthBar()
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

    private void BuildLevelBar()
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
        inventoryPanel.SetActive(!inventoryPanel.activeInHierarchy);
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
        WeaponManager manager = FindObjectOfType<WeaponManager>();
        List<GameObject> weapons = manager.GetAllWeapons();

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
}
