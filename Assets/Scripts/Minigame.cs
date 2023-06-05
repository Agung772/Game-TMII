using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minigame : MonoBehaviour
{
    public float score_KartuMemori;
    public float score_PolaSuara;
    public float score_DengarkanKata;
    public float score_Perbandingnan;
    public float score_LengkapiKata;
    public float score_PilihanGanda;

    [HideInInspector]
    public string
    _KartuMemori = "_KartuMemori",
    _PolaSuara = "_PolaSuara",
    _DengarkanKata = "_DengarkanKata",
    _Perbandingnan = "_Perbandingnan",
    _LengkapiKata = "_LengkapiKata",
    _PilihanGanda = "_PilihanGanda";

    public void LoadData()
    {
        score_KartuMemori = PlayerPrefs.GetFloat(_KartuMemori);
        score_PolaSuara = PlayerPrefs.GetFloat(_PolaSuara);
        score_DengarkanKata = PlayerPrefs.GetFloat(_DengarkanKata);
        score_Perbandingnan = PlayerPrefs.GetFloat(_Perbandingnan);
        score_LengkapiKata = PlayerPrefs.GetFloat(_LengkapiKata);
        score_PilihanGanda = PlayerPrefs.GetFloat(_PilihanGanda);
    }

    public void SaveMinigame(string namaMinigame, int score)
    {
        if (namaMinigame == _KartuMemori)
        {
            PlayerPrefs.SetFloat(_KartuMemori, score);
            score_KartuMemori = score;
        }
        else if (namaMinigame == _PolaSuara)
        {
            PlayerPrefs.SetFloat(_PolaSuara, score);
            score_PolaSuara = score;
        }
        else if (namaMinigame == _DengarkanKata)
        {
            PlayerPrefs.SetFloat(_DengarkanKata, score);
            score_DengarkanKata = score;
        }
        else if (namaMinigame == _Perbandingnan)
        {
            PlayerPrefs.SetFloat(_Perbandingnan, score);
            score_Perbandingnan = score;
        }
        else if (namaMinigame == _LengkapiKata)
        {
            PlayerPrefs.SetFloat(_LengkapiKata, score);
            score_LengkapiKata = score;
        }
        else if (namaMinigame == _PilihanGanda)
        {
            PlayerPrefs.SetFloat(_PilihanGanda, score);
            score_PilihanGanda = score;
        }
    }
}
