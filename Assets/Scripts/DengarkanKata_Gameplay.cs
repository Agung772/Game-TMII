using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class DengarkanKata_Gameplay : MonoBehaviour
{
    public static DengarkanKata_Gameplay instance;

    [SerializeField] int nyawa;

    [SerializeField] DengarkanKata_Soal[] tugu;
    DengarkanKata_Soal soal;

    public int soalIndex;

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
        soalIndex++;
        //DengarkanKata_UI.instance.inputJawaban.interactable = false;
        DengarkanKata_UI.instance.soalText.text = "0" + soalIndex;
        DengarkanKata_UI.instance.SetNyawa(nyawa);
        DengarkanKata_UI.instance.inputJawaban.interactable = false;
    }

    bool cdSoal;
    public void StartSoal()
    {
        if (!cdSoal)
        {
            cdSoal = true;
            StartCoroutine(Coroutine());
            IEnumerator Coroutine()
            {
                print("Kunci jawaban " + soal.soalList[soalIndex].jawaban);
                DengarkanKata_UI.instance.inputJawaban.interactable = true;
                if (soal.soalList[soalIndex].audioSoal != null) AudioManager.instance.SFXAudioSource.PlayOneShot(soal.soalList[soalIndex].audioSoal);
                //DengarkanKata_UI.instance.putarSuaraButton.SetActive(false);
                yield return new WaitForSeconds(2);
                cdSoal = false;
            }
        }
        else
        {
            UIManager.instance.SpawnNotif("Sabar cuy jangan nge-spam");
        }



    }
    public void InputJawaban(string value)
    {
        if (soal.soalList[soalIndex].jawaban == value.ToLower())
        {

            if (soalIndex == soal.soalList.Count - 1)
            {
                StartCoroutine(Coroutine());
                IEnumerator Coroutine()
                {
                    yield return new WaitForSeconds(2);
                    Minigame_UI.instance.ScoreUI(DataGame.instance.minigame._DengarkanKata, nyawa);
                }

            }
            else
            {
                soalIndex++;
                DengarkanKata_UI.instance.soalText.text = "0" + soalIndex;
                DengarkanKata_UI.instance.putarSuaraButton.SetActive(true);
                Minigame_UI.instance.MiniscoreUI(true);
                //DengarkanKata_UI.instance.inputJawaban.interactable = false;
                DengarkanKata_UI.instance.inputJawaban.text = null;
                DengarkanKata_UI.instance.inputJawaban.interactable = false;
            }
        }
        else if (value == "")
        {

        }
        else
        {
            nyawa--;
            if (nyawa == 0)
            {
                Minigame_UI.instance.ScoreUI(DataGame.instance.minigame._DengarkanKata, 0);
            }
            else
            {
                Minigame_UI.instance.MiniscoreUI(false);
            }
            DengarkanKata_UI.instance.SetNyawa(nyawa);
        }
    }
}
