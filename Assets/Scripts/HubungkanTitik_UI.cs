using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HubungkanTitik_UI : MonoBehaviour
{
    public static HubungkanTitik_UI instance;

    public TextMeshProUGUI soalText;

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
