using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class viewPanel : MonoBehaviour
{

    private float cellSize;
    private float spacing;
    private RectTransform rect;

    // Start is called before the first frame update
    void Start()
    {
        cellSize = GetComponent<GridLayoutGroup>().cellSize.x;
        spacing = GetComponent<GridLayoutGroup>().spacing.x;
        rect = GetComponent<RectTransform>();
    }

    public void RefreshSize(int delete)
    {
        
        int count = transform.childCount;
        print(count);
        if (delete == 0)
        {
            GetComponent<Image>().enabled = false;
        }
        else GetComponent<Image>().enabled = true;

        float width = (cellSize * count) +
                      (spacing * Mathf.Max(0, count - 1));

        rect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, width);
    }
}
