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

    [SerializeField] GameObject pilihSubTemaUI;
    [HideInInspector] public Metagame_PilihSubTema pilihSubTema;

    private void Awake()
    {
        pilihSubTema = pilihSubTemaUI.GetComponent<Metagame_PilihSubTema>();
    }

    public void SetUI(string namaUI)
    {
        pauseUI.SetActive(false);
        petaUI.SetActive(false);
        tasUI.SetActive(false);
        tokoUI.SetActive(false);
        pindahPulauUI.SetActive(false);
        popupPindahPulau.SetActive(false);
        tokoAwalUI.SetActive(false);
        cinderaMataUI.SetActive(false);
        pilihSubTemaUI.SetActive(false);

        if (namaUI == pauseUI.name)
        {
            pauseUI.SetActive(true);
        }
        else if (namaUI == petaUI.name)
        {
            petaUI.SetActive(true);
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
        else if (namaUI == pilihSubTemaUI.name)
        {
            pilihSubTemaUI.SetActive(true);
        }
    }
}
