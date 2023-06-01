using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataGame : MonoBehaviour
{
    public static DataGame instance;

    public string nama;
    public string karakter;

    public string pulau;
    public string provinsi;

    public float koin;
    public float tiket;

    public ListItem listItem;
    //
    public float fullScreen;
    public float sizeScreen;

    //Ojo typo typo masse
    string
        _DefaultData = "_DefaultData";

    //Data game
    string
        _Nama = "_Nama",
        _Karakter = "_Karakter",

        _Pulau = "_Pulau",
        _Provinsi = "_Provinsi",

        _Koin = "_Koin",
        _Tiket = "_Tiket",
        
        _Item = "_Item";
    //Data setting
    [HideInInspector]
    public string
        _FullScreen = "_FullScreen",
        _SizeScreen = "_SizeScreen";

    //Antitypo global
    [HideInInspector]
    //Pulau
    public string
        _Sulawesi = "_Sulawesi",
        _Kalimantan = "_Kalimantan",
        _Jawa = "_Jawa",
        _Sumatera = "_Sumatera",
        _Papua = "_Papua";

    private void Awake()
    {
        if (instance == null) instance = this;

        if (PlayerPrefs.GetFloat(_DefaultData) == 0)
        {
            PlayerPrefs.SetFloat(_DefaultData, 1);

            //Setting
            PlayerPrefs.SetFloat(_FullScreen, 1);
            PlayerPrefs.SetFloat(_SizeScreen, Screen.resolutions.Length);
            for (int i = 0; i < Screen.resolutions.Length; i++)
            {
                if (Screen.currentResolution.width == Screen.resolutions[i].width && Screen.currentResolution.height == Screen.resolutions[i].height)
                {
                    sizeScreen = i;
                    PlayerPrefs.SetFloat(_SizeScreen, sizeScreen);
                    print(Screen.resolutions[i].width + " x " + Screen.resolutions[i].height);
                }
            }
        }

        LoadData();
    }

    void LoadData()
    {
        nama = PlayerPrefs.GetString(_Nama);
        karakter = PlayerPrefs.GetString(_Karakter);

        pulau = PlayerPrefs.GetString(_Pulau);
        provinsi = PlayerPrefs.GetString(_Provinsi);

        koin = PlayerPrefs.GetFloat(_Koin);
        tiket = PlayerPrefs.GetFloat(_Tiket);


        listItem.itemStored = new string[listItem.itemDatas.Length];
        for (int i = 0; i < listItem.itemDatas.Length; i++)
        {
            listItem.itemStored[i] = PlayerPrefs.GetString(_Item + i);
        }

        //Setting
        fullScreen = PlayerPrefs.GetFloat(_FullScreen);
        sizeScreen = PlayerPrefs.GetFloat(_SizeScreen);


        //Ngeload data script lain
        if (TasUI.instance != null) TasUI.instance.LoadItem();
        if (MetagameUI.instance != null) MetagameUI.instance.LoadData();
        if (TokoUI.instance != null) TokoUI.instance.LoadData();


    }

    public void SaveProfil(string namaTemp, string karakterTemp)
    {
        nama = namaTemp;
        karakter = karakterTemp;

        PlayerPrefs.SetString(_Nama, nama);
        PlayerPrefs.SetString(_Karakter, karakter);
    }

    public void SavePulau(string pulauTemp)
    {
        PlayerPrefs.SetString(_Pulau, pulauTemp);
        pulau = pulauTemp;
    }

    public void AddKoin(float value)
    {
        koin += value;
        PlayerPrefs.SetFloat(_Koin, koin);

        LoadData();
    }
    public void AddTiket(float value)
    {
        tiket += value;
        PlayerPrefs.SetFloat(_Tiket, tiket);

        LoadData();
    }

    public void SaveItem(string itemTemp)
    {
        for (int i = 0; i < listItem.itemDatas.Length; i++)
        {
            if (listItem.itemStored[i] == "")
            {
                PlayerPrefs.SetString(_Item + i, itemTemp);

                LoadData();

                print(_Item + i);
                break;
            }
        }


    }
    public void DeletaData()
    {
        nama = "";
        karakter = "";

        pulau = "";
        provinsi = "";

        koin = 0;
        tiket = 0;

        PlayerPrefs.DeleteKey(_Nama);
        PlayerPrefs.DeleteKey(_Karakter);

        PlayerPrefs.DeleteKey(_Pulau);
        PlayerPrefs.DeleteKey(_Provinsi);

        PlayerPrefs.DeleteKey(_Koin);
        PlayerPrefs.DeleteKey(_Tiket);

        
    }

}
