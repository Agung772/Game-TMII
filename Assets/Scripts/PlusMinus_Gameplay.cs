using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlusMinus_Gameplay : MonoBehaviour
{
    public static PlusMinus_Gameplay instance;

    public int soalIndex;

    public RectTransform selectBilangan;
    public PlusMinus_BilanganBersusun[] bilanganBersusuns;

    public int urutBilangan;
    public string outputJawaban;

    public PlusMinus_Soal[] tugu;
    public PlusMinus_Soal soal;
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


        StartSoal();


    }

    void StartSoal()
    {
        soalIndex++;
        for (int i = 0; i < PlusMinus_UI.instance.bilanganBersusunParent.childCount; i++)
        {
            Destroy(PlusMinus_UI.instance.bilanganBersusunParent.GetChild(i).gameObject);
        }

        //Get index soal
        string tempSoal = soal.soalList[soalIndex].soal1.ToString();
        for (int i = 0; i < tempSoal.Length; i++)
        {
            GameObject temp = Instantiate(PlusMinus_UI.instance.bilanganBersusunPrefab, PlusMinus_UI.instance.bilanganBersusunParent);

            string tempSoal1 = soal.soalList[soalIndex].soal1.ToString();
            string tempSoal2 = soal.soalList[soalIndex].soal2.ToString();

            string tempSoal1Index = "";
            tempSoal1Index += tempSoal1[i];

            string tempSoal2Index = "";
            tempSoal2Index += tempSoal2[i];

            temp.GetComponent<PlusMinus_BilanganBersusun>().soalAtasText.text = tempSoal1Index;
            temp.GetComponent<PlusMinus_BilanganBersusun>().soalBawahText.text = tempSoal2Index;

            temp.name = "BilanganBersusun " + i;

            temp.transform.SetAsFirstSibling();

           

        }

        StartCoroutine(Coroutine());
        IEnumerator Coroutine()
        {
            yield return new WaitForSeconds(0.01f);
            for (int i = 0; i < PlusMinus_UI.instance.bilanganBersusunParent.childCount; i++)
            {
                print(i);
                bilanganBersusuns[i] = PlusMinus_UI.instance.bilanganBersusunParent.GetChild(i).GetComponent<PlusMinus_BilanganBersusun>();

                if (i == PlusMinus_UI.instance.bilanganBersusunParent.childCount - 1)
                {
                    bilanganBersusuns[i].jawabanInput.onEndEdit.AddListener(CheckJawaban);
                }
            }

            urutBilangan = 0;
            UpdateselectBilangan();
        }

        //Set bilangan bersusun


    }

    public void CheckJawaban(string inputJawaban)
    {
        int tempInput = int.Parse(outputJawaban);
        int jawabanBenar = soal.soalList[soalIndex].soal1 + soal.soalList[soalIndex].soal2;

        print(tempInput);
        print(jawabanBenar);
        if (tempInput == jawabanBenar)
        {
            print("Jawaban benar");
        }
        else
        {
            print("Jawaban salah");
        }
    }
    public void RightButton()
    {
        if (urutBilangan > 0)
        {
            urutBilangan--;
            UpdateselectBilangan();
        }
        bilanganBersusuns[urutBilangan].jawabanInput.ActivateInputField();
    }
    public void LeftButton()
    {
        if (urutBilangan < bilanganBersusuns.Length - 1)
        {
            urutBilangan++;
            UpdateselectBilangan();
        }
        bilanganBersusuns[urutBilangan].jawabanInput.ActivateInputField();
    }
    void UpdateselectBilangan()
    {
        float a = bilanganBersusuns[1].GetComponent<RectTransform>().localPosition.x;
        float b = a * urutBilangan + bilanganBersusuns[1].transform.parent.GetComponent<RectTransform>().localPosition.x;

        selectBilangan.localPosition = new Vector3(b, selectBilangan.localPosition.y, 0);

        bilanganBersusuns[urutBilangan].jawabanInput.ActivateInputField();
    }

    public void JawabanInput(string input)
    {


        if (input != "")
        {
            int tempInput = int.Parse(input);
            if (tempInput >= 10 && urutBilangan < bilanganBersusuns.Length - 1)
            {
                string temp0 = "";
                temp0 += input[0];

                string temp1 = "";
                temp1 += input[1];

                bilanganBersusuns[urutBilangan + 1].naikText.text = temp0.ToString();
                bilanganBersusuns[urutBilangan].jawabanInput.text = temp1.ToString();
            }

            outputJawaban = null;
            for (int i = bilanganBersusuns.Length - 1; i > -1; i--)
            {
                outputJawaban += bilanganBersusuns[i].jawabanInput.text;
            }
        }
        else
        {
            bilanganBersusuns[urutBilangan + 1].naikText.text = "";
        }


    }
}
