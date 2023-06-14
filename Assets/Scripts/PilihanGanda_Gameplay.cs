using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PilihanGanda_Gameplay : MonoBehaviour
{
    public static PilihanGanda_Gameplay instance;

    public int nyawa;

    public int soalIndex;

    [SerializeField] GameObject canvaSoalTemplate;

    [SerializeField] PilihanGanda_Soal[] tugu;

    PilihanGanda_Soal soal;
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
        PilihanGanda_UI.instance.SetNyawa(nyawa);

        canvaSoalTemplate.SetActive(false);

        StartSoal();
    }

    public void StartSoal()
    {
        soalIndex++;

        if (soalIndex == soal.soalList.Length - 1)
        {
            Minigame_UI.instance.ScoreUI(DataGame.instance.minigame._PilihanGanda, nyawa);
        }
        else
        {
            PilihanGanda_UI.instance.jumlahSoalText.text = "0" + soalIndex;

            GameObject tempSoal = Instantiate(canvaSoalTemplate, transform);

            tempSoal.SetActive(true);

            var canvaSoal = tempSoal.GetComponent<PilihanGanda_CanvaSoal>();

            canvaSoal.soalText.text = soal.soalList[soalIndex].soal;
            canvaSoal.jawabanBenar = soal.soalList[soalIndex].jawabanBenar;
            canvaSoal.jawaban1.text = soal.soalList[soalIndex].jawaban1;
            canvaSoal.jawaban2.text = soal.soalList[soalIndex].jawaban2;
            canvaSoal.jawaban3.text = soal.soalList[soalIndex].jawaban3;

            canvaSoal.RandomJawaban();
        }


    }

    public void JawabanBenar()
    {
        Minigame_UI.instance.MiniscoreUI(true);
        StartSoal();
    }
    public void JawabanSalah()
    {
        nyawa--;
        PilihanGanda_UI.instance.SetNyawa(nyawa);

        if (nyawa == 0)
        {
            Minigame_UI.instance.ScoreUI(DataGame.instance.minigame._PilihanGanda, nyawa);
        }
        else
        {
            Minigame_UI.instance.MiniscoreUI(false);
        }

    }
}
