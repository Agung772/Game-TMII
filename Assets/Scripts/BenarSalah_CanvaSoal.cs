using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class BenarSalah_CanvaSoal : MonoBehaviour
{
    public TextMeshProUGUI soalText;
    public bool benar;

    public void InputJawaban(bool value)
    {
        if (value == benar)
        {
            //Jawaban benar
            BenarSalah_Gameplay.instance.JawabanBenar();
        }
        else
        {
            //Jawaban salah
            BenarSalah_Gameplay.instance.JawabanSalah();
        }
    }
}
