using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HubungkanTitik_Gameplay : MonoBehaviour
{
    public static HubungkanTitik_Gameplay instance;

    public int nyawa;
    public int benar;

    public int soalIndex;

    [SerializeField] GameObject[] tugu;
    GameObject soal;

    public GameObject[] soals;
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

        HubungkanTitik_UI.instance.SetNyawa(nyawa);

        //Set soall
        NextSoal();
    }

    void NextSoal()
    {
        soalIndex++;

        soals = new GameObject[soal.transform.GetChild(0).childCount];
        for (int i = 0; i < soals.Length; i++)
        {
            soals[i].gameObject.SetActive(false);
        }

        soals[soalIndex].SetActive(true);
    }

    public void DotBenar()
    {
        benar++;
        if (soal.transform.GetChild(0).GetChild(0).childCount == benar)
        {
            if (soalIndex == 5)
            {
                Minigame_UI.instance.ScoreUI(DataGame.instance.minigame._HubungkanTitik, nyawa);
            }
            else
            {
                NextSoal();
            }

        }
    }

    public void DotSalah()
    {
        nyawa--;
        HubungkanTitik_UI.instance.SetNyawa(nyawa);

        if (nyawa == 0)
        {
            Minigame_UI.instance.ScoreUI(DataGame.instance.minigame._HubungkanTitik, 0);
        }
    }
}
