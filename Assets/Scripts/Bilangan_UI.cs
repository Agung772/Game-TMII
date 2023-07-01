using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Bilangan_UI : MonoBehaviour
{
    public static Bilangan_UI instance;

    public TextMeshProUGUI soalText;

    public TextMeshProUGUI codeText;
    public TextMeshProUGUI petunjukText;

    public Image timeImage;

    private void Awake()
    {
        instance = this;
    }
}
