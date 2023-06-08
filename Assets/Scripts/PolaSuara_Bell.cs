using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolaSuara_Bell : MonoBehaviour
{
    public int codeBell;

    [SerializeField] AudioClip suaraBell;
    [SerializeField] GameObject efectBunyi;

    public bool cooldown, putarSuara, nonClick;
    public void ClickBell()
    {
        if (!cooldown && !putarSuara && !nonClick)
        {
            cooldown = true;
            StartCoroutine(Coroutine());
            IEnumerator Coroutine()
            {
                AudioManager.instance.SFXAudioSource.PlayOneShot(suaraBell);
                efectBunyi.SetActive(true);

                PolaSuara_Gameplay.instance.CheckBell(codeBell);
                yield return new WaitForSeconds(2);


                efectBunyi.SetActive(false);
                cooldown = false;
            }
        }
        else if (cooldown && putarSuara)
        {
            UIManager.instance.SpawnNotif("Kami sedang ngecek jawaban kamu");
        }
        else if (cooldown)
        {
            UIManager.instance.SpawnNotif("Sabar boss lagi cooldown");
        }
        else if (putarSuara)
        {
            UIManager.instance.SpawnNotif("Sebentar, Melodi sedang di putar");
        }
        else if (nonClick)
        {
            UIManager.instance.SpawnNotif("Tekan tombol putar suara untuk mengetahui soal");
        }


    }

    public void StartBell()
    {
        StartCoroutine(Coroutine());
        IEnumerator Coroutine()
        {
            AudioManager.instance.SFXAudioSource.PlayOneShot(suaraBell);
            efectBunyi.SetActive(true);
            print("Bunyi " + gameObject.name);
            yield return new WaitForSeconds(2);
            efectBunyi.SetActive(false);

        }
    }
}
