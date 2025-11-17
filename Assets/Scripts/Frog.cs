using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog : MonoBehaviour
{
    public bool fed = false;
    public Sprite noBerry;
    public Inventory inv;
    public Item cookedBerry;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && !fed && inv.hasItem(cookedBerry)  && transform.GetChild(1).GetComponent<NearFrog>().isNear)
        {
            //destroys object
            Destroy(this.gameObject);
            inv.remove(cookedBerry);
            fed = true;

        }

    }
}
