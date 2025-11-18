using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Inventory : MonoBehaviour
{
    [Serializable]
    public class InventorySlot
    {
        public Item item;
        public int quantity;
    }
    public AudioSource itemPickupSound;
    public int columns = 0;
    public List<InventorySlot> items = new List<InventorySlot>();
    public GameObject fadeEffect;
    public float duration;

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

        if (itemPickupSound != null)
        {
            itemPickupSound.Play();
        }

        OnInventoryChanged?.Invoke();
    }

    public bool hasItem(Item question)
    {
        foreach (InventorySlot slot in items)
        {
            if (slot.item == question)
            {
                return true;
            }
        }
        return false;
    }

    public bool remove(Item question)
    {
        bool hasToRemove = false;
        InventorySlot slotToRemove = null;
        foreach (InventorySlot slot in items)
        {
            if (slot.item == question)
            {
                if (slot.quantity > 1)
                {
                    slot.quantity -= 1;
                    return true;
                }
                    
                else
                {
                    slotToRemove = slot;
                    hasToRemove = true;
                  
                }
                break;
                    
            }
        }
        if(hasToRemove)
            items.Remove(slotToRemove);
        return hasToRemove;
    }
    //when having 3 columns, switch to victory screen.
    void Update()
    {
        if (columns >= 3)
        {
            StartCoroutine(Fader(duration));
        }
    }

     IEnumerator<string> Fader( float duration)
    {
        Image fade = fadeEffect.GetComponent<Image>();
        fadeEffect.SetActive(true);
        float t = 0;
        Color c = fade.color;
        while (t < duration)
        {
            t += Time.deltaTime;
            c.a = t / duration;
            fade.color = c;
            yield return null;
        }
        SceneManager.LoadScene(2);
    }

    public void addColumn()
    {
        columns += 1;
    }
}
