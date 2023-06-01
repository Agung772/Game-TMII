using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewgameUI : MonoBehaviour
{
    [SerializeField]
    string 
        nama, 
        karakter;

    private void Start()
    {

    }

    //bool oneClick = false;

    public void namaInput(string value)
    {
        nama = value;
    }


    Image cowok, cewek;
    public void CowokInput(Image image)
    {
        cowok = image;

        if (cowok != null) cowok.color = Color.green;
        if (cewek != null) cewek.color = Color.white;

        karakter = "Cowok";
    }
    public void CewekInput(Image image)
    {
        cewek = image;

        if (cowok != null) cowok.color = Color.white;
        if (cewek != null) cewek.color = Color.green;

        karakter = "Cewek";
    }

    public void SaveProfil()
    {
        if (nama != "" && karakter != "")
        {
            DataGame.instance.DeletaData();
            DataGame.instance.SaveProfil(nama, karakter);
            UIManager.instance.PindahScene("PilihPulau");
        }
        else if (nama == "" && karakter == "")
        {
            UIManager.instance.SpawnNotif("Isi terlebih dahulu nama dan pilih karakter kamu");
        }
        else if (nama == "" && karakter != "")
        {
            UIManager.instance.SpawnNotif("Isi terlebih dahulu nama kamu");
        }
        else if (nama != "" && karakter == "")
        {
            UIManager.instance.SpawnNotif("Pilih terlebih dahulu karakter kamu");
        }
    }
}
