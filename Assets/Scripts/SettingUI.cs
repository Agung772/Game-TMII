using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SettingUI : MonoBehaviour
{
    public static SettingUI instance;

    public Slider BGMSlider, SFXSlider;

    public ToggleSlide toggleSlide;

    [SerializeField]
    Transform audioButton, videoButton;

    [SerializeField]
    GameObject audioUI, videoUI;

    [SerializeField]
    TMP_Dropdown sizeScreenDD;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        BGMSlider.onValueChanged.AddListener(AudioManager.instance.SetVolumeBGM);
        BGMSlider.value = AudioManager.instance.volumeBGM;

        SFXSlider.onValueChanged.AddListener(AudioManager.instance.SetVolumeSFX);
        SFXSlider.value = AudioManager.instance.volumeSFX;

        if (DataGame.instance.fullScreen == 1) { toggleSlide.isOn = true; fullscreen = true; }
        else { toggleSlide.isOn = false; fullscreen = false; }

        SetUI("Audio");
        SizeScreen();
    }

    public void SetUI(string value)
    {
        if (value == "Audio")
        {
            videoButton.SetAsFirstSibling();
            audioButton.SetSiblingIndex(transform.childCount - 2);

            audioUI.SetActive(true);
            videoUI.SetActive(false);
        }
        else if (value == "Video")
        {
            videoButton.SetSiblingIndex(transform.childCount - 2);
            audioButton.SetAsFirstSibling();


            audioUI.SetActive(false);
            videoUI.SetActive(true);
        }
    }

    public bool fullscreen;
    public void SetFullscreen()
    {
        Screen.fullScreen = fullscreen;
        if (!fullscreen)
        {
            fullscreen = true;
            int maxsize = Screen.resolutions.Length - 1;
            PlayerPrefs.SetFloat(DataGame.instance._FullScreen, 1);
            PlayerPrefs.SetFloat(DataGame.instance._SizeScreen, maxsize);
            DataGame.instance.fullScreen = 1;
            DataGame.instance.sizeScreen = maxsize;
            Screen.SetResolution(Screen.resolutions[maxsize].width, Screen.resolutions[maxsize].height, true);

            print(Screen.resolutions[maxsize].width + " x " + Screen.resolutions[maxsize].height);
        }
        else
        {
            fullscreen = false;
            int minisize = 19;
            PlayerPrefs.SetFloat(DataGame.instance._FullScreen, 0);
            PlayerPrefs.SetFloat(DataGame.instance._SizeScreen, minisize);
            DataGame.instance.fullScreen = 0;
            DataGame.instance.sizeScreen = minisize;
            Screen.SetResolution(Screen.resolutions[minisize].width, Screen.resolutions[minisize].height, false);

            print(Screen.resolutions[minisize].width + " x " + Screen.resolutions[minisize].height);
        }

        sizeScreenDD.value = (int)DataGame.instance.sizeScreen - 9;
        sizeScreenDD.RefreshShownValue();
    }

    void SizeScreen()
    {
        sizeScreenDD.ClearOptions();

        Resolution[] resolutions = Screen.resolutions;
        List<string> options = new List<string>();

        for (int i = 0; i < resolutions.Length; i++)
        {
            if (i >= 9)
            {
                options.Add(resolutions[i].width + " x " + resolutions[i].height);
            }

        }

        sizeScreenDD.AddOptions(options);
        sizeScreenDD.value = (int)DataGame.instance.sizeScreen;
        sizeScreenDD.RefreshShownValue();
    }

    public void SetSizeScreen(int value)
    {
        int start = 9;

        bool fullscreen = System.Convert.ToBoolean(DataGame.instance.fullScreen);

        Screen.SetResolution(Screen.resolutions[value + start].width, Screen.resolutions[value + start].height, fullscreen);
        PlayerPrefs.SetFloat(DataGame.instance._SizeScreen, value);
        DataGame.instance.sizeScreen = value;

        print(Screen.resolutions[value + start].width + " x " + Screen.resolutions[value + start].height);
    }


}
