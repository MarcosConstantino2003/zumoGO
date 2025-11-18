using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog : MonoBehaviour
{
    public bool fed = false;
    public Sprite noBerry;
    public Inventory inv;
    public Item cookedBerry;
    public GameObject FtoInt;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        bool readyToInteract = !fed && inv.hasItem(cookedBerry) &&  transform.GetChild(0).GetComponent<NearFrog>().isNear;

        if(readyToInteract)
        {
            FtoInt.SetActive(true);
        }
        else
        {
            FtoInt.SetActive(false);
        }

        if (readyToInteract && Input.GetKeyDown(KeyCode.F))
        {
            //destroys object
            GetComponent<Animator>().SetTrigger("disapear");
            GetComponent<Collider2D>().enabled = false;
            inv.remove(cookedBerry);
            fed = true;

        }

    }
}
