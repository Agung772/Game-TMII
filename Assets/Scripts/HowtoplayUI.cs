using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HowtoplayUI : MonoBehaviour
{
    [SerializeField]
    string[] bodyText;
    [SerializeField]
    TextMeshProUGUI text;

    [SerializeField]
    RectTransform content;

    [SerializeField]
    GameObject rightButton, leftButton;

    int halaman = 1;
    float posX;

    private void OnEnable()
    {
        halaman = 1;

        text.text = bodyText[halaman];
        ButtonCondition();

        posX = 0;
        content.anchoredPosition = new Vector2(0, 0);

    }
    private void Update()
    {
        content.anchoredPosition = Vector2.Lerp(content.anchoredPosition, new Vector2(posX, 0), 5 * Time.deltaTime);
    }

    public void RightButton()
    {
        if (halaman > bodyText.Length - 2) return;
        halaman++;
        posX -= content.GetChild(0).GetComponent<RectTransform>().rect.width + content.GetComponent<HorizontalLayoutGroup>().spacing;

        text. text = bodyText[halaman];

        ButtonCondition();
    }
    public void LeftButton()
    {
        if (halaman == 1) return;
        halaman--;
        posX += content.GetChild(0).GetComponent<RectTransform>().rect.width + content.GetComponent<HorizontalLayoutGroup>().spacing;

        text.text = bodyText[halaman];

        ButtonCondition();
    }

    void ButtonCondition()
    {
        if (halaman == 1)
        {
            rightButton.SetActive(true);
            leftButton.SetActive(false);
        }
        else if (halaman > bodyText.Length - 2)
        {
            rightButton.SetActive(false);
            leftButton.SetActive(true);
        }
        else
        {
            rightButton.SetActive(true);
            leftButton.SetActive(true);
        }
    }
}
