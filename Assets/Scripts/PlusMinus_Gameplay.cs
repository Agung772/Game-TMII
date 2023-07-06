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

        string tempSoal2 = "";
        int soal2 = 0;

        for (int i = 0; i < soal.soalList[soalIndex].soal2.Length; i++)
        {
            if (Char.IsDigit(soal.soalList[soalIndex].soal2[i]))
                tempSoal2 += soal.soalList[soalIndex].soal2[i];
        }

        int.TryParse(tempSoal2, out soal2);
        print(soal2);

    }
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            RightButton();
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            LeftButton();
        }
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
        //Spawn bilangan sususan
        for (int i = 0; i < tempSoal.Length; i++)
        {
            GameObject temp = Instantiate(PlusMinus_UI.instance.bilanganBersusunPrefab, PlusMinus_UI.instance.bilanganBersusunParent);

            string tempSoal1 = soal.soalList[soalIndex].soal1.ToString();
            string tempSoal2 = soal.soalList[soalIndex].soal2.ToString();

            string tempSoal1Index = "";
            tempSoal1Index += tempSoal1[i];

            string tempSoal2Index = "";
            tempSoal2Index += tempSoal2[i];
            if (tempSoal2Index == "-") tempSoal2Index = "";

            temp.GetComponent<PlusMinus_BilanganBersusun>().soalAtasText.text = tempSoal1Index;
            temp.GetComponent<PlusMinus_BilanganBersusun>().soalBawahText.text = tempSoal2Index;

            temp.name = "BilanganBersusun " + i;

            temp.transform.SetAsFirstSibling();

            //Set OperatorAritmatik
            if (soal.soalList[soalIndex].operatorAritmatik == PlusMinus_Soal.OperatorAritmatik.Tambah)
            {
                temp.GetComponent<PlusMinus_BilanganBersusun>().operatorAritmatikText.text = "+";
            }
            else if (soal.soalList[soalIndex].operatorAritmatik == PlusMinus_Soal.OperatorAritmatik.Kurang)
            {
                temp.GetComponent<PlusMinus_BilanganBersusun>().operatorAritmatikText.text = "-";
            }
            else if (soal.soalList[soalIndex].operatorAritmatik == PlusMinus_Soal.OperatorAritmatik.Kali)
            {
                temp.GetComponent<PlusMinus_BilanganBersusun>().operatorAritmatikText.text = "x";
            }

        }


        StartCoroutine(Coroutine());
        IEnumerator Coroutine()
        {
            yield return new WaitForSeconds(0.01f);
            bilanganBersusuns = new PlusMinus_BilanganBersusun[PlusMinus_UI.instance.bilanganBersusunParent.childCount];
            for (int i = 0; i < PlusMinus_UI.instance.bilanganBersusunParent.childCount; i++)
            {
                bilanganBersusuns[i] = PlusMinus_UI.instance.bilanganBersusunParent.GetChild(i).GetComponent<PlusMinus_BilanganBersusun>();
            }

            urutBilangan = 0;
            UpdateselectBilangan();

            //Set UI
            PlusMinus_UI.instance.jumlahSoalText.text = soalIndex + "/5";

            //Sel soal
            string tempSoal2 = "";
            int soal2 = 0;

            for (int i = 0; i < soal.soalList[soalIndex].soal2.Length; i++)
            {
                if (Char.IsDigit(soal.soalList[soalIndex].soal2[i]))
                    tempSoal2 += soal.soalList[soalIndex].soal2[i];
            }
            int.TryParse(tempSoal2, out soal2);
            PlusMinus_UI.instance.soalText.text = soal.soalList[soalIndex].soal1 + " " + bilanganBersusuns[0].operatorAritmatikText.text + " " + soal2;
        }
    }
    public void CheckJawaban()
    {
        int tempInput = int.Parse(outputJawaban);

        //Convert to int
        string tempSoal2 = "";
        int soal2 = 0;

        for (int i = 0; i < soal.soalList[soalIndex].soal2.Length; i++)
        {
            if (Char.IsDigit(soal.soalList[soalIndex].soal2[i]))
                tempSoal2 += soal.soalList[soalIndex].soal2[i];
        }


        //Get int
        int soal1 = int.Parse(soal.soalList[soalIndex].soal1);
        int.TryParse(tempSoal2, out soal2);

        int jawabanBenar = 0;
        if (soal.soalList[soalIndex].operatorAritmatik == PlusMinus_Soal.OperatorAritmatik.Tambah)
        {
            jawabanBenar = soal1 + soal2;
        }
        else if (soal.soalList[soalIndex].operatorAritmatik == PlusMinus_Soal.OperatorAritmatik.Kurang)
        {

            if (soal2 < 0) { soal2 = soal2 - soal2 - soal2; }
            jawabanBenar = soal1 - soal2;
            print(soal2);
        }
        else if (soal.soalList[soalIndex].operatorAritmatik == PlusMinus_Soal.OperatorAritmatik.Kali)
        {
            jawabanBenar = soal1 * soal2;
        }

        print(tempInput);
        print(jawabanBenar);
        if (tempInput == jawabanBenar)
        {
            print("Jawaban benar");
            StartSoal();
        }
        else
        {
            print("Jawaban salah");
        }


    }
    public void JawabanInput(string input)
    {
        if (input != "")
        {
            int tempInput = int.Parse(input);
            //Input jawaban untuk penjumlahan ------------------------------------------------------
            if (soal.soalList[soalIndex].operatorAritmatik == PlusMinus_Soal.OperatorAritmatik.Tambah)
            {
                if (tempInput >= 10 && urutBilangan < bilanganBersusuns.Length - 1)
                {
                    string temp0 = "";
                    temp0 += input[0];

                    string temp1 = "";
                    temp1 += input[1];

                    bilanganBersusuns[urutBilangan + 1].naikText.text = temp0.ToString();
                    bilanganBersusuns[urutBilangan].jawabanInput.text = temp1.ToString();
                }
            }
            //Input jawaban untuk pengurangan ------------------------------------------------------
            else if (soal.soalList[soalIndex].operatorAritmatik == PlusMinus_Soal.OperatorAritmatik.Kurang)
            {
                int soalNaik = 0;
                if (bilanganBersusuns[urutBilangan].naikText.text != "") soalNaik = int.Parse(bilanganBersusuns[urutBilangan].naikText.text);
                else soalNaik = 0;

                int soalAtas = int.Parse(bilanganBersusuns[urutBilangan].soalAtasText.text);
                int soalBawah = 0;
                if (bilanganBersusuns[urutBilangan].soalBawahText.text != "") 
                soalBawah = int.Parse(bilanganBersusuns[urutBilangan].soalBawahText.text);
                print(((soalNaik + soalAtas) - soalBawah));
                if (((soalNaik + soalAtas) - soalBawah) < 0 && urutBilangan < bilanganBersusuns.Length - 1)
                {
                    bilanganBersusuns[urutBilangan + 1].naikText.text = "-1";
                }
            }
            //Input jawaban untuk perkalian ------------------------------------------------------
            else if (soal.soalList[soalIndex].operatorAritmatik == PlusMinus_Soal.OperatorAritmatik.Kali)
            {
                int soalAtas = int.Parse(bilanganBersusuns[urutBilangan].soalAtasText.text);
                int soalBawah = 0;
                if (bilanganBersusuns[urutBilangan].soalBawahText.text != "")
                    soalBawah = int.Parse(bilanganBersusuns[urutBilangan].soalBawahText.text);
                if (tempInput >= 10 && urutBilangan < bilanganBersusuns.Length - 1)
                {
                    string temp0 = "";
                    temp0 += input[0];

                    string temp1 = "";
                    temp1 += input[1];

                    bilanganBersusuns[urutBilangan + 1].naikText.text = temp0.ToString();
                    bilanganBersusuns[urutBilangan].jawabanInput.text = temp1.ToString();
                }
            }

            //Get jawaban dari semua bilangan sususan ------------------------------------------------------
            outputJawaban = null;
            for (int i = bilanganBersusuns.Length - 1; i > -1; i--)
            {
                outputJawaban += bilanganBersusuns[i].jawabanInput.text;
            }
        }
        else
        {
            //Hapus penaikan bilangan ------------------------------------------------------
            if (urutBilangan < bilanganBersusuns.Length - 1)
            {
                bilanganBersusuns[urutBilangan + 1].naikText.text = "";
            }

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
 

        float a = 0;
        float b = 0;
        if (bilanganBersusuns.Length > 1)
        {
            print("UpdateSe");
            a = bilanganBersusuns[urutBilangan].GetComponent<RectTransform>().localPosition.x;
            b = a;
        }

        selectBilangan.localPosition = new Vector3(b, selectBilangan.localPosition.y, 0);

        bilanganBersusuns[urutBilangan].jawabanInput.ActivateInputField();
    }

}
