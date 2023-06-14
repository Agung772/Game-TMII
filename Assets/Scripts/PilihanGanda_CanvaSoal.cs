using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PilihanGanda_CanvaSoal : MonoBehaviour
{
    public TextMeshProUGUI soalText;
    public int jawabanBenar;
    public TextMeshProUGUI jawaban1;
    public TextMeshProUGUI jawaban2;
    public TextMeshProUGUI jawaban3;

    public Vector3[] pos = new Vector3[4];
    public bool[] randomBool = new bool[4];
    int randomIndex;

    public void RandomJawaban()
    {
        //Get
        for (int i = 0; i < 4; i++)
        {
            if (i != 0)
            {
                pos[i] = transform.GetChild(i).GetComponent<RectTransform>().position;
            }
        }

        //Set
        RandomIndex();
        transform.GetChild(1).GetComponent<RectTransform>().position = pos[randomIndex];


        void RandomIndex()
        {
            int random = Random.Range(1, 4);
            print(random);

            for (int i = 0; i < 4; i++)
            {
                if (i != 0)
                {
                    if (!randomBool[i] && random == i)
                    {
                        randomBool[i] = true;
                        randomIndex = i;
                        break;
                    }
                    else if (randomBool[i] && random == i)
                    {
                        RandomIndex();
                    }
                }

            }
        }
    }

    public void InputJawaban(int value)
    {
        if (value == jawabanBenar)
        {
            //Jawaban benar
            PilihanGanda_Gameplay.instance.JawabanBenar();
        }
        else
        {
            //Jawaban salah
            PilihanGanda_Gameplay.instance.JawabanSalah();
        }
    }
}
