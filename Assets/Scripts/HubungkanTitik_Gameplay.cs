using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HubungkanTitik_Gameplay : MonoBehaviour
{
    public static HubungkanTitik_Gameplay instance;

    public int nyawa;
    public int benar;

    public GameObject[] tugu;
    public GameObject soal;
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
    }

    public void DotBenar()
    {
        benar++;
        if (soal.transform.GetChild(0).childCount == benar)
        {
            Minigame_UI.instance.ScoreUI(DataGame.instance.minigame._HubungkanTitik, nyawa);

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
