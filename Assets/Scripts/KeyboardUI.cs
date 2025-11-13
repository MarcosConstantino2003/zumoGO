using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyboardUI : MonoBehaviour
{

    public GameObject keyboardPanel;
    public GameObject key;
    public Transform itemContainer;
    public Transform viewPanel;
    public string words;

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
    public void addNewKey(float posX, float posY,string kana)
    {
        
        GameObject newKey = Instantiate(key, itemContainer);
        Key k = newKey.GetComponent<Key>();
        k.KeyCode = kana;
        newKey.transform.localPosition = new Vector2(posX * newKey.GetComponent<RectTransform>().rect.width, posY * newKey.GetComponent<RectTransform>().rect.height);
        Button b = newKey.transform.GetChild(0).GetComponent<Button>();
        b.onClick.AddListener(delegate { keyPressed(newKey); });

    }
    public void keyPressed(GameObject keyp)
    {
        string kana = keyp.GetComponent<Key>().KeyCode;
        print(kana);
        words += kana;

        GameObject newKey = Instantiate(key, viewPanel);
        Key k = newKey.GetComponent<Key>();
        k.KeyCode = kana;
    }
}
