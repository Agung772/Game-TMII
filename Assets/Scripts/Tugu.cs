using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tugu : MonoBehaviour
{
    public string namaTugu;
    public int codeTugu;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerMetagame>())
        {
            MetagameUI.instance.SetNotifInteraksi(true, "Tekan F untuk mulai belajar");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<PlayerMetagame>())
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                MetagameUI.instance.GetComponent<MetagameButton>().SetUI("PilihTemaUI");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<PlayerMetagame>())
        {
            MetagameUI.instance.SetNotifInteraksi(false, "");
        }
    }
}
