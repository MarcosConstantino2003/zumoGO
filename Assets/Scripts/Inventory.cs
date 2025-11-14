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
        bool found = false;

        foreach (InventorySlot slot in items)
        {
            if (slot.item == newItem)
            {
                slot.quantity += amount;
                found = true;
                break;
            }
        }

        if (!found)
        {
            InventorySlot newSlot = new InventorySlot { item = newItem, quantity = amount };
            items.Add(newSlot);
        }

        OnInventoryChanged?.Invoke();
    }
}
