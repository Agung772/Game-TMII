using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Perbandingan_Benda : MonoBehaviour
{
    public bool kanan;
    bool tempatBenda;
    bool click;

    RectTransform tempatBendaRT;
    private void Start()
    {
        Perbandingan_TempatBenda[] temp = FindObjectsOfType<Perbandingan_TempatBenda>();
        for (int i = 0; i < temp.Length; i++)
        {
            if (kanan && temp[i].kanan)
            {
                tempatBendaRT = temp[i].GetComponent<RectTransform>();
            }
            else if (!kanan && !temp[i].kanan)
            {
                tempatBendaRT = temp[i].GetComponent<RectTransform>();
            }
        }

    }
    private void Update()
    {
        if (Vector3.Distance(GetComponent<RectTransform>().position, tempatBendaRT.position) < 15)
        {
            tempatBenda = true;
        }
        else
        {
            tempatBenda = false;
        }
    }

    public void Click(bool value)
    {
        if (value)
        {
            click = true;
        }
        else
        {
            click = false;

            if (tempatBenda)
            {

            }
            else
            {

            }
        }
    }
}
