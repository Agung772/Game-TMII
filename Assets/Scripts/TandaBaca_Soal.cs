using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TandaBaca_Soal : MonoBehaviour
{
    public string[] jawaban;
    public TextMeshProUGUI[] inputs;

    private void OnValidate()
    {
        if (jawaban.Length != transform.childCount - 1)
        {
            jawaban = new string[transform.childCount - 1];
        }

        inputs = new TextMeshProUGUI[transform.childCount -1];

        for (int i = 0; i < inputs.Length; i++)
        {
            inputs[i] = transform.GetChild(i + 1).GetComponent<TextMeshProUGUI>();

        }
    }
}
