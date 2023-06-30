using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Bilangan_Input : MonoBehaviour
{
    public int output;

    [SerializeField] TextMeshProUGUI outputText;

    public void InputButton(bool right)
    {
        if (right)
        {
            output++;
        }
        else
        {
            output--;
        }

        outputText.text = output.ToString();
    }
}
