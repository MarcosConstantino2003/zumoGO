using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactBush : MonoBehaviour
{
    public bool harvested = false;
    public Sprite noBerry;
    public Inventory inv;
    public Item item;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && !harvested && transform.GetChild(0).GetComponent<NearFrog>().isNear)
        {
            harvested = true;
            this.GetComponent<SpriteRenderer>().sprite = noBerry;
            inv.AddItem(item, 1);
            Debug.Log("Picked up " + 1 + " x " + item.itemName);
        }

    }
}
