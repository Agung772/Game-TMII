using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Minigame_UI : MonoBehaviour
{
    public static Minigame_UI instance;

    [SerializeField] GameObject scoreUI;
    [SerializeField] Sprite[] tropi;
    [SerializeField] Image tropiImage;
    [SerializeField] TextMeshProUGUI titleText;

    private void Awake()
    {
        instance = this;
    }

    public void ScoreUI(string namaMinigame,int score)
    {
        scoreUI.SetActive(true);
        if (score == 0)
        {
            tropiImage.sprite = tropi[0];
            titleText.text = "JANGAN MENYERAH AYO COBA LAGI!";
        }
        else if (score == 1)
        {
            tropiImage.sprite = tropi[1];
            titleText.text = "BAIK!";
        }
        else if (score == 2)
        {
            tropiImage.sprite = tropi[2];
            titleText.text = "KEREN!";
        }
        else if (score == 3)
        {
            tropiImage.sprite = tropi[3];
            titleText.text = "HEBAT BENAR SEMUA!";
        }

        DataGame.instance.minigame.SaveMinigame(namaMinigame, score);
    }
}
