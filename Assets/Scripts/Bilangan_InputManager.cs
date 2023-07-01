using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bilangan_InputManager : MonoBehaviour
{
    public static Bilangan_InputManager instance;

    public int output;

    public Bilangan_Input 
        ribuan,
        ratusan,
        puluhan,
        satuan;
    private void Awake()
    {
        instance = this;
    }

    public void OutputUpdate()
    {
        string temp = ribuan.output.ToString() + ratusan.output.ToString() + puluhan.output.ToString() + satuan.output.ToString();
        output = int.Parse(temp);

        ribuan.outputText.text = ribuan.output.ToString();
        ratusan.outputText.text = ratusan.output.ToString();
        puluhan.outputText.text = puluhan.output.ToString();
        satuan.outputText.text = satuan.output.ToString();
    }

    public void OutputReset()
    {
        output = 0;

        ribuan.output = 0;
        ratusan.output = 0;
        puluhan.output = 0;
        satuan.output = 0;

        OutputUpdate();
    }
}
