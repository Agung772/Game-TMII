using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarisBilangan_Soal : MonoBehaviour
{
    [System.Serializable]
    public struct Soal
    {
        public string soal;
        public int nomorAwal;
        public int nomorBenar;
    }

    public Soal[] soalList;
}
