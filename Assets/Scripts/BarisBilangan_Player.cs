using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarisBilangan_Player : MonoBehaviour
{
    public static BarisBilangan_Player instance;

    public int nomor;
    public int posisiContent;
    public int posisiPlayer;
    public int maxPosPlayer;
    
    float distance;

    [SerializeField] Transform design2D;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        UpdatePosisiPlayer();
    }

    public void RightButton()
    {
        if (posisiPlayer == maxPosPlayer)
        {
            if (posisiContent < BarisBilangan_UI.instance.content.transform.childCount - 4)
            {
                posisiContent++;
            }
            else
            {
                posisiPlayer++;
            }

        }

        if (posisiPlayer < maxPosPlayer)
        {
            posisiPlayer++;
        }

        if (nomor < BarisBilangan_UI.instance.content.transform.childCount -1)
        {
            nomor++;
        }

        design2D.localEulerAngles = Vector2.zero;
        UpdatePosisiTempat();
    }
    public void LeftButton()
    {
        if (posisiPlayer == -maxPosPlayer)
        {
            if (posisiContent > 4)
            {
                posisiContent--;
            }
            else
            {
                posisiPlayer--;
            }

        }

        if (posisiPlayer > -maxPosPlayer)
        {
            posisiPlayer--;
        }

        if (nomor > 1)
        {
            nomor--;
        }
        design2D.localEulerAngles = Vector2.down * 180;
        UpdatePosisiTempat();
    }
    void UpdatePosisiPlayer()
    {
        RectTransform rectTransform = GetComponent<RectTransform>();
        rectTransform.localPosition = Vector3.Lerp(rectTransform.localPosition, new Vector2(posisiPlayer * distance, rectTransform.localPosition.y), 10 * Time.deltaTime);
    }


    public void UpdatePosisiTempat()
    {
        var content = BarisBilangan_UI.instance.content;

        distance = content.GetComponent<GridLayoutGroup>().spacing.x + content.GetComponent<GridLayoutGroup>().cellSize.x;

        content.GetComponent<RectTransform>().localPosition = new Vector2((-posisiContent + 15) * distance, content.transform.GetComponent<RectTransform>().localPosition.y);


        BarisBilangan_Gameplay.instance.SetTempat(nomor);
    }
}
