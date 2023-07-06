using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlusMinus_UI : MonoBehaviour
{
    public static PlusMinus_UI instance;

    public TextMeshProUGUI jumlahSoalText;
    public TextMeshProUGUI soalText;

    public Transform bilanganBersusunParent;
    public GameObject bilanganBersusunPrefab;
    private void Awake()
    {
        instance = this;
    }
}
