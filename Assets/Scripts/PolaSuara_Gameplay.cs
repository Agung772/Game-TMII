using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PolaSuara_Gameplay : MonoBehaviour
{
    [System.Serializable] struct Soal
    {
        public int[] urutan;
    }

    [SerializeField] int soalIndex;
    [SerializeField] int totalBell;
    [SerializeField] Soal[] soal;


    public GameObject bellParent;
    [SerializeField] PolaSuara_Bell[] bell;

    private void Start()
    {
        if (DataGame.instance.pulau == DataGame.instance._Sumatera)
        {
            bellParent = PolaSuara_UI.instance.bellSumatera;
        }

        totalBell = bellParent.transform.childCount;
        bell = new PolaSuara_Bell[totalBell + 1];
        for (int i = 0; i < totalBell + 1; i++)
        {
            if (i != 0)
            {
                bell[i] = bellParent.transform.GetChild(i - 1).GetComponent<PolaSuara_Bell>();
            }
        }
    }

    public bool cd;
    private void Update()
    {
        if (cd)
        {
            cd = false;
            StartSoal();
        }
    }
    public int totalBunyi;
    public int urutanBunyi;
    public void StartSoal()
    {
        StartCoroutine(Coroutine());
        IEnumerator Coroutine()
        {
            CekBell(true);
            soalIndex++;
            yield return new WaitForSeconds(1);
            CekBell(false);
        }




        void PlayBell()
        {
            for (int i = 0; i < soal[soalIndex].urutan.Length; i++)
            {

            }
        }
        void CekBell(bool value)
        {
            for (int i = 0; i < totalBell + 1; i++)
            {
                if (i != 0)
                {
                    bell[i].check = value;
                }

            }
        }
    }

    public void CheckBell()
    {

    }
}
