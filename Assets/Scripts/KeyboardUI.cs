using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyboardUI : MonoBehaviour
{

    public GameObject keyboardPanel;
    public GameObject key;
    public GameObject DelKey;
    public GameObject Enter;
    public GameObject ze;
    public Transform itemContainer;
    public Transform viewPanel;
    public viewPanel panelScript;
    public string words;

    private float keyWidth;
    private float keyHeight;
    private float offset = 10;

    private bool isOpen = false;
    public bool isAquired = false;

    public Puzzles puzzle;
    // Start is called before the first frame update
    void Start()
    {
        keyboardPanel.SetActive(isOpen);
        keyWidth = DelKey.transform.GetChild(0).GetComponent<RectTransform>().rect.width;
        keyHeight = DelKey.transform.GetChild(0).GetComponent<RectTransform>().rect.height-6;
        RectTransform rt = keyboardPanel.GetComponent<RectTransform>();
        rt.sizeDelta = new Vector2(keyWidth * 9 + 8, keyHeight * 5 + 27);



        Navigation nav = new Navigation();
        nav.mode = Navigation.Mode.None;
        
        DelKey.transform.localPosition = new Vector2(keyWidth*4, keyHeight*(2)+offset);
        Button b = DelKey.transform.GetChild(0).GetComponent<Button>();
        b.onClick.AddListener(delegate { delKeyPressed(); });
        b.navigation = nav;
        Enter.transform.localPosition = new Vector2(keyWidth * 4, keyHeight * (-1) + offset);
        Button b1 = Enter.transform.GetChild(0).GetComponent<Button>();
        b1.onClick.AddListener(delegate { enterPressed(); });
        b1.navigation = nav;
        ze.transform.localPosition = new Vector2(keyWidth , keyHeight * (-1) + offset);
        Button b2 = ze.transform.GetChild(0).GetComponent<Button>();
        b2.onClick.AddListener(delegate { keyPressed(ze); });
        b2.navigation = nav;
        Key k = ze.GetComponent<Key>();
        k.KeyCode = "ze";
    }

    // Update is called once per frame
    void Update()
    {
        if (isAquired && Input.GetKeyDown(KeyCode.Q))
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
        newKey.transform.localPosition = new Vector2(posX * keyWidth, posY * keyHeight+ offset);

        Image img = newKey.transform.GetChild(0).GetComponent<Image>();
        img.sprite = Resources.Load<Sprite>($"keys/key-{kana}");


        Button b = newKey.transform.GetChild(0).GetComponent<Button>();
        b.onClick.AddListener(delegate { keyPressed(newKey); });
        Sprite pressed = Resources.Load<Sprite>($"keys/key-{kana}-pressed");

       
        var ss = b.spriteState;
        ss.pressedSprite = pressed;
        b.spriteState = ss;

        Navigation nav = new Navigation();
        nav.mode = Navigation.Mode.None;
        b.navigation = nav;

    }
    public void keyPressed(GameObject keyp)
    {
        string kana = keyp.GetComponent<Key>().KeyCode;
        print(kana);
        words += kana;
        GameObject imgObj = new GameObject("KanaImage");
        imgObj.transform.SetParent(viewPanel, false);
        Image img = imgObj.AddComponent<Image>();
        img.sprite = Resources.Load<Sprite>($"Kana/kana-{kana}");
        panelScript.RefreshSize(1);


    }

    public void delKeyPressed()
    {
        words = "";

        foreach (Transform child in viewPanel)
            Destroy(child.gameObject);
        panelScript.RefreshSize(0);
    }

    public void enterPressed()
    {
        
        foreach (Transform child in viewPanel)
            Destroy(child.gameObject);
        panelScript.RefreshSize(0);
        print(words);
        puzzle.checkEffect(words);
        words = "";
    }
}
