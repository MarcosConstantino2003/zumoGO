using UnityEngine;

public class PickupItem : MonoBehaviour
{
    public Item item;
    public int quantity = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("PickupItem triggered by: " + collision.name);
            Inventory inv = collision.GetComponentInParent<Inventory>();
            if (inv)
            {
                inv.AddItem(item, quantity);
                Debug.Log("Picked up " + quantity + " x " + item.itemName);
                Destroy(gameObject);
            }
        }
    }
}
