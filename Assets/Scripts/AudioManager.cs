using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public
    AudioSource BGMAudioSource, SFXAudioSource;

    public float volumeBGM, volumeSFX;

    //Anti typo
    string 
        _DefaultAudio = "_DefaultAudio",
        _VolumeBGM = "_VolumeBGM",
        _VolumeSFX = "_VolumeSFX";

    private void Awake()
    {
        if (instance == null) instance = this;

        if (PlayerPrefs.GetFloat(_DefaultAudio) == 0)
        {
            PlayerPrefs.SetFloat(_DefaultAudio, 1);
            PlayerPrefs.SetFloat(_VolumeBGM, 0.6f);
            PlayerPrefs.SetFloat(_VolumeSFX, 0.6f);
        }


        LoadDataAudio();
    }
    private void Start()
    {

    }

    void LoadDataAudio()
    {
        volumeBGM = PlayerPrefs.GetFloat(_VolumeBGM);
        volumeSFX = PlayerPrefs.GetFloat(_VolumeSFX);

        BGMAudioSource.volume = volumeBGM;
        SFXAudioSource.volume = volumeSFX;
    }

    public void SetVolumeBGM(float value)
    {
        volumeBGM = value;
        PlayerPrefs.SetFloat(_VolumeBGM, volumeBGM);
    }
    public void SetVolumeSFX(float value)
    {
        volumeSFX = value;
        PlayerPrefs.SetFloat(_VolumeSFX, volumeSFX);
    }
}
