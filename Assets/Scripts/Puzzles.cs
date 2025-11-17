using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzles : MonoBehaviour
{
    public GameObject waterfall;
    public GameObject fire;
    public GameObject house;
    public Inventory inv;
    public Item frutilla;
    public Item frutillaQ;
    public GameObject[] boxes;
    public AudioSource puzzleSound;
    public AudioSource boxSound;
    public PlayerMovement player;
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
        bool solved = false;
        if (words=="mizu" && waterfall.transform.GetChild(0).GetComponent<Near>().isNear ){
                Destroy(waterfall);
                solved = true;
        }
            

        if (words == "kaji" && fire.transform.GetChild(0).GetComponent<Near>().isNear && inv.hasItem(frutilla))
        {
            fire.GetComponent<Animator>().SetTrigger("frutilla");
            Debug.Log("Consumo " + frutilla.itemName + " y doy  " + frutillaQ.itemName);
            inv.remove(frutilla);
            inv.AddItem(frutillaQ,1);
            solved = true;
        }
            

        if(words == "kaze")
        {
            foreach(GameObject box in boxes)
            {
                if (box.transform.GetChild(0).GetComponent<Near>().isNear)
                {
                    box.GetComponent<Box>().openBox();
                    boxSound.Play();
                }
            }
        }
       
       
       if (words == "ushirowoiku") 
            {
        if (house.transform.GetChild(0).GetComponent<NearHouse>().isNear)
        {
            Collider2D col = house.GetComponent<Collider2D>();
            if (col != null)
                col.enabled = false;

            SpriteRenderer sr = house.GetComponent<SpriteRenderer>();
            if (sr != null)
            {
                Color c = sr.color;
                c.a = 0.3f;
                sr.color = c;
            }

            solved = true;
        }
    }

        if(words == "kaze"){
            player.superJump = true;
            player.jumpForce = 60f;
            solved = true;
        }
        if (solved)
        {
            puzzleSound.Play();
        }
    }
}
