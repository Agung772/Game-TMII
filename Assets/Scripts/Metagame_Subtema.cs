using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class Metagame_Subtema : MonoBehaviour
{
    public string namaScene;
    public Button button;
    public TextMeshProUGUI titleText;

    public void PindahScene()
    {
        UIManager.instance.PindahScene(namaScene);
    }

}
