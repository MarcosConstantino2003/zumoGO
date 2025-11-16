using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NearHouse : MonoBehaviour
{
    private bool isNear = false;
    private GameObject house; 
    
    void Start()
    {
        house = transform.parent.gameObject;
    }
    
    void Update()
    {
        if (isNear && Input.GetKeyDown(KeyCode.F))
        {
            house.SetActive(false);
        }
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