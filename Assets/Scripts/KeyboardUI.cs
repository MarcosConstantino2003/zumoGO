using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardUI : MonoBehaviour
{

    public GameObject keyboardPanel;
    public GameObject key;
    public Transform itemContainer;

    private bool isOpen = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            ToggleKeyboard();
        }
    }

    void ToggleKeyboard()
    {
        isOpen = !isOpen;
        keyboardPanel.SetActive(isOpen);

        
    }
    public void addNewKey(float posX, float posY)
    {
        
        GameObject newKey = Instantiate(key, itemContainer);
        newKey.transform.localPosition = new Vector2(posX * newKey.GetComponent<RectTransform>().rect.width, posY * newKey.GetComponent<RectTransform>().rect.height);
        
    }
    public void keyPressed(GameObject key)
    {
    }
}
