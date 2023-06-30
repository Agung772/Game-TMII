using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bilangan_Soal : MonoBehaviour
{
    [System.Serializable]
    public struct SoalList
    {
        public int angka;
        public string dibaca;
    }

    public SoalList[] soalList;
}
