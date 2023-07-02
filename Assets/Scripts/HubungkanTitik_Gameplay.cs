using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HubungkanTitik_Gameplay : MonoBehaviour
{
    public static HubungkanTitik_Gameplay instance;

    public int nyawa;
    public int benar;

    public int soalIndex;

    [SerializeField] GameObject[] tugus;
    public GameObject tugu;

    public GameObject[] soals;
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        for (int i = 0; i < tugus[1].transform.parent.childCount; i++)
        {
            tugus[1].transform.parent.GetChild(i).gameObject.SetActive(false);
        }



        //Start
        if (DataGame.instance.pulau == DataGame.instance._Sumatera)
        {
            tugu = tugus[(int)DataGame.instance.codeTugu];
        }

        tugu.gameObject.SetActive(true);

        HubungkanTitik_UI.instance.SetNyawa(nyawa);
        HubungkanTitik_UI.instance.soalText.text = soalIndex + "/5";

        //Set soall
        NextSoal();
    }

    public void DotBenar()
    {
        benar++;
        if (tugu.transform.GetChild(0).GetChild(0).childCount == benar)
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

    void NextSoal()
    {
        soalIndex++;
        HubungkanTitik_UI.instance.soalText.text = soalIndex + "/5";

        benar = 0;

        soals = new GameObject[tugu.transform.childCount];
        for (int i = 0; i < soals.Length; i++)
        {
            soals[i] = tugu.transform.GetChild(i).gameObject;
            soals[i].gameObject.SetActive(false);
        }

        soals[soalIndex - 1].SetActive(true);
    }
}
