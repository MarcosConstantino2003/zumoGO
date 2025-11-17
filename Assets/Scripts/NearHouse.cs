using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NearHouse : MonoBehaviour
{
    public bool isNear = false;
    private GameObject house; 
    
    void Start()
    {
        house = transform.parent.gameObject;
    }
    
    void Update()
    {

    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isNear = true;
        }
        
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isNear = false;
        }
    }
    }
}