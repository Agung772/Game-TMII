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
    [SerializeField] int nyawa, totalSoal;

    [Space]
    [SerializeField] int soalIndex;
    [SerializeField] int totalBell;

    PolaSuara_Soal soal;
    public GameObject bellParent;

    [SerializeField] PolaSuara_Bell[] bell;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        for (int i = 0; i < PolaSuara_UI.instance.tuguSoal[1].transform.parent.childCount; i++)
        {
            PolaSuara_UI.instance.tuguSoal[1].transform.parent.GetChild(i).gameObject.SetActive(false);
        }
        for (int i = 0; i < PolaSuara_UI.instance.tuguBell[1].transform.parent.childCount; i++)
        {
            PolaSuara_UI.instance.tuguBell[1].transform.parent.GetChild(i).gameObject.SetActive(false);
        }

        PolaSuara_UI.instance.notifText.text = "TEKAN PUTAR SUARA UNTUK MENDENGARKAN MELODI";

        if (DataGame.instance.pulau == DataGame.instance._Sumatera)
        {
            soal = PolaSuara_UI.instance.tuguSoal[(int)DataGame.instance.codeTugu];
            bellParent = PolaSuara_UI.instance.tuguBell[(int)DataGame.instance.codeTugu];
        }
        else
        {
            //null
            soal = PolaSuara_UI.instance.tuguSoal[(int)DataGame.instance.codeTugu];
            bellParent = PolaSuara_UI.instance.tuguBell[(int)DataGame.instance.codeTugu];
        }

        soal.gameObject.SetActive(true);
        bellParent.SetActive(true);

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
        PolaSuara_UI.instance.SetNyawa(nyawa);
        NonClickBell(true);
    }
    
    public int totalBunyi;
    public int urutanBunyi;
    public void StartSoal()
    {
        if (soalIndex == totalSoal + 1)
        {
            Minigame_UI.instance.ScoreUI(DataGame.instance.minigame._PolaSuara, nyawa);
        }
        else
        {
            StartCoroutine(Coroutine());
            IEnumerator Coroutine()
            {
                PolaSuara_UI.instance.putarSuaraButton.gameObject.SetActive(false);

                urutanBunyi = 0;
                urutanCheck = 0;
                totalBunyi = soal.soalList[soalIndex].urutan.Length;
                totalCheck = soal.soalList[soalIndex].urutan.Length;

                PlayBell();

                PutarSuara(true);
                PolaSuara_UI.instance.notifText.text = "DENGARKAN MELODI";
                yield return new WaitForSeconds(soalIndex * 2);
                PutarSuara(false);
                NonClickBell(false);
                PolaSuara_UI.instance.notifText.text = "TEKAN MELODI SESUAI DENGAN CLUE ";
            }

            void PlayBell()
            {
                bell[soal.soalList[soalIndex].urutan[urutanBunyi]].StartBell();

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

        }

    }
    void PutarSuara(bool value)
    {
        for (int i = 0; i < totalBell + 1; i++)
        {
            if (i != 0)
            {
                bell[i].putarSuara = value;
            }

        }
    }
    void NonClickBell(bool value)
    {
        for (int i = 0; i < totalBell + 1; i++)
        {
            if (i != 0)
            {
                bell[i].nonClick = value;
            }

        }
    }

    int urutanCheck;
    int totalCheck;

    int totalSalah;
    public void CheckBell(int codeBell)
    {
        if (totalCheck > 0)
        {
            print("soalIndex " + soalIndex + " urutanCheck " + urutanCheck);
            if (codeBell == soal.soalList[soalIndex].urutan[urutanCheck])
            {
                urutanCheck++;
                totalCheck--;

                PolaSuara_UI.instance.notifText.text = "TEKAN " + totalCheck + " MELODI LAGI";
                if (totalCheck == 0)
                {
                    print("Bell benar");

                    //Update UI
                    soalIndex++;

                    //Semua soal terjawab
                    if (soalIndex == totalSoal + 1)
                    {
                        StartCoroutine(Coroutine());
                        IEnumerator Coroutine()
                        {
                            PolaSuara_UI.instance.notifText.text = "KAMU BENAR, SEMUA SOAL TELAH DIJAWAB";
                            yield return new WaitForSeconds(3);
                            Minigame_UI.instance.ScoreUI(DataGame.instance.minigame._PolaSuara, nyawa);
                        }
                    }
                    //Lanjut soal berikutnnya
                    else
                    {
                        PolaSuara_UI.instance.soalText.text = "0" + soalIndex;
                        PolaSuara_UI.instance.putarSuaraButton.gameObject.SetActive(true);
                        PolaSuara_UI.instance.notifText.text = "KAMU BENAR, PUTAR SUARA UNTUK SOAL SELANJUTNYA";
                        NonClickBell(true);
                    }
                }

            }
            else
            {
                urutanCheck = 0;
                totalCheck = soal.soalList[soalIndex].urutan.Length;
                totalSalah++;
                print("Bell salah");
                if (totalSalah == 1)
                {
                    PolaSuara_UI.instance.notifText.text = "MELODI YANG KAMU TEKAN SALAH, TEKAN ULANG MELODI DARI AWAL";
                }
                else
                {
                    PolaSuara_UI.instance.notifText.text = "MELODI YANG KAMU TEKAN MASIH SALAH, KAMU UDAH SALAH " + totalSalah + " KALI";
                }


                nyawa--;
                PolaSuara_UI.instance.SetNyawa(nyawa);
                if (nyawa == 0)
                {
                    StartCoroutine(Coroutine());
                    IEnumerator Coroutine()
                    {
                        yield return new WaitForSeconds(3);
                        Minigame_UI.instance.ScoreUI(DataGame.instance.minigame._PolaSuara, 0);
                    }

                }
            }
        }
    }
}
