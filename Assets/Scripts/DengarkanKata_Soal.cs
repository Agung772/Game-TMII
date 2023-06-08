using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DengarkanKata_Soal : MonoBehaviour
{
    [System.Serializable] public struct Soal
    {
        public AudioClip audioSoal;
        public string jawaban;
    }

    public List<Soal> soalList;
}
