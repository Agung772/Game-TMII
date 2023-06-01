using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetagameButton : MonoBehaviour
{
    [SerializeField] GameObject pauseUI;
    [SerializeField] GameObject petaUI;
    [SerializeField] GameObject tasUI;
    [SerializeField] GameObject tokoUI;
    [SerializeField] GameObject pindahPulauUI;
    [SerializeField] GameObject popupPindahPulau;
    [SerializeField] GameObject tokoAwalUI;
    [SerializeField] GameObject cinderaMataUI;
    [SerializeField] GameObject pilihTemaUI;

    public void SetUI(string namaUI)
    {
        pauseUI.SetActive(false);
        petaUI.SetActive(false);
        RenderMap.instance.gameObject.SetActive(false);
        tasUI.SetActive(false);
        tokoUI.SetActive(false);
        pindahPulauUI.SetActive(false);
        popupPindahPulau.SetActive(false);
        tokoAwalUI.SetActive(false);
        cinderaMataUI.SetActive(false);
        pilihTemaUI.SetActive(false);

        if (namaUI == pauseUI.name)
        {
            pauseUI.SetActive(true);
        }
        else if (namaUI == petaUI.name)
        {
            petaUI.SetActive(true);
            RenderMap.instance.gameObject.SetActive(true);
        }
        else if(namaUI == tasUI.name)
        {
            tasUI.SetActive(true);
        }
        else if(namaUI == tokoUI.name)
        {
            tokoUI.SetActive(true);
        }
        else if(namaUI == pindahPulauUI.name)
        {
            pindahPulauUI.SetActive(true);
        }
        else if (namaUI == popupPindahPulau.name)
        {
            pindahPulauUI.SetActive(true);
            popupPindahPulau.SetActive(true);
        }        
        else if (namaUI == tokoAwalUI.name)
        {
            tokoUI.SetActive(true);
            tokoAwalUI.SetActive(true);
        }
        else if (namaUI == cinderaMataUI.name)
        {
            tokoUI.SetActive(true);
            cinderaMataUI.SetActive(true);
        }
        else if (namaUI == pilihTemaUI.name)
        {
            pilihTemaUI.SetActive(true);
        }
    }
}
