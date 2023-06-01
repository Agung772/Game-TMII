using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toko : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerMetagame>())
        {
            MetagameUI.instance.SetNotifInteraksi(true, "Tekan F untuk interaksi");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<PlayerMetagame>())
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                MetagameUI.instance.GetComponent<MetagameButton>().SetUI("TokoAwalUI");
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
