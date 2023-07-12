using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarisBilangan_Gameplay : MonoBehaviour
{
    public static BarisBilangan_Gameplay instance;

    public float waktuTempat;
    float m_waktuTempat;

    public int nyawa = 3;
    public int soalIndex;

    [SerializeField] BarisBilangan_Soal[] tugu;

    BarisBilangan_Soal soal;
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        m_waktuTempat = waktuTempat;

        for (int i = 0; i < tugu[1].transform.parent.childCount; i++)
        {
            tugu[1].transform.parent.GetChild(i).gameObject.SetActive(false);
        }

        //Start
        if (DataGame.instance.pulau == DataGame.instance._Sumatera)
        {
            soal = tugu[(int)DataGame.instance.codeTugu];
        }
        else
        {
            soal = tugu[(int)DataGame.instance.codeTugu];
        }
        soal.gameObject.SetActive(true);
        BarisBilangan_UI.instance.SetNyawa(nyawa);

        StartSoal();
    }

    public void StartSoal()
    {
        soalIndex++;

        BarisBilangan_UI.instance.jumlahSoalText.text = soalIndex + "/5";
        BarisBilangan_UI.instance.soalText.text = soal.soalList[soalIndex].soal;

        BarisBilangan_Player.instance.nomor = soal.soalList[soalIndex].nomorAwal;
        BarisBilangan_Player.instance.posisiContent = soal.soalList[soalIndex].nomorAwal;
    }
    public void CheckJawaban()
    {
        if (soal.soalList[soalIndex].nomorBenar == BarisBilangan_Player.instance.nomor)
        {
            print("Benar");
        }
        else
        {
            nyawa--;
            BarisBilangan_UI.instance.SetNyawa(nyawa);
            print("Salah");
        }
    }

    int valueSebelumnya;
    bool breakWhile;
    public void SetTempat(int value)
    {
        var content = BarisBilangan_Content.instance;

        breakWhile = true;
        m_waktuTempat = waktuTempat;
        content.tempat[value].delayImage.fillAmount = m_waktuTempat / waktuTempat;

        if (valueSebelumnya != 0) content.tempat[valueSebelumnya].delayParent.SetActive(false);
        content.tempat[value].delayParent.SetActive(true);
        valueSebelumnya = value;


        StartCoroutine(Coroutine());
        IEnumerator Coroutine()
        {
            yield return new WaitForSeconds(0.1f);
            breakWhile = false;
            while (m_waktuTempat > 0 && !breakWhile)
            {
                m_waktuTempat -= Time.deltaTime;
                content.tempat[value].delayImage.fillAmount = m_waktuTempat / waktuTempat;

                if (m_waktuTempat <= 0)
                {
                    CheckJawaban();
                }

                yield return null;
            }

        }
    }
}
