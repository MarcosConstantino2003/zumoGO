using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzles : MonoBehaviour
{
    public GameObject waterfall;
    public GameObject fire;
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

        if (words == "kaji" && fire.transform.GetChild(0).GetComponent<Near>().isNear)
            fire.transform.localScale *= 2; 
    }
}
