using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bilangan_Gameplay : MonoBehaviour
{
    public static Bilangan_Gameplay instance;

    [SerializeField] float waktu;
    float o_waktu;

    [SerializeField] Bilangan_Soal[] tugu;
    Bilangan_Soal soal;

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

        o_waktu = waktu;

        StartSoal();
    }

    bool oTime;
    private void Update()
    {
        if (!oTime) o_waktu -= Time.deltaTime;
        Bilangan_UI.instance.timeImage.fillAmount = o_waktu / waktu;

        if (o_waktu <= 0)
        {
            Minigame_UI.instance.ScoreUI(DataGame.instance.minigame._Bilangan, 0);
        }
    }

    public void StartSoal()
    {
        Bilangan_UI.instance.soalText.text = soalIndex + "/5";
        Bilangan_UI.instance.codeText.text = soal.soalList[soalIndex].angka.ToString();
        Bilangan_UI.instance.petunjukText.text = soal.soalList[soalIndex].dibaca.ToString();
    }

    public void InputJawaban()
    {
        if (Bilangan_InputManager.instance.output == soal.soalList[soalIndex].angka)
        {
            if (soalIndex == soal.soalList.Length - 1)
            {
                StartCoroutine(Coroutine());
                IEnumerator Coroutine()
                {
                    oTime = true;
                    yield return new WaitForSeconds(2);
                    Minigame_UI.instance.ScoreUI(DataGame.instance.minigame._Bilangan, 3);
                }
            }
            else
            {
                soalIndex++;
                StartSoal();

                o_waktu = waktu;
                
                Bilangan_InputManager.instance.OutputReset();
            }

        }
        else
        {
            UIManager.instance.SpawnNotif("Jawaban yang kamu bikin salah");
        }
    }


}
