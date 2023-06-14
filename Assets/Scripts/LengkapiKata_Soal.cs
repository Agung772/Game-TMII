using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LengkapiKata_Soal : MonoBehaviour
{
    [System.Serializable]public struct Soal
    {
        public string soal;
        public string jawaban;
        public Sprite ilustrasi;
    }

    public Soal[] soalList;
}
