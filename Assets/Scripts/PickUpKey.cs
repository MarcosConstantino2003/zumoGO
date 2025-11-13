using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpKey : MonoBehaviour
{
   
   
    public GameObject keyboard;
    public string kana;
    

    public float posX;
    public float posY;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("PickupItem triggered by: " + collision.name);
            KeyboardUI keyScript = keyboard.GetComponent<KeyboardUI>();
            keyScript.addNewKey(posX, posY,kana);
            Destroy(gameObject);
            //Inventory inv = collision.GetComponentInParent<Inventory>();
            // if (inv)
            //{
            //    inv.AddItem(item, quantity);
            //    Debug.Log("Picked up " + quantity + " x " + item.itemName);
            //    Destroy(gameObject);
            //}
        }
    }
}
