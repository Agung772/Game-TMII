using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BarisBilangan_Tempat : MonoBehaviour
{
    public TextMeshProUGUI nomorTempatText;
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
