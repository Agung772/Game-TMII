using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlusMinus_Soal : MonoBehaviour
{
    public enum OperatorAritmatik
    {
        Tambah,
        Kurang,
        Kali
    }
    [System.Serializable]
    public struct SoalList
    {
        public string soal1;
        public string soal2;
        public OperatorAritmatik operatorAritmatik;
    }

    public SoalList[] soalList;
}
