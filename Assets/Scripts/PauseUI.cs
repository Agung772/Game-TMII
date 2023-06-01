using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseUI : MonoBehaviour
{
    public Slider BGMSlider, SFXSlider;

    public Button howtoplayButton, mainmenuButton;

    private void Start()
    {
        BGMSlider.onValueChanged.AddListener(AudioManager.instance.SetVolumeBGM);
        BGMSlider.value = AudioManager.instance.volumeBGM;

        SFXSlider.onValueChanged.AddListener(AudioManager.instance.SetVolumeSFX);
        SFXSlider.value = AudioManager.instance.volumeSFX;

        howtoplayButton.onClick.AddListener(UIManager.instance.Howtoplay);

        mainmenuButton.onClick.AddListener(Mainmenu);
    }

    bool oneClick;
    void Mainmenu()
    {
        if (oneClick) return;
        UIManager.instance.PindahScene("Mainmenu");
        oneClick = true;
    }

    bool pause;
    public void Pause()
    {
        if (!pause)
        {
            pause = true;
            gameObject.SetActive(true);
        }
        else if (pause)
        {
            pause = false;
            gameObject.SetActive(false);
        }
    }
}
