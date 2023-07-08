using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BenarSalah_Gameplay : MonoBehaviour
{
    public static BenarSalah_Gameplay instance;

    public int nyawa;

    public int soalIndex;

    [SerializeField] GameObject canvaSoalTemplate;

    [SerializeField] BenarSalah_Soal[] tugu;

    BenarSalah_Soal soal;
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
        BenarSalah_UI.instance.SetNyawa(nyawa);

        canvaSoalTemplate.SetActive(false);

        StartSoal();
    }

    public void StartSoal()
    {
        soalIndex++;

        if (soalIndex == soal.soalList.Length)
        {
            Minigame_UI.instance.ScoreUI(DataGame.instance.minigame._BenarSalah, nyawa);
        }
        else
        {
            BenarSalah_UI.instance.jumlahSoalText.text = "0" + soalIndex;

            GameObject tempSoal = Instantiate(canvaSoalTemplate, transform);

            tempSoal.SetActive(true);

            var canvaSoal = tempSoal.GetComponent<BenarSalah_CanvaSoal>();

            canvaSoal.soalText.text = soal.soalList[soalIndex].soal;
            canvaSoal.benar = soal.soalList[soalIndex].benar;
        }


    }

    public void JawabanBenar()
    {
        if (soalIndex == soal.soalList.Length - 1)
        {

        }
        else
        {
            Minigame_UI.instance.MiniscoreUI(true);
        }

        StartSoal();
    }
    public void JawabanSalah()
    {
        nyawa--;
        BenarSalah_UI.instance.SetNyawa(nyawa);

        if (nyawa == 0)
        {
            Minigame_UI.instance.ScoreUI(DataGame.instance.minigame._BenarSalah, nyawa);
        }
        else
        {
            StartSoal();
            Minigame_UI.instance.MiniscoreUI(false);
        }

    }
}
