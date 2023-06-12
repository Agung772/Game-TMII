using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Perbandingan_UI : MonoBehaviour
{
    public static Perbandingan_UI instance;

    public TextMeshProUGUI jumlahSoalText;

    public TextMeshProUGUI bendaKananText;
    public TextMeshProUGUI bendaKiriText;
    private void Awake()
    {
        instance = this;
    }
}
