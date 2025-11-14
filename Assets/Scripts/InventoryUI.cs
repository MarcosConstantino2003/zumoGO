using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    public GameObject inventoryPanel;
    public GameObject itemSlotPrefab;
    public Transform itemContainer;
    public Inventory playerInventory;
   

    private bool isOpen = false;

    void Start()
    {
        if (playerInventory != null)
        {
            playerInventory.OnInventoryChanged += RefreshUI; 
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            ToggleInventory();
        }
    }

    void ToggleInventory()
    {
        isOpen = !isOpen;
        inventoryPanel.SetActive(isOpen);

        if (isOpen)
        {
            RefreshUI();
        }
    }

    public void RefreshUI()
    {
        if (itemContainer == null || itemSlotPrefab == null)
        {
            return;
        }
        foreach (Transform child in itemContainer)
        {
            Destroy(child.gameObject);
        }
        foreach (Inventory.InventorySlot invSlot in playerInventory.items)
        {
            GameObject uiSlot = Instantiate(itemSlotPrefab, itemContainer);
            Image icon = uiSlot.GetComponentInChildren<Image>();
            TMP_Text text = uiSlot.transform.Find("ItemName")?.GetComponent<TMP_Text>();
            TMP_Text description = uiSlot.transform.Find("ItemDescription")?.GetComponent<TMP_Text>();
            if (icon != null) icon.sprite = invSlot.item.icon;
            if (text != null) text.text = invSlot.item.itemName;
            if (description != null) description.text = invSlot.item.description;

        }
    }
    
    
}
