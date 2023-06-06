using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PolaSuara_UI : MonoBehaviour
{
    public static PolaSuara_UI instance;

    public TextMeshProUGUI notifText;

    public GameObject bellSumatera;

    private void Awake()
    {
        instance = this;
    }
}
