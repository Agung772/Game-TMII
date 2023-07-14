using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TandaBaca_Gameplay : MonoBehaviour
{
    public static TandaBaca_Gameplay instance;
    public int nyawa = 3;
    public int soalIndex;

    [SerializeField] Transform kotakSelect;

    [SerializeField] TandaBaca_SoalManager[] tugu;

    TandaBaca_SoalManager soalManager;
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
            soalManager = tugu[(int)DataGame.instance.codeTugu];
        }
        else
        {
            soalManager = tugu[(int)DataGame.instance.codeTugu];
        }
        soalManager.gameObject.SetActive(true);
        TandaBaca_UI.instance.SetNyawa(nyawa);

        StartSoal();
    }

    public void StartSoal()
    {
        //Resetttt
        for (int i = 0; i < tugu[1].transform.childCount; i++)
        {
            tugu[1].transform.GetChild(i).gameObject.SetActive(false);
        }

        soalIndex++;
        TandaBaca_UI.instance.jumlahSoalText.text = soalIndex + "/5";
        soalManager.soal[soalIndex].gameObject.SetActive(true);

        slide = 0;
        kotakSelect.position = soalManager.soal[soalIndex].inputs[slide].transform.position;
    }


    public int slide;
    public void SlideButton(bool right)
    {
        if (right)
        {
            if (slide < soalManager.soal[soalIndex].jawaban.Length -1)
            {
                slide++;
            }
        }
        else
        {
            if (slide > 0)
            {
                slide--;
            }
        }

        kotakSelect.position = soalManager.soal[soalIndex].inputs[slide].transform.position;
    }

    public void InputButton(TextMeshProUGUI text)
    {
        soalManager.soal[soalIndex].inputs[slide].text = text.text;
    }

    public void CheckJawaban()
    {
        int totalJawaban = soalManager.soal[soalIndex].jawaban.Length;
        int count = 0;
        for (int i = 0; i < totalJawaban; i++)
        {
            if (soalManager.soal[soalIndex].inputs[i].text == soalManager.soal[soalIndex].jawaban[i])
            {
                count++;
            }
            else if (soalManager.soal[soalIndex].inputs[i].text == "...")
            {
                UIManager.instance.SpawnNotif("Isi semua jawaban");
                return;
            }
            else
            {
                break;
            }
        }

        if (totalJawaban == count)
        {
            print("Benar");

            if (soalIndex == 5)
            {
                Minigame_UI.instance.ScoreUI(DataGame.instance.minigame._TandaBaca, nyawa);
            }
            else
            {
                Minigame_UI.instance.MiniscoreUI(true);
                StartSoal();
            }

        }
        else
        {
            print("Salah");
            nyawa--;
            TandaBaca_UI.instance.SetNyawa(nyawa);

            if (nyawa == 0)
            {
                Minigame_UI.instance.ScoreUI(DataGame.instance.minigame._TandaBaca, nyawa);
            }
            else
            {
                Minigame_UI.instance.MiniscoreUI(false);
            }
        }
    }
}
