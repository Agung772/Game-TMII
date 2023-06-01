using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TokoUI : MonoBehaviour
{
    public static TokoUI instance;

    [SerializeField]
    TextMeshProUGUI koinText;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        LoadData();
    }

    public void LoadData()
    {
        koinText.text = DataGame.instance.koin.ToString("F0");
    }

    bool tokoUI;
    public void SetTokoUI()
    {
        if (!tokoUI)
        {
            tokoUI = true;
            gameObject.SetActive(true);
        }
        else
        {
            tokoUI = false;
            gameObject.SetActive(false);
        }
    }


}
