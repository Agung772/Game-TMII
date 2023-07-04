using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlusMinus_Soal : MonoBehaviour
{
    public enum OperatorAritmatik
    {
        Tambah,
        Kurang,
        Kali,
        Bagi
    }
    [System.Serializable]
    public struct SoalList
    {
        public int soal1;
        public int soal2;
        public OperatorAritmatik operatorAritmatik;
    }

    public SoalList[] soalList;
}
