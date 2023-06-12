using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Perbandingan_Benda : MonoBehaviour
{
    public bool kanan;
    public bool tempatBenda;
    public bool click;

    Vector3 posisiAwal;
    public Perbandingan_TempatBenda tempatBendaSC;
    private void Start()
    {
        posisiAwal = GetComponent<RectTransform>().position;
    }
    private void Update()
    {
        if (click)
        {
            GetComponent<RectTransform>().position = Input.mousePosition;
        }
    }

    public void Click(bool value)
    {
        if (value)
        {
            click = true;

            tempatBendaSC.jumlahBenda--;
            for (int i = 0; i < tempatBendaSC.posisiBenda.Length; i++)
            {
                if (tempatBendaSC.benda[i] == gameObject)
                {
                    tempatBendaSC.benda[i] = null;
                }

            }
        }
        else
        {
            click = false;

            if (tempatBenda)
            {
                tempatBendaSC.jumlahBenda++;
                for (int i = 0; i < tempatBendaSC.posisiBenda.Length; i++)
                {
                    if (tempatBendaSC.benda[i] == null)
                    {
                        tempatBendaSC.benda[i] = gameObject;
                        GetComponent<RectTransform>().position = tempatBendaSC.posisiBenda[i].position;
                        break;
                    }

                }
            }

            else
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Perbandingan_TempatBenda>())
        {
            if (collision.GetComponent<Perbandingan_TempatBenda>().kanan == kanan)
            {
                tempatBenda = true;
            }

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Perbandingan_TempatBenda>())
        {
            tempatBenda = false;
        }
    }
}
