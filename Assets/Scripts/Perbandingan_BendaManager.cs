using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Perbandingan_BendaManager : MonoBehaviour
{
    public bool kanan;
    public int jumlahSpawn;

    public GameObject bendaPrefab;
    public Perbandingan_TempatBenda tempatBendaSC;

    GameObject benda;
    public void Click(bool value)
    {
        if (tempatBendaSC.jumlahBenda < 10)
        {
            if (value)
            {
                benda = Instantiate(bendaPrefab, transform);
                var bendaSC = benda.GetComponent<Perbandingan_Benda>();

                bendaSC.gameObject.SetActive(true);
                bendaSC.tempatBendaSC = tempatBendaSC;
                bendaSC.click = true;
            }
            else
            {
                var bendaSC = benda.GetComponent<Perbandingan_Benda>();

                bendaSC.click = false;

                if (bendaSC.tempatBenda)
                {
                    tempatBendaSC.jumlahBenda++;
                    jumlahSpawn++;
                    for (int i = 0; i < tempatBendaSC.posisiBenda.Length; i++)
                    {
                        if (tempatBendaSC.benda[i] == null)
                        {
                            tempatBendaSC.benda[i] = bendaSC.gameObject;
                            bendaSC.GetComponent<RectTransform>().position = tempatBendaSC.posisiBenda[i].position;
                            break;
                        }

                    }
                }
                else
                {
                    Destroy(bendaSC.gameObject);
                }
            }
        }
    }
}
