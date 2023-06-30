using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bilangan_Gameplay : MonoBehaviour
{
    public static Bilangan_Gameplay instance;

    [SerializeField] float waktu;
    float o_waktu;

    [SerializeField] Bilangan_Soal[] tugu;
    Bilangan_Soal soal;

    public int soalIndex;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        for (int i = 0; i < tugu[1].transform.parent.childCount; i++)
        {
            tugu[1].transform.parent.GetChild(i).gameObject.SetActive(false);
        }

        //Start
        if (DataGame.instance.pulau == DataGame.instance._Sumatera)
        {
            soal = tugu[(int)DataGame.instance.codeTugu];
        }

        soal.gameObject.SetActive(true);
        soalIndex++;

        o_waktu = waktu;
    }
}
