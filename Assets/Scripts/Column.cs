using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Column : MonoBehaviour
{
    public Item item;
    public Vector3 iconOffset = new Vector3(0, 1.5f, 0); 
    public float iconScale = 0.5f; 
    public Light2D columnLight; 
    public AudioSource itemUseSound;
    
    private GameObject iconObject;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("PickupItem triggered by: " + collision.name);
            Inventory inv = collision.GetComponentInParent<Inventory>();
            if (inv && item != null)
            {
                // Verificar si el jugador tiene el item antes de removerlo
                if (inv.hasItem(item))
                {
                    inv.remove(item);
                    if (itemUseSound != null)
                    {
                        itemUseSound.Play();
                    }
                    Debug.Log("Item removed from inventory: " + item.name);
                    inv.addColumn();
                    DrawItemIcon();
                    
                    ActivateLight();
                }
                else
                {
                    Debug.Log("Player doesn't have the required item: " + item.itemName);
                }
            }
        }
    }
    
  private void ActivateLight()
{
    Debug.Log("Activating column light.");
    if (columnLight != null)
    {
        columnLight.gameObject.SetActive(true);
        columnLight.enabled = true;

        Debug.Log("Light enabled: " + columnLight.enabled);
        Debug.Log("Intensity: " + columnLight.intensity);
        Debug.Log("Color: " + columnLight.color);
    }
}

    
    private void DrawItemIcon()
    {
        if (iconObject != null)
            return;
            
        iconObject = new GameObject(item.itemName + " Icon");
        iconObject.transform.position = transform.position + iconOffset;
        iconObject.transform.SetParent(transform); // Hacerlo hijo de la columna
        
        SpriteRenderer spriteRenderer = iconObject.AddComponent<SpriteRenderer>();
        spriteRenderer.sprite = item.icon;
        spriteRenderer.sortingOrder = 10; // Asegurar que se dibuje encima de otros sprites
        
        iconObject.transform.localScale = Vector3.one * iconScale;
        
        Debug.Log("Item icon drawn on top of column: " + item.itemName);
    }
}