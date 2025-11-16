using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NearFrog : MonoBehaviour
{
    public bool isNear = false;
    public GameObject dialoge;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            isNear = true;
        dialoge.SetActive(isNear);

    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            isNear = false;
        dialoge.SetActive(isNear);
    }
}
