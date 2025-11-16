using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzles : MonoBehaviour
{
    public GameObject waterfall;
    public GameObject fire;
    public Inventory inv;
    public Item frutilla;
    public Item frutillaQ;
    public GameObject[] boxes;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void checkEffect(string words)
    {
        if (words=="mizu" && waterfall.transform.GetChild(0).GetComponent<Near>().isNear )
            Destroy(waterfall);

        if (words == "kaji" && fire.transform.GetChild(0).GetComponent<Near>().isNear && inv.hasItem(frutilla))
        {
            fire.transform.localScale *= 2;
            Debug.Log("Consumo " + frutilla.itemName + " y doy  " + frutillaQ.itemName);
            inv.remove(frutilla);
            inv.AddItem(frutillaQ,1);
        }
            

        if(words == "hakowoakeru")
        {
            foreach(GameObject box in boxes)
            {
                if (box.transform.GetChild(0).GetComponent<Near>().isNear)
                {
                    box.GetComponent<Box>().openBox();
                }
            }
        }
    }
}
