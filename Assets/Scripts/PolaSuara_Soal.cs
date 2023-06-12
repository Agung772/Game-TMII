using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolaSuara_Soal : MonoBehaviour
{
    [System.Serializable]
    public struct Soal
    {
        public int[] urutan;
    }

    public List<Soal> soalList;
}
