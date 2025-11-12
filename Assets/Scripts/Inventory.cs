using System;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [Serializable]
    public class InventorySlot
    {
        public Item item;
        public int quantity;
    }

    public List<InventorySlot> items = new List<InventorySlot>();

    public event Action OnInventoryChanged;

    public void AddItem(Item newItem, int amount)
    {
        Debug.Log($"Trying to add {amount}x {newItem.itemName}");
        bool found = false;

        foreach (InventorySlot slot in items)
        {
            if (slot.item == newItem)
            {
                slot.quantity += amount;
                found = true;
                Debug.Log($"Stacked {amount}x {newItem.itemName}, total now {slot.quantity}");
                break;
            }
        }

        if (!found)
        {
            InventorySlot newSlot = new InventorySlot { item = newItem, quantity = amount };
            items.Add(newSlot);
            Debug.Log($"Added new slot for {newItem.itemName}");
        }

        OnInventoryChanged?.Invoke();
    }
}
