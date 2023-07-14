using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jam_Soal : MonoBehaviour
{
    [System.Serializable]
    public struct Soal
    {
        public int jamRight;
        public int menitRight;
        [Space]
        public int jamLeft;
        public int menitLeft;
        [Space]
        public int jawabJam;
        public int jawabMenit;
    }

    public Soal[] soalList;
}
