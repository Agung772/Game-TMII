using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Perbandingan_TempatPerbandingan : MonoBehaviour
{
    public static Perbandingan_TempatPerbandingan instance;
    public enum JenisPerbandingan
    {
        Null,
        LebihBesar,
        SamaDengan,
        LebihKecil
    }

    public JenisPerbandingan perbandingan;
    private void Awake()
    {
        instance = this;
    }
}
