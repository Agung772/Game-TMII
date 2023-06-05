using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KartuMemori_UI : MonoBehaviour
{
    public static KartuMemori_UI instance;

    public TextMeshProUGUI gameTimeText;
    public TextMeshProUGUI totalSelesaiText;

    public GameObject kartuSumatera;
    private void Awake()
    {
        instance = this;
    }
}
