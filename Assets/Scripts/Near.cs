using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Near : MonoBehaviour
{
    public bool isNear = false;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            isNear = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            isNear = false;
    }
}
