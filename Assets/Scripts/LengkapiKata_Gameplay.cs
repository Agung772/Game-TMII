using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LengkapiKata_Gameplay : MonoBehaviour
{
    public int nyawa;

    public int soalIndex;


    [SerializeField] LengkapiKata_Soal[] tugu;
    LengkapiKata_Soal soal;

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
        LengkapiKata_UI.instance.SetNyawa(nyawa);

        StartSoal();
    }
    public void StartSoal()
    {
        soalIndex++;

        LengkapiKata_UI.instance.jumlahSoalText.text = "0" + soalIndex;
        LengkapiKata_UI.instance.soalText.text = soal.soalList[soalIndex].soal;
        LengkapiKata_UI.instance.ilustrasiImage.sprite = soal.soalList[soalIndex].ilustrasi;
    }

    public void InputJawaban(string value)
    {
        string jawaban = value.ToLower();

        if (jawaban == soal.soalList[soalIndex].jawaban)
        {
            //Jawaban benar
            Minigame_UI.instance.MiniscoreUI(true);

            if (soalIndex == soal.soalList.Length - 1)
            {
                Minigame_UI.instance.ScoreUI(DataGame.instance.minigame._LengkapiKata, nyawa);
            }
            else
            {
                StartSoal();
                LengkapiKata_UI.instance.inputField.text = null;
            }

        }
        else
        {
            //Jawaban salah
            nyawa--;
            LengkapiKata_UI.instance.SetNyawa(nyawa);

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
}
