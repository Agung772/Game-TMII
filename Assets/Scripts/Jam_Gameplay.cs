using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Jam_Gameplay : MonoBehaviour
{
    public int nyawa = 3;
    public int soalIndex;

    [SerializeField] Jam_Jam jamLeft;
    [SerializeField] Jam_Jam jamRight;
    [SerializeField] Jam_Jam jamJawab;

    [SerializeField] Jam_Soal[] tugu;

    Jam_Soal soal;

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
        else
        {
            soal = tugu[(int)DataGame.instance.codeTugu];
        }
        soal.gameObject.SetActive(true);
        Jam_UI.instance.SetNyawa(nyawa);

        StartSoal();
    }

    public void StartSoal()
    {
        soalIndex++;

        jamLeft.menit = soal.soalList[soalIndex].menitLeft;
        jamLeft.jam = soal.soalList[soalIndex].jamLeft;
        jamLeft.UpdateUI();

        jamRight.menit = soal.soalList[soalIndex].menitRight;
        jamRight.jam = soal.soalList[soalIndex].jamRight;
        jamRight.UpdateUI();

        jamJawab.menit = 0;
        jamJawab.jam = 0;
        jamJawab.UpdateUI();

    }

    public bool hold, useHold;
    public void HoldButton(string value)
    {
        float holdTime = 0;

        if (value == "right, hold") { hold = true; holdTime = 1; }
        if (value == "left, hold") { hold = true; holdTime = 1; }
        if (value == "right, !hold") hold = false;
        if (value == "left, !hold") hold = false;

        bool cd = false;
        StartCoroutine(Coroutine());
        IEnumerator Coroutine()
        {
            while(holdTime > 0 && hold)
            {
                holdTime -= Time.deltaTime;
                print(holdTime);
                yield return null;
            }

            while (holdTime <= 0 && hold)
            {
                useHold = true;
                if (!cd)
                {
                    cd = true;
                    if (value == "right, hold")
                    {
                        SlideButton(true);
                    }
                    else if (value == "left, hold")
                    {
                        SlideButton(false);
                    }
                    yield return new WaitForSeconds(0.1f);
                    cd = false;
                }
                yield return null;
            }
        }

        if (value == "right, !hold" && !useHold) SlideButton(true);
        else if (value == "left, !hold" && !useHold) SlideButton(false);
        else useHold = false;
    }

    public void SlideButton(bool right)
    {
        if (right)
        {
            jamJawab.menit += 5;
        }
        else
        {
            jamJawab.menit -= 5;
        }
        jamJawab.UpdateUI();
    }
}
