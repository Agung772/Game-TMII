using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PolaSuara_UI : MonoBehaviour
{
    public static PolaSuara_UI instance;

    public TextMeshProUGUI notifText;
    public TextMeshProUGUI soalText;

    public GameObject putarSuaraButton;

    public GameObject bellSumatera;



    private void Awake()
    {
        instance = this;
    }

    [SerializeField] GameObject[] nyawa;
    public void SetNyawa(int totalNyawa)
    {
        if (totalNyawa == 3)
        {
            nyawa[0].SetActive(true);
            nyawa[1].SetActive(true);
            nyawa[2].SetActive(true);
        }
        else if (totalNyawa == 2)
        {
            nyawa[0].SetActive(true);
            nyawa[1].SetActive(true);
            nyawa[2].SetActive(false);
        }
        else if (totalNyawa == 1)
        {
            nyawa[0].SetActive(true);
            nyawa[1].SetActive(false);
            nyawa[2].SetActive(false);
        }
        else if (totalNyawa == 0)
        {
            nyawa[0].SetActive(false);
            nyawa[1].SetActive(false);
            nyawa[2].SetActive(false);
        }
    }
}
