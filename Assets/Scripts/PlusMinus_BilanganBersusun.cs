using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlusMinus_BilanganBersusun : MonoBehaviour
{
    public string input;

    public TextMeshProUGUI naikText;
    public TextMeshProUGUI soalAtasText;
    public TextMeshProUGUI operatorAritmatikText;
    public TextMeshProUGUI soalBawahText;
    public TMP_InputField jawabanInput;

    public void JawabanInput()
    {
        input = jawabanInput.text;
        PlusMinus_Gameplay.instance.JawabanInput(input);
    }

    public void ResetJawaban()
    {
        input = "";
        jawabanInput.text = "";
    }
}
