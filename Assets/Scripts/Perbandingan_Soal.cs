using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Perbandingan_Soal : MonoBehaviour
{
    public enum JenisPerbandingan
    {
        LebihBesar,
        SamaDengan,
        LebihKecil
    }

    [System.Serializable]public struct Soal
    {
        public JenisPerbandingan perbandingan;
        public int bendaKiri;
        public int bendaKanan;
    }

    public Soal[] soal;
}
