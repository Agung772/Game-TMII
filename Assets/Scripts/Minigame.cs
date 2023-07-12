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
    public float score_Bilangan;
    public float score_HubungkanTitik;
    public float score_PlusMinus;
    public float score_BenarSalah;
    public float score_BarisBilangan;
    public float score_Tandabaca;

    [HideInInspector]
    public string
    _KartuMemori = "_KartuMemori",
    _PolaSuara = "_PolaSuara",
    _DengarkanKata = "_DengarkanKata",
    _Perbandingnan = "_Perbandingnan",
    _LengkapiKata = "_LengkapiKata",
    _PilihanGanda = "_PilihanGanda",
    _Bilangan = "_Bilangan",
    _HubungkanTitik = "_HubungkanTitik",
    _PlusMinus = "_PlusMinus",
    _BenarSalah = "_BenarSalah",
    _BarisBilangan = "_BarisBilangan",
    _Tandabaca = "_Tandabaca";

    public void LoadData()
    {
        score_KartuMemori = PlayerPrefs.GetFloat(_KartuMemori);
        score_PolaSuara = PlayerPrefs.GetFloat(_PolaSuara);
        score_DengarkanKata = PlayerPrefs.GetFloat(_DengarkanKata);
        score_Perbandingnan = PlayerPrefs.GetFloat(_Perbandingnan);
        score_LengkapiKata = PlayerPrefs.GetFloat(_LengkapiKata);
        score_PilihanGanda = PlayerPrefs.GetFloat(_PilihanGanda);
        score_Bilangan = PlayerPrefs.GetFloat(_Bilangan);
        score_HubungkanTitik = PlayerPrefs.GetFloat(_HubungkanTitik);
        score_PlusMinus = PlayerPrefs.GetFloat(_PlusMinus);
        score_BenarSalah = PlayerPrefs.GetFloat(_BenarSalah);
        score_BarisBilangan = PlayerPrefs.GetFloat(_BarisBilangan);
        score_Tandabaca = PlayerPrefs.GetFloat(_Tandabaca);
    }

    public void SaveMinigame(string namaMinigame, int score)
    {
        if (namaMinigame == _KartuMemori && score > score_KartuMemori)
        {
            PlayerPrefs.SetFloat(_KartuMemori, score);
            score_KartuMemori = score;
        }
        else if (namaMinigame == _PolaSuara && score > score_PolaSuara)
        {
            PlayerPrefs.SetFloat(_PolaSuara, score);
            score_PolaSuara = score;
        }
        else if (namaMinigame == _DengarkanKata && score > score_DengarkanKata)
        {
            PlayerPrefs.SetFloat(_DengarkanKata, score);
            score_DengarkanKata = score;
        }
        else if (namaMinigame == _Perbandingnan && score > score_Perbandingnan)
        {
            PlayerPrefs.SetFloat(_Perbandingnan, score);
            score_Perbandingnan = score;
        }
        else if (namaMinigame == _LengkapiKata && score > score_LengkapiKata)
        {
            PlayerPrefs.SetFloat(_LengkapiKata, score);
            score_LengkapiKata = score;
        }
        else if (namaMinigame == _PilihanGanda && score > score_PilihanGanda)
        {
            PlayerPrefs.SetFloat(_PilihanGanda, score);
            score_PilihanGanda = score;
        }
        else if (namaMinigame == _Bilangan && score > score_Bilangan)
        {
            PlayerPrefs.SetFloat(_Bilangan, score);
            score_Bilangan = score;
        }        
        else if (namaMinigame == _HubungkanTitik && score > score_HubungkanTitik)
        {
            PlayerPrefs.SetFloat(_HubungkanTitik, score);
            score_HubungkanTitik = score;
        }
        else if (namaMinigame == _PlusMinus && score > score_PlusMinus)
        {
            PlayerPrefs.SetFloat(_PlusMinus, score);
            score_PlusMinus = score;
        }        
        else if (namaMinigame == _BenarSalah && score > score_BenarSalah)
        {
            PlayerPrefs.SetFloat(_BenarSalah, score);
            score_BenarSalah = score;
        }
        else if (namaMinigame == _BarisBilangan && score > score_BarisBilangan)
        {
            PlayerPrefs.SetFloat(_BarisBilangan, score);
            score_BarisBilangan = score;
        }        
        else if (namaMinigame == _Tandabaca && score > score_Tandabaca)
        {
            PlayerPrefs.SetFloat(_Tandabaca, score);
            score_Tandabaca = score;
        }
    }
}
