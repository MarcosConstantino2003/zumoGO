using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{

    public GameObject[] itemsInBox;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void openBox()
    {
        print("OPENN");
        GetComponent<Animator>().SetTrigger("Opens");
        foreach (GameObject item in itemsInBox)
        {
            item.SetActive(true);
        }
    }
}
