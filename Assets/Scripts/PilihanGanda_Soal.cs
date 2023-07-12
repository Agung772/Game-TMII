using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PilihanGanda_Soal : MonoBehaviour
{
    [System.Serializable]
    public struct Soal
    {
        [TextArea(3,10)]
        public string soal;
        public int jawabanBenar;
        public string jawaban1;
        public string jawaban2;
        public string jawaban3;
    }

    public Soal[] soalList;
}
