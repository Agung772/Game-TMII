using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PolaSuara_Gameplay : MonoBehaviour
{
    public static PolaSuara_Gameplay instance;
    [System.Serializable] struct Soal
    {
        public int[] urutan;
    }
    [SerializeField] int nyawa;

    [Space]
    [SerializeField] int soalIndex;
    [SerializeField] int totalBell;
    [SerializeField] Soal[] soal;


    public GameObject bellParent;
    [SerializeField] PolaSuara_Bell[] bell;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        PolaSuara_UI.instance.notifText.text = "TEKAN PUTAR SUARA UNTUK MENDENGARKAN MELODI";

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

        soalIndex++;
        PolaSuara_UI.instance.soalText.text = "0" + soalIndex;
    }
    
    public int totalBunyi;
    public int urutanBunyi;
    public void StartSoal()
    {
        StartCoroutine(Coroutine());
        IEnumerator Coroutine()
        {
            PolaSuara_UI.instance.putarSuaraButton.gameObject.SetActive(false);

            urutanBunyi = 0;
            urutanCheck = 0;
            totalBunyi = soal[soalIndex].urutan.Length;
            totalCheck = soal[soalIndex].urutan.Length;

            PlayBell();

            CekBell(true);
            yield return new WaitForSeconds(soalIndex * 2);
            CekBell(false);
        }

        void PlayBell()
        {
            bell[soal[soalIndex].urutan[urutanBunyi]].StartBell();

            if (totalBunyi > 1)
            {
                StartCoroutine(Coroutine());
                IEnumerator Coroutine()
                {
                    yield return new WaitForSeconds(2);
                    urutanBunyi++;
                    totalBunyi--;
                    PlayBell();
                }
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

            if (value)
            {
                PolaSuara_UI.instance.notifText.text = "DENGARKAN MELODI";
            }
            else
            {
                PolaSuara_UI.instance.notifText.text = "TEKAN MELODI SESUAI DENGAN CLUE ";
            }
        }
    }

    int urutanCheck;
    int totalCheck;
    public void CheckBell(int codeBell)
    {
        if (totalCheck > 0)
        {
            print("soalIndex " + soalIndex + " urutanCheck " + urutanCheck);
            if (codeBell == soal[soalIndex].urutan[urutanCheck])
            {
                urutanCheck++;
                totalCheck--;
                if (totalCheck == 0)
                {
                    print("Bell benar");
                    PolaSuara_UI.instance.putarSuaraButton.gameObject.SetActive(true);
                    PolaSuara_UI.instance.notifText.text = "KAMU BENAR, PUTAR SUARA UNTUK SOAL SELANJUTNYA";

                    //Update UI
                    soalIndex++;
                    PolaSuara_UI.instance.soalText.text = "0" + soalIndex;
                }

            }
            else
            {
                urutanCheck = 0;
                totalCheck = soal[soalIndex].urutan.Length;
                print("Bell salah");
                PolaSuara_UI.instance.notifText.text = "MELODI YANG KAMU TEKAN SALAH, TEKAN ULANG MELODI DARI AWAL";
            }
        }
    }
}
