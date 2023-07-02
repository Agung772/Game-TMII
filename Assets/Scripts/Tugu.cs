using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tugu : MonoBehaviour
{
    public string namaTugu;
    public int codeTugu;

    public enum MinigameList
    {
        _KartuMemori,
        _PolaSuara,
        _DengarkanKata,
        _Perbandingnan,
        _LengkapiKata,
        _PilihanGanda,
        _Bilangan,
        _HubungkanTitik,
        _PlusMinus
    }
    [System.Serializable]
    public struct MinigameSelect
    {
        public string judulSubtema;
        public MinigameList minigameList;
    }
    public MinigameSelect[] minigameSelects;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerMetagame>())
        {
            MetagameUI.instance.SetNotifInteraksi(true, "Tekan F untuk mulai belajar");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<PlayerMetagame>())
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                string[] tempNamaSubtema = new string[minigameSelects.Length];
                string[] tempMinigame = new string[minigameSelects.Length];
                for (int i = 0; i < minigameSelects.Length; i++)
                {
                    tempNamaSubtema[i] = minigameSelects[i].judulSubtema;
                    tempMinigame[i] = minigameSelects[i].minigameList.ToString();
                }

                DataGame.instance.SaveCodeTugu(codeTugu);
                MetagameUI.instance.GetComponent<MetagameButton>().pilihSubTema.Set(tempNamaSubtema, tempMinigame);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<PlayerMetagame>())
        {
            MetagameUI.instance.SetNotifInteraksi(false, "");
        }
    }
}
