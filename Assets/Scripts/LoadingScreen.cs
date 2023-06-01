using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LoadingScreen : MonoBehaviour
{
    [SerializeField]
    Sprite[] screenSprite;

    [SerializeField]
    string[] screenTitleText;
    [SerializeField]
    string[] screenBodyText;

    [SerializeField]
    Image image;
    [SerializeField]
    TextMeshProUGUI titleText;
    [SerializeField]
    TextMeshProUGUI bodyText;

    public void StartRandom()
    {
        int random = Random.Range(0, screenSprite.Length);

        image.sprite = screenSprite[random];
        titleText.text = screenTitleText[random];
        bodyText.text = screenBodyText[random];
    }
}
