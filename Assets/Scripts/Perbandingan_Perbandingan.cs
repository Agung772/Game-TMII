using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Perbandingan_Perbandingan : MonoBehaviour
{
    public enum JenisPerbandingan
    {
        LebihBesar,
        SamaDengan,
        LebihKecil
    }

    public JenisPerbandingan jenisPerbandingan;
    public bool click;
    public bool tempatPerbandingan;

    RectTransform tempatPerbandinganRT;
    Vector3 posisiAwal;

    private void Awake()
    {
        posisiAwal = GetComponent<RectTransform>().position;
        tempatPerbandinganRT = Perbandingan_TempatPerbandingan.instance.GetComponent<RectTransform>();
    }

    private void Update()
    {
        if (click)
        {
            GetComponent<RectTransform>().position = Input.mousePosition;
        }

        if (Vector3.Distance(GetComponent<RectTransform>().position, tempatPerbandinganRT.position) < 100)
        {
            tempatPerbandingan = true;
        }
        else
        {
            tempatPerbandingan = false;
        }
    }
    public void Click(bool value)
    {
        var tempatPerbandinganSC = Perbandingan_TempatPerbandingan.instance;

        if (value)
        {
            click = true;

            if (tempatPerbandingan && tempatPerbandinganSC.perbandingan != Perbandingan_TempatPerbandingan.JenisPerbandingan.Null)
            {
                tempatPerbandinganSC.perbandingan = Perbandingan_TempatPerbandingan.JenisPerbandingan.Null;
            }
        }
        else
        {
            click = false;
            if (tempatPerbandingan && tempatPerbandinganSC.perbandingan == Perbandingan_TempatPerbandingan.JenisPerbandingan.Null)
            {
                //Setposisi
                GetComponent<RectTransform>().position = tempatPerbandinganRT.position;

                //Kondisi
                if (jenisPerbandingan == JenisPerbandingan.LebihBesar)
                {
                    tempatPerbandinganSC.perbandingan = Perbandingan_TempatPerbandingan.JenisPerbandingan.LebihBesar;
                }
                else if (jenisPerbandingan == JenisPerbandingan.SamaDengan)
                {
                    tempatPerbandinganSC.perbandingan = Perbandingan_TempatPerbandingan.JenisPerbandingan.SamaDengan;
                }
                else if (jenisPerbandingan == JenisPerbandingan.LebihKecil)
                {
                    tempatPerbandinganSC.perbandingan = Perbandingan_TempatPerbandingan.JenisPerbandingan.LebihKecil;
                }

                //Check
                Perbandingan_Gameplay.instance.CheckHasil();
            }
            else
            {
                GetComponent<RectTransform>().position = posisiAwal;
            }
        }

    }

    public void ResetPerbandingan()
    {
        var tempatPerbandinganSC = Perbandingan_TempatPerbandingan.instance;
        tempatPerbandinganSC.perbandingan = Perbandingan_TempatPerbandingan.JenisPerbandingan.Null;
        GetComponent<RectTransform>().position = posisiAwal;
        tempatPerbandingan = false;
    }
}
