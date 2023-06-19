using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KartuMemori_Gameplay : MonoBehaviour
{
    public static KartuMemori_Gameplay instance;

    public float gameTime;

    [Space]
    GameObject kartuParent;

    [Space]
    public float totalKartu;
    public float totalSelesai;

    [Space]
    public float codePertama;
    public float codeKedua;

    public KartuMemori_Kartu kartuPertama;
    public KartuMemori_Kartu kartuKedua;
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        for (int i = 0; i < KartuMemori_UI.instance.kartuTugu[1].transform.parent.childCount; i++)
        {
            KartuMemori_UI.instance.kartuTugu[1].transform.parent.GetChild(i).gameObject.SetActive(false);
        }
        print(DataGame.instance._Sumatera);
        if (DataGame.instance.pulau == DataGame.instance._Sumatera)
        {
            kartuParent = KartuMemori_UI.instance.kartuTugu[(int)DataGame.instance.codeTugu];
        }
        else
        {
            //null
            kartuParent = KartuMemori_UI.instance.kartuTugu[(int)DataGame.instance.codeTugu];
        }
        kartuParent.SetActive(true);
        totalKartu = kartuParent.transform.childCount;
        KartuMemori_UI.instance.totalSelesaiText.text = "0" + totalSelesai.ToString();

        RandomKartu();
    }
    private void Update()
    {
        if (gameTime > 0)
        {
            gameTime -= Time.deltaTime;
            KartuMemori_UI.instance.gameTimeText.text = System.TimeSpan.FromSeconds(gameTime).Minutes + ":" + System.TimeSpan.FromSeconds(gameTime).Seconds;
        }
    }

    void RandomKartu()
    {
        Vector2[] tempV2 = new Vector2[(int)totalKartu];
        RectTransform[] tempRT = new RectTransform[(int)totalKartu];
        for (int i = 0; i < (int)totalKartu; i++)
        {
            tempRT[i] = kartuParent.transform.GetChild(i).GetComponent<RectTransform>();
            tempV2[i] = kartuParent.transform.GetChild(i).GetComponent<RectTransform>().localPosition;
        }

        int index = 0;
        bool[] randomBool = new bool[(int)totalKartu];
        void RandomIndex()
        {
            float random = Random.Range(0, (int)totalKartu);
            print(random);
            for (int i = 0; i < (int)totalKartu; i++)
            {
                if (!randomBool[i] && random == i)
                {
                    randomBool[i] = true;
                    index = i;

                    break;
                }
                else if (randomBool[i] && random == i)
                {
                    RandomIndex();
                }
            }
        }

        for (int i = 0; i < (int)totalKartu; i++)
        {
            RandomIndex();
            tempRT[i].localPosition = tempV2[index];

        }


    }
    public void CekKartu(float codeKartu, KartuMemori_Kartu kartu)
    {
        if (codeKartu == 0)
        {
            if (codePertama != 0)
            {
                codePertama = 0;
                kartuPertama = kartu;
            }
        }
        else if (codePertama == 0)
        {
            codePertama = codeKartu;
            kartuPertama = kartu;
        }
        else if (codeKedua == 0)
        {
            codeKedua = codeKartu;
            kartuKedua = kartu;
        }

        //Sudah kebuka 2 kartu
        if (codePertama != 0 && codeKedua != 0)
        {
            if (codePertama == codeKedua)
            {
                StartCoroutine(Coroutine());
                IEnumerator Coroutine()
                {
                    codePertama = 0;
                    codeKedua = 0;

                    kartuPertama.selesai = true;
                    kartuKedua.selesai = true;

                    SetCheck(true);
                    yield return new WaitForSeconds(0.66f);
                    SetCheck(false);

                    totalSelesai++;
                    KartuMemori_UI.instance.totalSelesaiText.text = "0" + totalSelesai.ToString();
                    //Selesai semua
                    if (totalSelesai == totalKartu / 2)
                    {
                        print("Selesai");
                        Minigame_UI.instance.ScoreUI(DataGame.instance.minigame._KartuMemori, 2);
                    }
                }
            }
            else
            {
                StartCoroutine(Coroutine());
                IEnumerator Coroutine()
                {
                    codePertama = 0;
                    codeKedua = 0;

                    SetCheck(true);
                    yield return new WaitForSeconds(0.66f);
                    kartuPertama.SetKartuBelakang();
                    kartuKedua.SetKartuBelakang();
                    yield return new WaitForSeconds(0.66f);
                    SetCheck(false);
                }

            }
        }
    }

    void SetCheck(bool value)
    {
        if (value)
        {
            for (int i = 0; i < (int)totalKartu; i++)
            {
                kartuParent.transform.GetChild(i).GetComponent<KartuMemori_Kartu>().check = true;
            }
        }
        else
        {
            for (int i = 0; i < (int)totalKartu; i++)
            {
                kartuParent.transform.GetChild(i).GetComponent<KartuMemori_Kartu>().check = false;
            }
        }
    }
}
