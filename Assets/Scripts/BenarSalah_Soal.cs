using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BenarSalah_Soal : MonoBehaviour
{
    [System.Serializable]
    public struct Soal
    {
        public string soal;
        public bool benar;
    }

    public Soal[] soalList;
}
