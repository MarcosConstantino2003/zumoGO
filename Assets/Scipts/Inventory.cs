using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [System.Serializable]
    public class InventorySlot
    {
        public Item item;
        public int quantity;

        public InventorySlot(Item item, int quantity)
        {
            this.item = item;
            this.quantity = quantity;
        }
    }

    public List<InventorySlot> items = new List<InventorySlot>();

    public void AddItem(Item newItem, int amount = 1)
    {
        if (newItem.isStackable)
        {
            foreach (var slot in items)
            {
                if (slot.item == newItem)
                {
                    slot.quantity += amount;
                    return;
                }
            }
        }

        items.Add(new InventorySlot(newItem, amount));
    }

    public void RemoveItem(Item itemToRemove, int amount = 1)
    {
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].item == itemToRemove)
            {
                items[i].quantity -= amount;
                if (items[i].quantity <= 0)
                    items.RemoveAt(i);
                return;
            }
        }
    }

    public bool HasItem(Item item)
    {
        foreach (var slot in items)
        {
            if (slot.item == item)
                return true;
        }
        return false;
    }
}
