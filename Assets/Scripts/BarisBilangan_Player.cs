using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarisBilangan_Player : MonoBehaviour
{
    public int nomor;


    float distance;
    private void Start()
    {
        var content = BarisBilangan_UI.instance.content;
        distance = content.GetComponent<GridLayoutGroup>().spacing.x + content.GetComponent<GridLayoutGroup>().cellSize.x;

        content.GetComponent<RectTransform>().localPosition = new Vector2((-nomor + 15) * distance, content.transform.GetComponent<RectTransform>().localPosition.y);
        print(-nomor + 15);
    }
    private void Update()
    {
        
    }

    public void RightButton()
    {
        nomor++;
    }
    public void LeftButton()
    {
        nomor--;
    }


}
