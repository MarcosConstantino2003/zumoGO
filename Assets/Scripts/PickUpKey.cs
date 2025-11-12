using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpKey : MonoBehaviour
{
   
   
    public Transform keyboard;
    public GameObject key;


    public float posX;
    public float posY;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("PickupItem triggered by: " + collision.name);
            GameObject newKey = Instantiate(key, keyboard);
            newKey.transform.localPosition = new Vector2(posX*60, posY*60);
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
