using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MetagameUI : MonoBehaviour
{
    public static MetagameUI instance;

    [SerializeField]
    TextMeshProUGUI
        namaText,
        koinText,
        namaPulauText;

    [SerializeField]
    Image iconProfil;

    [SerializeField]
    Sprite iconCowok, iconCewek;

    [Space]
    [SerializeField] NotifInteraksi notifInteraksi;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        LoadData();
    }

    public void LoadData()
    {
        var dataGame = DataGame.instance;

        namaText.text = dataGame.nama;
        koinText.text = dataGame.koin.ToString("F0");

        namaPulauText.text = dataGame.pulau;

        if (dataGame.karakter == "Cowok")
        {
            iconProfil.sprite = iconCowok;
        }
        else if (dataGame.karakter == "Cewek")
        {
            iconProfil.sprite = iconCewek;
        }
    }

    public void SetNotifInteraksi(bool set, string value)
    {
        if (set)
        {
            notifInteraksi.gameObject.SetActive(true);
            notifInteraksi.notifText.text = value;
        }
        else
        {
            notifInteraksi.gameObject.SetActive(false);
            notifInteraksi.notifText.text = value;
        }

    }
}
