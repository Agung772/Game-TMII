using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Perbandingan_Gameplay : MonoBehaviour
{
    public static Perbandingan_Gameplay instance;

    public int nyawa;
    public int soalIndex;

    [SerializeField]Perbandingan_Soal[] tugu;
    public Perbandingan_Soal soal;

    [SerializeField] Perbandingan_TempatBenda tempatBendaKanan;
    [SerializeField] Perbandingan_TempatBenda tempatBendaKiri;
    [SerializeField] Perbandingan_TempatPerbandingan tempatPerbandingan;
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        for (int i = 0; i < tugu.Length; i++)
        {
            tugu[i].gameObject.SetActive(false);
        }
        //Start
        if (DataGame.instance.pulau == DataGame.instance._Sumatera)
        {
            soal = tugu[(int)DataGame.instance.codeTugu];
        }


        Perbandingan_UI.instance.SetNyawa(nyawa);
        Perbandingan_UI.instance.screenText.text = "Letakkan buah";

        Perbandingan(false);
        StartSoal();
    }

    void StartSoal()
    {
        if (soalIndex == soal.soal.Length - 1)
        {
            Minigame_UI.instance.ScoreUI(DataGame.instance.minigame._Perbandingnan, nyawa);
        }
        else
        {
            soalIndex++;

            soal.gameObject.SetActive(true);

            Perbandingan_UI.instance.jumlahSoalText.text = "0" + soalIndex;

            Perbandingan_UI.instance.bendaKananText.text = soal.soal[soalIndex].bendaKanan.ToString();
            Perbandingan_UI.instance.bendaKiriText.text = soal.soal[soalIndex].bendaKiri.ToString();
        }

    }

    public void CheckHasil()
    {
        if (tempatBendaKanan.jumlahBenda == soal.soal[soalIndex].bendaKanan &&
            tempatBendaKiri.jumlahBenda == soal.soal[soalIndex].bendaKiri &&
            tempatPerbandingan.perbandingan.ToString() == soal.soal[soalIndex].perbandingan.ToString())
        {
            print("Benar");



            StartCoroutine(Coroutine());
            IEnumerator Coroutine()
            {
                Minigame_UI.instance.MiniscoreUI(true);
                yield return new WaitForSeconds(1);
                Reset();
                yield return new WaitForSeconds(1);
                StartSoal();
            }
        }
        else
        {
            StartCoroutine(Coroutine());
            IEnumerator Coroutine()
            {
                nyawa--;
                Perbandingan_UI.instance.SetNyawa(nyawa);
                if (nyawa == 0)
                {
                    Minigame_UI.instance.ScoreUI(DataGame.instance.minigame._Perbandingnan, nyawa);
                }


                Minigame_UI.instance.MiniscoreUI(false);
                yield return new WaitForSeconds(1);
                Reset();
            }
        }

        void Reset()
        {
            //Reset ------------------
            Perbandingan_Benda[] tempBenda = FindObjectsOfType<Perbandingan_Benda>();
            for (int i = 0; i < tempBenda.Length; i++)
            {
                Destroy(tempBenda[i].gameObject);
            }
            tempatBendaKanan.jumlahBenda = 0;
            tempatBendaKiri.jumlahBenda = 0;

            Perbandingan_Perbandingan[] tempPerbandingan = FindObjectsOfType<Perbandingan_Perbandingan>();
            for (int i = 0; i < tempPerbandingan.Length; i++)
            {
                tempPerbandingan[i].ResetPerbandingan();
            }

            Perbandingan_UI.instance.screenText.text = "Letakkan buah";
            Perbandingan(false);
            kanan = false;
            kiri = false;
        }
    }


    bool kanan, kiri;
    public void UseBenda(bool value)
    {
        if (value)
        {
            kanan = true;
        }
        else
        {
            kiri = true;
        }

        if (kanan && kiri)
        {
            Perbandingan(true);
            Perbandingan_UI.instance.screenText.text = "Letakkan tanda perbandingan";
        }
    }

    void Perbandingan(bool value)
    {
        Perbandingan_Perbandingan[] temp = FindObjectsOfType<Perbandingan_Perbandingan>();
        for (int i = 0; i < temp.Length; i++)
        {
            temp[i].enabled = value;
        }
    }
}
