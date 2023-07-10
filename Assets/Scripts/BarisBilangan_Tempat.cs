using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BarisBilangan_Tempat : MonoBehaviour
{
    public TextMeshProUGUI nomorTempatText;

    public GameObject delayParent;
    public Image delayImage;

    private void OnValidate()
    {
        string nomorTempat = "";

        for (int i = 0; i < name.Length; i++)
        {
            if (Char.IsDigit(name[i]))
                nomorTempat += name[i];
        }

        nomorTempatText.text = nomorTempat;
    }
}
