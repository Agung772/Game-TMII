using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HubungkanTitik_DotPos : MonoBehaviour
{
    public bool benar;
    public bool salah;

    [HideInInspector]
    public HubungkanTitik_StartDot startDot;    
    [HideInInspector]
    public HubungkanTitik_EndDot endDot;


    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<HubungkanTitik_EndDot>())
        {
            if (other.GetComponent<HubungkanTitik_EndDot>().codeDot == startDot.codeDot)
            {
                benar = true;

                endDot = other.GetComponent<HubungkanTitik_EndDot>();
            }
            else
            {
                salah = true;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {

        if (other.GetComponent<HubungkanTitik_EndDot>())
        {
            benar = false;
            salah = false;
        }
    }
}
