using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PilihPulauUI : MonoBehaviour
{
    [SerializeField]
    GameObject popupUI;
    [SerializeField]
    TextMeshProUGUI popupText;

    bool oneClick;
    public void SetPulau(string namaPulau)
    {
        if (oneClick) return;
        oneClick = true;

        var dataGame = DataGame.instance;

        if (namaPulau == "Sulawesi")
        {
            dataGame.SavePulau("Sulawesi");
            UIManager.instance.PindahScene("Sulawesi");
        }
        else if (namaPulau == "Kalimantan")
        {
            dataGame.SavePulau("Kalimantan");
            UIManager.instance.PindahScene("Kalimantan");
        }
        else if (namaPulau == "Jawa")
        {
            dataGame.SavePulau("Jawa");
            UIManager.instance.PindahScene("Jawa");
        }
        else if (namaPulau == "Sumatera")
        {
            dataGame.SavePulau("Sumatera");
            UIManager.instance.PindahScene("Sumatera");
        }
        else if (namaPulau == "Papua")
        {
            dataGame.SavePulau("Papua");
            UIManager.instance.PindahScene("Papua");
        }
    }


    string namaPulauTemp;
    public void SetPopupPindahPulau()
    {
        SetPulau(namaPulauTemp);
    }

    public void SetPopup(string namaPulau)
    {
        namaPulauTemp = namaPulau;

        popupUI.SetActive(true);
        popupText.text = "Yakin ingin pergi menuju Pulau " + namaPulauTemp + "?";
    }

    bool pilihPulau;
    public void SetPilihPulauUI()
    {
        if (!pilihPulau)
        {
            gameObject.SetActive(true);
            pilihPulau = true;
        }
        else
        {
            gameObject.SetActive(false);
            pilihPulau = false;
        }
    }
}
